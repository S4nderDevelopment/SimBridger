using SimBridger.Common;
using SimBridger.Main;
using System.Diagnostics;

Debug.Assert(SimXperienceTelemetry.Size == 260,
    $"Expected 260 bytes, got {SimXperienceTelemetry.Size}");

var packet = new SimXperienceTelemetry { Yaw = 1.5f, Speed = 42f };
var bytes = packet.ToByteArray();
var roundTrip = SimXperienceTelemetry.FromByteArray(bytes);
Debug.Assert(roundTrip is { Yaw: 1.5f, Speed: 42f });

using var client = new SimXperienceUdpClient();
var bytesSent = client.Send(bytes);
Console.WriteLine($"Sent {bytesSent} bytes ({SimXperienceTelemetry.Size}-byte telemetry packet) " +
    $"to {Constants.SimXperienceHost}:{Constants.SimXperiencePort}");
