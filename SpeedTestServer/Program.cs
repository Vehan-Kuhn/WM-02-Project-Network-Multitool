
using System.Diagnostics;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Configure the local speed-test server
var port = Environment.GetEnvironmentVariable("PORT") ?? "5080";

builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// Allow uploads up to 500 MB
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 500L * 1024 * 1024;
});

var app = builder.Build();

// -----------------------------------------
// 1. PING ENDPOINT
// -----------------------------------------

app.MapGet("/ping", () =>
{
    return Results.Json(new
    {
        Status = "Online",
        Server = "Custom C# Speed Test Server",
        Timestamp = DateTime.UtcNow
    });
});

// -----------------------------------------
// 2. DOWNLOAD ENDPOINT
// -----------------------------------------

app.MapGet("/download", async (HttpContext context) =>
{
    int megabytes = 50;

    if (int.TryParse(context.Request.Query["mb"], out int requestedSize))
    {
        megabytes = requestedSize;
    }

    if (megabytes < 1 || megabytes > 500)
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync(
            "Download size must be between 1 and 500 MB.");

        return;
    }

    long totalBytes = megabytes * 1024L * 1024L;

    byte[] buffer = new byte[64 * 1024];

    RandomNumberGenerator.Fill(buffer);

    context.Response.ContentType = "application/octet-stream";
    context.Response.ContentLength = totalBytes;

    long remaining = totalBytes;

    while (remaining > 0)
    {
        context.RequestAborted.ThrowIfCancellationRequested();

        int bytesToWrite = (int)Math.Min(buffer.Length, remaining);

        await context.Response.Body.WriteAsync(
            buffer.AsMemory(0, bytesToWrite),
            context.RequestAborted);

        remaining -= bytesToWrite;
    }

    await context.Response.Body.FlushAsync(
        context.RequestAborted);
});

// -----------------------------------------
// 3. UPLOAD ENDPOINT
// -----------------------------------------

app.MapPost("/upload", async (HttpContext context) =>
{
    Stopwatch stopwatch = Stopwatch.StartNew();

    long totalBytes = 0;

    byte[] buffer = new byte[64 * 1024];

    int bytesRead;

    while ((bytesRead = await context.Request.Body.ReadAsync(
        buffer.AsMemory(0, buffer.Length),
        context.RequestAborted)) > 0)
    {
        totalBytes += bytesRead;
    }

    stopwatch.Stop();

    return Results.Json(new
    {
        Status = "Upload received",
        BytesReceived = totalBytes,
        ElapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds
    });
});

// -----------------------------------------
// START SERVER
// -----------------------------------------

app.Run();
