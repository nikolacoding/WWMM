using System.Diagnostics;

namespace WWMM
{
    public partial class MainForm : Form
    {

        private Cheats cheats = new Cheats();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void checkStateButton_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("POP2");
            if (processes.Length == 0)
            {
                statusLabel.Text = "Game not detected!";
                statusLabel.ForeColor = Color.Red;
            }
            else
            {
                statusLabel.Text = "Game is running!";
                statusLabel.ForeColor = Color.Green;
            }
        }

        private void infoButton_Click(object sender, EventArgs e) {
            MessageBox.Show("Note: The game process might be detected perfectly, but the either of the two cheats aren't guaranteed to work since " +
                "there exist tens of variants of the POP2.exe binary and they aren't compiled the same way, especially since this is an old 32-bit DX9 " +
                "game. The version confirmed to work is the most common one -- the standard, unmodded Steam version.", "Info");
        }

        private void invincibilityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool success = cheats.EnableGodMode(invincibilityCheckBox.Checked);
            if (!success)
            {
                invincibilityCheckBox.CheckedChanged -= invincibilityCheckBox_CheckedChanged;
                invincibilityCheckBox.Checked = cheats.isGodModeActive;
                invincibilityCheckBox.CheckedChanged += invincibilityCheckBox_CheckedChanged;
            }
        }

        private void infiniteSandCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool success = cheats.EnableInfiniteSand(infiniteSandCheckBox.Checked);

            if (!success)
            {
                infiniteSandCheckBox.CheckedChanged -= infiniteSandCheckBox_CheckedChanged;
                infiniteSandCheckBox.Checked = cheats.isInfiniteSandActive;
                infiniteSandCheckBox.CheckedChanged += infiniteSandCheckBox_CheckedChanged;
            }
        }
    }
}