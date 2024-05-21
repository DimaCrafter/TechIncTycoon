using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CustomLauncher {
    public partial class MainForm: Form {
        public MainForm () {
            InitializeComponent();
        }

        private void OnLoad (object sender, EventArgs e) {

        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture ();
        [DllImport("User32.dll")]
        public static extern int SendMessage (IntPtr hWnd, int Msg, int wParam, int lParam);

        private void label1_MouseDown (object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button2_Click (object sender, EventArgs e) {
            Application.Exit();
        }

        private void button1_Click (object sender, EventArgs e) {
            Process.Start(new ProcessStartInfo {
                FileName = "TechIncTycoon.exe",
                Arguments = $"--player:{textBox1.Text}"
            });

            Application.Exit();
        }
    }
}
