using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SimBridger.UI;

public partial class MainForm : Form
{
    private const int EM_GETFIRSTVISIBLELINE = 0x00CE;
    private const int EM_LINESCROLL = 0x00B6;
    private const int SB_VERT = 1;
    private const uint SIF_RANGE = 0x1;
    private const uint SIF_PAGE = 0x2;
    private const uint SIF_POS = 0x4;
    private const uint SIF_ALL = SIF_RANGE | SIF_PAGE | SIF_POS;

    [StructLayout(LayoutKind.Sequential)]
    private struct SCROLLINFO
    {
        public uint cbSize;
        public uint fMask;
        public int nMin;
        public int nMax;
        public uint nPage;
        public int nPos;
        public int nTrackPos;
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetScrollInfo(IntPtr hwnd, int nBar, ref SCROLLINFO lpsi);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Action? OnStartClicked { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Action? OnStopClicked { get; set; }

    public MainForm()
    {
        InitializeComponent();
    }

    public void AddLog(string line)
    {
        AppendLine($"[{DateTime.Now:HH:mm:ss}] {line}");
    }

    private void AppendLine(string text)
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => AppendLine(text));
            return;
        }

        int firstVisible = SendMessage(logTextBox.Handle, EM_GETFIRSTVISIBLELINE, 0, 0);
        var si = new SCROLLINFO { cbSize = (uint)Marshal.SizeOf<SCROLLINFO>(), fMask = SIF_ALL };
        bool wasAtBottom = !GetScrollInfo(logTextBox.Handle, SB_VERT, ref si)
                           || si.nPos + (int)si.nPage > si.nMax;

        logTextBox.AppendText(text + Environment.NewLine);

        if (!wasAtBottom)
        {
            int currentFirst = SendMessage(logTextBox.Handle, EM_GETFIRSTVISIBLELINE, 0, 0);
            _ = SendMessage(logTextBox.Handle, EM_LINESCROLL, 0, firstVisible - currentFirst);
        }
    }

    private void StartButton_Click(object? sender, EventArgs e)
    {
        OnStartClicked?.Invoke();
        startButton.Enabled = false;
        stopButton.Enabled = true;
    }

    private void StopButton_Click(object? sender, EventArgs e)
    {
        OnStopClicked?.Invoke();
        startButton.Enabled = true;
        stopButton.Enabled = false;
    }
}
