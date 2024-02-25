namespace Survival
{
    partial class Form1
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
            inputBox = new TextBox();
            panel1 = new Panel();
            currentWeight = new Label();
            maxWeight = new Label();
            locationL = new Label();
            thirst = new Label();
            hunger = new Label();
            health = new Label();
            menuStrip1 = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            consoleBox = new TextBox();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // inputBox
            // 
            inputBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            inputBox.Location = new Point(12, 271);
            inputBox.MaxLength = 1000;
            inputBox.Name = "inputBox";
            inputBox.PlaceholderText = "Enter 'help' for help..";
            inputBox.Size = new Size(492, 23);
            inputBox.TabIndex = 0;
            inputBox.KeyDown += inputBox_KeyDown;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(currentWeight);
            panel1.Controls.Add(maxWeight);
            panel1.Controls.Add(locationL);
            panel1.Controls.Add(thirst);
            panel1.Controls.Add(hunger);
            panel1.Controls.Add(health);
            panel1.Location = new Point(12, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(196, 131);
            panel1.TabIndex = 1;
            // 
            // currentWeight
            // 
            currentWeight.AutoSize = true;
            currentWeight.Location = new Point(-1, 84);
            currentWeight.Name = "currentWeight";
            currentWeight.Size = new Size(94, 15);
            currentWeight.TabIndex = 5;
            currentWeight.Text = "Current Weight: ";
            // 
            // maxWeight
            // 
            maxWeight.AutoSize = true;
            maxWeight.Location = new Point(-1, 99);
            maxWeight.Name = "maxWeight";
            maxWeight.Size = new Size(74, 15);
            maxWeight.TabIndex = 4;
            maxWeight.Text = "Max Weight:";
            // 
            // locationL
            // 
            locationL.AutoSize = true;
            locationL.Location = new Point(-1, 114);
            locationL.Name = "locationL";
            locationL.Size = new Size(56, 15);
            locationL.TabIndex = 3;
            locationL.Text = "Location:";
            // 
            // thirst
            // 
            thirst.AutoSize = true;
            thirst.Location = new Point(-1, 30);
            thirst.Name = "thirst";
            thirst.Size = new Size(39, 15);
            thirst.TabIndex = 2;
            thirst.Text = "Thirst:";
            // 
            // hunger
            // 
            hunger.AutoSize = true;
            hunger.Location = new Point(-1, 15);
            hunger.Name = "hunger";
            hunger.Size = new Size(50, 15);
            hunger.TabIndex = 1;
            hunger.Text = "Hunger:";
            // 
            // health
            // 
            health.AutoSize = true;
            health.Location = new Point(-1, 0);
            health.Name = "health";
            health.Size = new Size(48, 15);
            health.TabIndex = 0;
            health.Text = "Health: ";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(516, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem, quitToolStripMenuItem });
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(50, 20);
            gameToolStripMenuItem.Text = "Game";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(140, 22);
            saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            loadToolStripMenuItem.Size = new Size(140, 22);
            loadToolStripMenuItem.Text = "Load";
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            quitToolStripMenuItem.Size = new Size(140, 22);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // consoleBox
            // 
            consoleBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleBox.Location = new Point(12, 177);
            consoleBox.MaxLength = 1000;
            consoleBox.Multiline = true;
            consoleBox.Name = "consoleBox";
            consoleBox.ReadOnly = true;
            consoleBox.ScrollBars = ScrollBars.Vertical;
            consoleBox.Size = new Size(492, 88);
            consoleBox.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 306);
            Controls.Add(consoleBox);
            Controls.Add(panel1);
            Controls.Add(inputBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Survival";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputBox;
        private Panel panel1;
        private Label thirst;
        private Label hunger;
        private Label health;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private TextBox consoleBox;
        private Label locationL;
        private Label maxWeight;
        private Label currentWeight;
    }
}
