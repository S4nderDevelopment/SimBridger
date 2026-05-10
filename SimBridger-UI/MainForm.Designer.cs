namespace SimBridger.UI;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Button startButton;
    private System.Windows.Forms.Button stopButton;
    private System.Windows.Forms.TextBox logTextBox;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        startButton = new System.Windows.Forms.Button();
        stopButton = new System.Windows.Forms.Button();
        logTextBox = new System.Windows.Forms.TextBox();
        SuspendLayout();

        startButton.Location = new System.Drawing.Point(12, 12);
        startButton.Size = new System.Drawing.Size(140, 32);
        startButton.Text = "Start NGP Client";
        startButton.Click += StartButton_Click;

        stopButton.Location = new System.Drawing.Point(160, 12);
        stopButton.Size = new System.Drawing.Size(140, 32);
        stopButton.Text = "Stop NGP Client";
        stopButton.Enabled = false;
        stopButton.Click += StopButton_Click;

        logTextBox.Location = new System.Drawing.Point(12, 56);
        logTextBox.Size = new System.Drawing.Size(776, 382);
        logTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
                          | System.Windows.Forms.AnchorStyles.Bottom
                          | System.Windows.Forms.AnchorStyles.Left
                          | System.Windows.Forms.AnchorStyles.Right;
        logTextBox.Multiline = true;
        logTextBox.ReadOnly = true;
        logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        logTextBox.WordWrap = false;
        logTextBox.BackColor = System.Drawing.SystemColors.Window;
        logTextBox.Font = new System.Drawing.Font("Consolas", 9F);

        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(startButton);
        Controls.Add(stopButton);
        Controls.Add(logTextBox);
        Text = "SimBridger";
        ResumeLayout(false);
        PerformLayout();
    }
}
