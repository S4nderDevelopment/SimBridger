using System.Net;

namespace SimBridger.RbrNgp;

internal static class NgpConstants
{
    public static readonly IPAddress ListenHost = IPAddress.Loopback;
    public const int ListenPort = 6776;
}
