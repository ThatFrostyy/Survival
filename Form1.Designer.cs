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
            craftButton = new Button();
            shopGrid = new DataGridView();
            armor = new Label();
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
            craftToolStripMenuItem = new ToolStripMenuItem();
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
            inputBox.Location = new Point(17, 630);
            inputBox.Margin = new Padding(4, 5, 4, 5);
            inputBox.MaxLength = 1000;
            inputBox.Name = "inputBox";
            inputBox.PlaceholderText = "Enter 'help' for help..";
            inputBox.Size = new Size(708, 31);
            inputBox.TabIndex = 0;
            inputBox.KeyDown += InputBox_KeyDown;
            // 
            // statsPanel
            // 
            statsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            statsPanel.BorderStyle = BorderStyle.FixedSingle;
            statsPanel.Controls.Add(craftButton);
            statsPanel.Controls.Add(shopGrid);
            statsPanel.Controls.Add(armor);
            statsPanel.Controls.Add(currentWeight);
            statsPanel.Controls.Add(maxWeight);
            statsPanel.Controls.Add(locationL);
            statsPanel.Controls.Add(thirst);
            statsPanel.Controls.Add(hunger);
            statsPanel.Controls.Add(health);
            statsPanel.Location = new Point(17, 67);
            statsPanel.Margin = new Padding(4, 5, 4, 5);
            statsPanel.Name = "statsPanel";
            statsPanel.Size = new Size(279, 395);
            statsPanel.TabIndex = 1;
            // 
            // craftButton
            // 
            craftButton.Location = new Point(166, 360);
            craftButton.Name = "craftButton";
            craftButton.Size = new Size(112, 34);
            craftButton.TabIndex = 5;
            craftButton.Text = "Craft";
            craftButton.UseVisualStyleBackColor = true;
            craftButton.Click += craftButton_Click;
            // 
            // shopGrid
            // 
            shopGrid.AllowUserToAddRows = false;
            shopGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            shopGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            shopGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            shopGrid.Location = new Point(-1, -2);
            shopGrid.Name = "shopGrid";
            shopGrid.ReadOnly = true;
            shopGrid.RowHeadersVisible = false;
            shopGrid.RowHeadersWidth = 62;
            shopGrid.Size = new Size(283, 238);
            shopGrid.TabIndex = 5;
            shopGrid.Visible = false;
            // 
            // armor
            // 
            armor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            armor.AutoSize = true;
            armor.Location = new Point(-1, 75);
            armor.Name = "armor";
            armor.Size = new Size(114, 25);
            armor.TabIndex = 6;
            armor.Text = "Armor Value:";
            // 
            // currentWeight
            // 
            currentWeight.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            currentWeight.AutoSize = true;
            currentWeight.Location = new Point(-1, 318);
            currentWeight.Margin = new Padding(4, 0, 4, 0);
            currentWeight.Name = "currentWeight";
            currentWeight.Size = new Size(140, 25);
            currentWeight.TabIndex = 5;
            currentWeight.Text = "Current Weight: ";
            // 
            // maxWeight
            // 
            maxWeight.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            maxWeight.AutoSize = true;
            maxWeight.Location = new Point(-1, 343);
            maxWeight.Margin = new Padding(4, 0, 4, 0);
            maxWeight.Name = "maxWeight";
            maxWeight.Size = new Size(110, 25);
            maxWeight.TabIndex = 4;
            maxWeight.Text = "Max Weight:";
            // 
            // locationL
            // 
            locationL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            locationL.AutoSize = true;
            locationL.Location = new Point(-1, 368);
            locationL.Margin = new Padding(4, 0, 4, 0);
            locationL.Name = "locationL";
            locationL.Size = new Size(83, 25);
            locationL.TabIndex = 3;
            locationL.Text = "Location:";
            // 
            // thirst
            // 
            thirst.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            thirst.AutoSize = true;
            thirst.Location = new Point(-1, 50);
            thirst.Margin = new Padding(4, 0, 4, 0);
            thirst.Name = "thirst";
            thirst.Size = new Size(59, 25);
            thirst.TabIndex = 2;
            thirst.Text = "Thirst:";
            // 
            // hunger
            // 
            hunger.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            hunger.AutoSize = true;
            hunger.Location = new Point(-1, 25);
            hunger.Margin = new Padding(4, 0, 4, 0);
            hunger.Name = "hunger";
            hunger.Size = new Size(75, 25);
            hunger.TabIndex = 1;
            hunger.Text = "Hunger:";
            // 
            // health
            // 
            health.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            health.AutoSize = true;
            health.Location = new Point(-1, 0);
            health.Margin = new Padding(4, 0, 4, 0);
            health.Name = "health";
            health.Size = new Size(72, 25);
            health.TabIndex = 0;
            health.Text = "Health: ";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem, craftToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(744, 35);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem, quitToolStripMenuItem });
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(74, 29);
            gameToolStripMenuItem.Text = "Game";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(213, 34);
            saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            loadToolStripMenuItem.Size = new Size(213, 34);
            loadToolStripMenuItem.Text = "Load";
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            quitToolStripMenuItem.Size = new Size(213, 34);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += QuitToolStripMenuItem_Click;
            // 
            // craftToolStripMenuItem
            // 
            craftToolStripMenuItem.Name = "craftToolStripMenuItem";
            craftToolStripMenuItem.Size = new Size(16, 29);
            // 
            // consoleBox
            // 
            consoleBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleBox.Location = new Point(17, 473);
            consoleBox.Margin = new Padding(4, 5, 4, 5);
            consoleBox.MaxLength = 1000;
            consoleBox.Multiline = true;
            consoleBox.Name = "consoleBox";
            consoleBox.ReadOnly = true;
            consoleBox.ScrollBars = ScrollBars.Vertical;
            consoleBox.Size = new Size(708, 144);
            consoleBox.TabIndex = 3;
            // 
            // inventoryGrid
            // 
            inventoryGrid.AllowUserToAddRows = false;
            inventoryGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            inventoryGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            inventoryGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inventoryGrid.Location = new Point(306, 67);
            inventoryGrid.Margin = new Padding(4, 5, 4, 5);
            inventoryGrid.Name = "inventoryGrid";
            inventoryGrid.ReadOnly = true;
            inventoryGrid.RowHeadersVisible = false;
            inventoryGrid.RowHeadersWidth = 62;
            inventoryGrid.Size = new Size(421, 397);
            inventoryGrid.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 688);
            Controls.Add(inventoryGrid);
            Controls.Add(consoleBox);
            Controls.Add(statsPanel);
            Controls.Add(inputBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
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
        private Label armor;
        private Button craftButton;
        private ToolStripMenuItem craftToolStripMenuItem;
    }
}
