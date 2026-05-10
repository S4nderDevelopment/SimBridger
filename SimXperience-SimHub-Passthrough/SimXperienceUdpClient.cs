using System.Net;
using System.Net.Sockets;

namespace SimXperienceSimHubPassthrough;

internal sealed class SimXperienceUdpClient : IDisposable
{
    private readonly UdpClient _client = new();
    private readonly IPEndPoint _endpoint = new(
        IPAddress.Parse(Constants.SimXperienceHost),
        Constants.SimXperiencePort);

    public int Send(byte[] data) => _client.Send(data, data.Length, _endpoint);

    public void Dispose() => _client.Dispose();
}
