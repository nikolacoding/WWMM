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