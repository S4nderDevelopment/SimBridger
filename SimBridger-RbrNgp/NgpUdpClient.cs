using System.Net;
using System.Net.Sockets;

namespace SimBridger.RbrNgp;

public sealed class NgpUdpClient : IDisposable
{
    private readonly UdpClient _client;

    public NgpUdpClient()
        : this(NgpConstants.ListenHost, NgpConstants.ListenPort) { }

    public NgpUdpClient(IPAddress host, int port)
    {
        _client = new UdpClient(new IPEndPoint(host, port));
    }

    public async Task<NgpTelemetry> ReceiveAsync(CancellationToken cancellationToken = default)
    {
        var result = await _client.ReceiveAsync(cancellationToken);
        return NgpTelemetry.FromByteArray(result.Buffer);
    }

    public void Dispose() => _client.Dispose();

    // Reference implementation of the wait → receive → instantiate → wait loop.
    // Not wired to a Main; call from your own driver (or a future passthrough
    // pipeline) when you want to consume NGP UDP telemetry.
    public static async Task LoopExample(CancellationToken cancellationToken = default)
    {
        using var client = new NgpUdpClient();
        Console.WriteLine(
            $"Listening for NGP telemetry on {NgpConstants.ListenHost}:{NgpConstants.ListenPort}…");
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var telemetry = await client.ReceiveAsync(cancellationToken);
                Console.WriteLine(
                    $"step={telemetry.TotalSteps} speed={telemetry.CarSpeed:F2} " +
                    $"gear={telemetry.ControlGear} rpm={telemetry.EngineRpm:F0}");
            }
            catch (OperationCanceledException) { break; }
        }
    }
}
