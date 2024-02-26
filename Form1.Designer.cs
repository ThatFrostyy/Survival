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
            statsPanel = new Panel();
            shopGrid = new DataGridView();
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
            inventoryGrid = new DataGridView();
            statsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)shopGrid).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inventoryGrid).BeginInit();
            SuspendLayout();
            // 
            // inputBox
            // 
            inputBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            inputBox.Location = new Point(12, 378);
            inputBox.MaxLength = 1000;
            inputBox.Name = "inputBox";
            inputBox.PlaceholderText = "Enter 'help' for help..";
            inputBox.Size = new Size(497, 23);
            inputBox.TabIndex = 0;
            inputBox.KeyDown += InputBox_KeyDown;
            // 
            // statsPanel
            // 
            statsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            statsPanel.BorderStyle = BorderStyle.FixedSingle;
            statsPanel.Controls.Add(shopGrid);
            statsPanel.Controls.Add(currentWeight);
            statsPanel.Controls.Add(maxWeight);
            statsPanel.Controls.Add(locationL);
            statsPanel.Controls.Add(thirst);
            statsPanel.Controls.Add(hunger);
            statsPanel.Controls.Add(health);
            statsPanel.Location = new Point(12, 40);
            statsPanel.Name = "statsPanel";
            statsPanel.Size = new Size(196, 238);
            statsPanel.TabIndex = 1;
            // 
            // shopGrid
            // 
            shopGrid.AllowUserToAddRows = false;
            shopGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            shopGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            shopGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            shopGrid.Location = new Point(-1, -1);
            shopGrid.Name = "shopGrid";
            shopGrid.ReadOnly = true;
            shopGrid.RowHeadersVisible = false;
            shopGrid.Size = new Size(196, 238);
            shopGrid.TabIndex = 5;
            shopGrid.Visible = false;
            // 
            // currentWeight
            // 
            currentWeight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            currentWeight.AutoSize = true;
            currentWeight.Location = new Point(-1, 191);
            currentWeight.Name = "currentWeight";
            currentWeight.Size = new Size(94, 15);
            currentWeight.TabIndex = 5;
            currentWeight.Text = "Current Weight: ";
            // 
            // maxWeight
            // 
            maxWeight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            maxWeight.AutoSize = true;
            maxWeight.Location = new Point(-1, 206);
            maxWeight.Name = "maxWeight";
            maxWeight.Size = new Size(74, 15);
            maxWeight.TabIndex = 4;
            maxWeight.Text = "Max Weight:";
            // 
            // locationL
            // 
            locationL.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            locationL.AutoSize = true;
            locationL.Location = new Point(-1, 221);
            locationL.Name = "locationL";
            locationL.Size = new Size(56, 15);
            locationL.TabIndex = 3;
            locationL.Text = "Location:";
            // 
            // thirst
            // 
            thirst.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            thirst.AutoSize = true;
            thirst.Location = new Point(-1, 30);
            thirst.Name = "thirst";
            thirst.Size = new Size(39, 15);
            thirst.TabIndex = 2;
            thirst.Text = "Thirst:";
            // 
            // hunger
            // 
            hunger.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            hunger.AutoSize = true;
            hunger.Location = new Point(-1, 15);
            hunger.Name = "hunger";
            hunger.Size = new Size(50, 15);
            hunger.TabIndex = 1;
            hunger.Text = "Hunger:";
            // 
            // health
            // 
            health.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
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
            menuStrip1.Size = new Size(521, 24);
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
            quitToolStripMenuItem.Click += QuitToolStripMenuItem_Click;
            // 
            // consoleBox
            // 
            consoleBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleBox.Location = new Point(12, 284);
            consoleBox.MaxLength = 1000;
            consoleBox.Multiline = true;
            consoleBox.Name = "consoleBox";
            consoleBox.ReadOnly = true;
            consoleBox.ScrollBars = ScrollBars.Vertical;
            consoleBox.Size = new Size(497, 88);
            consoleBox.TabIndex = 3;
            // 
            // inventoryGrid
            // 
            inventoryGrid.AllowUserToAddRows = false;
            inventoryGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            inventoryGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            inventoryGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inventoryGrid.Location = new Point(214, 40);
            inventoryGrid.Name = "inventoryGrid";
            inventoryGrid.ReadOnly = true;
            inventoryGrid.RowHeadersVisible = false;
            inventoryGrid.Size = new Size(295, 238);
            inventoryGrid.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 413);
            Controls.Add(inventoryGrid);
            Controls.Add(consoleBox);
            Controls.Add(statsPanel);
            Controls.Add(inputBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Survival";
            statsPanel.ResumeLayout(false);
            statsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)shopGrid).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)inventoryGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputBox;
        private Panel statsPanel;
        private Label thirst;
        private Label hunger;
        private Label health;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private Label locationL;
        private Label maxWeight;
        private Label currentWeight;
        private TextBox consoleBox;
        public DataGridView inventoryGrid;
        public DataGridView shopGrid;
    }
}
