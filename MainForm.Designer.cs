namespace WWMM
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            invincibilityCheckBox = new CheckBox();
            infiniteSandCheckBox = new CheckBox();
            checkStateButton = new Button();
            statusLabel = new Label();
            infoButton = new Button();
            SuspendLayout();
            // 
            // invincibilityCheckBox
            // 
            invincibilityCheckBox.AutoSize = true;
            invincibilityCheckBox.Location = new Point(272, 12);
            invincibilityCheckBox.Name = "invincibilityCheckBox";
            invincibilityCheckBox.Size = new Size(87, 19);
            invincibilityCheckBox.TabIndex = 0;
            invincibilityCheckBox.Text = "Invincibility";
            invincibilityCheckBox.UseVisualStyleBackColor = true;
            invincibilityCheckBox.CheckedChanged += invincibilityCheckBox_CheckedChanged;
            // 
            // infiniteSandCheckBox
            // 
            infiniteSandCheckBox.AutoSize = true;
            infiniteSandCheckBox.Location = new Point(272, 38);
            infiniteSandCheckBox.Name = "infiniteSandCheckBox";
            infiniteSandCheckBox.Size = new Size(92, 19);
            infiniteSandCheckBox.TabIndex = 1;
            infiniteSandCheckBox.Text = "Infinite Sand";
            infiniteSandCheckBox.UseVisualStyleBackColor = true;
            infiniteSandCheckBox.CheckedChanged += infiniteSandCheckBox_CheckedChanged;
            // 
            // checkStateButton
            // 
            checkStateButton.Location = new Point(12, 9);
            checkStateButton.Name = "checkStateButton";
            checkStateButton.Size = new Size(127, 23);
            checkStateButton.TabIndex = 2;
            checkStateButton.Text = "Check detection";
            checkStateButton.UseVisualStyleBackColor = true;
            checkStateButton.Click += checkStateButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(12, 39);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(0, 15);
            statusLabel.TabIndex = 3;
            // 
            // infoButton
            // 
            infoButton.Location = new Point(289, 71);
            infoButton.Name = "infoButton";
            infoButton.Size = new Size(75, 23);
            infoButton.TabIndex = 4;
            infoButton.Text = "Info";
            infoButton.UseVisualStyleBackColor = true;
            infoButton.Click += infoButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(371, 106);
            Controls.Add(infoButton);
            Controls.Add(statusLabel);
            Controls.Add(checkStateButton);
            Controls.Add(infiniteSandCheckBox);
            Controls.Add(invincibilityCheckBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "WWMM - Warrior Within Mod Menu";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox invincibilityCheckBox;
        private CheckBox infiniteSandCheckBox;
        private Button checkStateButton;
        private Label statusLabel;
        private Button infoButton;
    }
}
