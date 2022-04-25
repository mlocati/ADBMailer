using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ADBMailer
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
            if (Program.ExeIcon != null)
            {
                this.Icon = Program.ExeIcon;
            }
            try
            {
                var process = Process.GetCurrentProcess();
                var module = process.MainModule;
                if (module == null)
                {
                    throw new Exception("Modulo principale dell'applicazione non trovato!");
                }
                var exeName = module.FileName;
                if (string.IsNullOrEmpty(exeName))
                {
                    throw new Exception("Eseguibile dell'applicazione non trovato!");
                }
                var di = new FileInfo(exeName).Directory;
                var rtfName = di == null ? "" : Path.Join(di.FullName, "Help.rtf");
                if (rtfName.Length == 0 || !File.Exists(rtfName))
                {
                    throw new Exception("File della guida non trovato!");
                }
                this.rtbHelp.Rtf = File.ReadAllText(rtfName);
            }
            catch (Exception x)
            {
                this.rtbHelp.Text = x.Message;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public readonly int Left;
            public readonly int Top;
            public readonly int Right;
            public readonly int Bottom;
            public int Width { get => this.Right - this.Left; }
            public int Height { get => this.Bottom - this.Top; }

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }
        }
    }
}