using SimBridger.Common;
using SimBridger.Main;
using SimBridger.RbrNgp;
using SimBridger.UI;
using System.Diagnostics;

Debug.Assert(SimXperienceTelemetry.Size == 260,
    $"Expected 260 bytes, got {SimXperienceTelemetry.Size}");

var packet = new SimXperienceTelemetry { Yaw = 1.5f, Speed = 42f };
var bytes = packet.ToByteArray();
var roundTrip = SimXperienceTelemetry.FromByteArray(bytes);
Debug.Assert(roundTrip is { Yaw: 1.5f, Speed: 42f });

using var sxClient = new SimXperienceUdpClient();
var bytesSent = sxClient.Send(bytes);
Console.WriteLine($"Sent {bytesSent} bytes ({SimXperienceTelemetry.Size}-byte telemetry packet) " +
    $"to {Constants.SimXperienceHost}:{Constants.SimXperiencePort}");

ApplicationConfiguration.Initialize();

CancellationTokenSource? ngpCts = null;
Task? ngpLoop = null;

var mainForm = new MainForm();

mainForm.OnStartClicked = () =>
{
    mainForm.AddLog("Starting NGP client...");
    ngpCts = new CancellationTokenSource();
    ngpLoop = Task.Run(() => NgpUdpClient.LoopExample(ngpCts.Token));
};

mainForm.OnStopClicked = () =>
{
    mainForm.AddLog("Stopping NGP client...");
    ngpCts?.Cancel();
    ngpCts?.Dispose();
    ngpCts = null;
    ngpLoop = null;
};

Application.Run(mainForm);
