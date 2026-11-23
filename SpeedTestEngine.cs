
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace InternetSpeedTest
{
    public class SpeedTestEngine : IDisposable
    {
        private readonly HttpClient httpClient;
        private readonly string serverUrl;

        public SpeedTestEngine(string serverUrl)
        {
            this.serverUrl = serverUrl.TrimEnd('/');

            httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromMinutes(5)
            };
        }

        // 1. Check whether the speed-test server is online
        public async Task<bool> CheckServerAsync()
        {
            try
            {
                using HttpResponseMessage response =
                    await httpClient.GetAsync($"{serverUrl}/ping");

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        // 2. Test ping, jitter and packet loss
        public async Task<(double Ping, double Jitter, double PacketLoss)>
            TestPingAsync(int attempts = 10)
        {
            string host = new Uri(serverUrl).Host;

            using Ping pingSender = new Ping();

            double totalPing = 0;
            double previousPing = 0;
            double totalJitter = 0;
            int successfulPings = 0;
            int jitterSamples = 0;

            for (int i = 0; i < attempts; i++)
            {
                try
                {
                    PingReply reply = await pingSender.SendPingAsync(
                        host, 3000);

                    if (reply.Status == IPStatus.Success)
                    {
                        double currentPing = reply.RoundtripTime;

                        totalPing += currentPing;
                        successfulPings++;

                        if (successfulPings > 1)
                        {
                            totalJitter += Math.Abs(
                                currentPing - previousPing);

                            jitterSamples++;
                        }

                        previousPing = currentPing;
                    }
                }
                catch
                {
                    // Failed ping counts as packet loss.
                }

                await Task.Delay(100);
            }

            double packetLoss =
                ((attempts - successfulPings) / (double)attempts) * 100;

            double averagePing = successfulPings > 0
                ? totalPing / successfulPings
                : 0;

            double averageJitter = jitterSamples > 0
                ? totalJitter / jitterSamples
                : 0;

            return (averagePing, averageJitter, packetLoss);
        }

        // 3. Test download speed
        public async Task<double> TestDownloadAsync(int megabytes = 50)
        {
            if (megabytes < 1 || megabytes > 500)
                throw new ArgumentOutOfRangeException(nameof(megabytes));

            string url = $"{serverUrl}/download?mb={megabytes}";

            using HttpResponseMessage response = await httpClient.GetAsync(
                url, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            await using Stream stream =
                await response.Content.ReadAsStreamAsync();

            byte[] buffer = new byte[64 * 1024];
            long totalBytes = 0;

            Stopwatch stopwatch = Stopwatch.StartNew();

            int bytesRead;

            while ((bytesRead = await stream.ReadAsync(buffer)) > 0)
            {
                totalBytes += bytesRead;
            }

            stopwatch.Stop();

            double seconds = stopwatch.Elapsed.TotalSeconds;

            if (seconds <= 0)
                return 0;

            return (totalBytes * 8.0) / seconds / 1_000_000;
        }

        // 4. Test upload speed
        public async Task<double> TestUploadAsync(int megabytes = 50)
        {
            if (megabytes < 1 || megabytes > 500)
                throw new ArgumentOutOfRangeException(nameof(megabytes));

            long totalBytes = megabytes * 1024L * 1024L;

            byte[] buffer = new byte[64 * 1024];
            Random.Shared.NextBytes(buffer);

            using HttpContent content =
                new RepeatingDataContent(buffer, totalBytes);

            Stopwatch stopwatch = Stopwatch.StartNew();

            using HttpResponseMessage response = await httpClient.PostAsync(
                $"{serverUrl}/upload", content);

            stopwatch.Stop();

            response.EnsureSuccessStatusCode();

            double seconds = stopwatch.Elapsed.TotalSeconds;

            if (seconds <= 0)
                return 0;

            return (totalBytes * 8.0) / seconds / 1_000_000;
        }

        // Generates upload data without storing the entire test file in memory
        private sealed class RepeatingDataContent : HttpContent
        {
            private readonly byte[] buffer;
            private readonly long totalLength;

            public RepeatingDataContent(byte[] buffer, long totalLength)
            {
                this.buffer = buffer;
                this.totalLength = totalLength;

                Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue(
                        "application/octet-stream");
            }

            protected override bool TryComputeLength(out long length)
            {
                length = totalLength;
                return true;
            }

            protected override Task SerializeToStreamAsync(
                Stream stream,
                TransportContext? context)
            {
                return WriteDataAsync(stream, CancellationToken.None);
            }

            protected override Task SerializeToStreamAsync(
                Stream stream,
                TransportContext? context,
                CancellationToken cancellationToken)
            {
                return WriteDataAsync(stream, cancellationToken);
            }

            private async Task WriteDataAsync(
                Stream stream,
                CancellationToken cancellationToken)
            {
                long remaining = totalLength;

                while (remaining > 0)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    int bytesToWrite = (int)Math.Min(
                        buffer.Length, remaining);

                    await stream.WriteAsync(
                        buffer.AsMemory(0, bytesToWrite),
                        cancellationToken);

                    remaining -= bytesToWrite;
                }
            }
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
