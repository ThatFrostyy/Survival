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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            inputBox = new TextBox();
            statsPanel = new Panel();
            shopGrid = new DataGridView();
            level = new Label();
            craftButton = new Button();
            armor = new Label();
            currentWeight = new Label();
            maxWeight = new Label();
            locationL = new Label();
            thirst = new Label();
            hunger = new Label();
            health = new Label();
            xp = new Label();
            menuStrip1 = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            menusToolStripMenuItem = new ToolStripMenuItem();
            craftToolStripMenuItem1 = new ToolStripMenuItem();
            optionsToolStripMenuItem1 = new ToolStripMenuItem();
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
            inputBox.Size = new Size(606, 23);
            inputBox.TabIndex = 0;
            inputBox.KeyDown += InputBox_KeyDown;
            // 
            // statsPanel
            // 
            statsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            statsPanel.BorderStyle = BorderStyle.FixedSingle;
            statsPanel.Controls.Add(shopGrid);
            statsPanel.Controls.Add(level);
            statsPanel.Controls.Add(craftButton);
            statsPanel.Controls.Add(armor);
            statsPanel.Controls.Add(currentWeight);
            statsPanel.Controls.Add(maxWeight);
            statsPanel.Controls.Add(locationL);
            statsPanel.Controls.Add(thirst);
            statsPanel.Controls.Add(hunger);
            statsPanel.Controls.Add(health);
            statsPanel.Controls.Add(xp);
            statsPanel.Location = new Point(12, 40);
            statsPanel.Name = "statsPanel";
            statsPanel.Size = new Size(305, 238);
            statsPanel.TabIndex = 1;
            // 
            // shopGrid
            // 
            shopGrid.AllowUserToAddRows = false;
            shopGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            shopGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            shopGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            shopGrid.Location = new Point(-2, -1);
            shopGrid.Margin = new Padding(2);
            shopGrid.Name = "shopGrid";
            shopGrid.ReadOnly = true;
            shopGrid.RowHeadersVisible = false;
            shopGrid.RowHeadersWidth = 62;
            shopGrid.Size = new Size(307, 166);
            shopGrid.TabIndex = 5;
            shopGrid.Visible = false;
            // 
            // level
            // 
            level.AutoSize = true;
            level.Location = new Point(-1, 60);
            level.Margin = new Padding(2, 0, 2, 0);
            level.Name = "level";
            level.Size = new Size(40, 15);
            level.TabIndex = 7;
            level.Text = "Level: ";
            // 
            // craftButton
            // 
            craftButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            craftButton.Location = new Point(236, 204);
            craftButton.Margin = new Padding(2);
            craftButton.Name = "craftButton";
            craftButton.Size = new Size(65, 30);
            craftButton.TabIndex = 5;
            craftButton.Text = "Craft";
            craftButton.UseVisualStyleBackColor = true;
            craftButton.Click += craftButton_Click;
            // 
            // armor
            // 
            armor.AutoSize = true;
            armor.Location = new Point(-1, 45);
            armor.Margin = new Padding(2, 0, 2, 0);
            armor.Name = "armor";
            armor.Size = new Size(75, 15);
            armor.TabIndex = 6;
            armor.Text = "Armor Value:";
            // 
            // currentWeight
            // 
            currentWeight.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            currentWeight.AutoSize = true;
            currentWeight.Location = new Point(-1, 191);
            currentWeight.Name = "currentWeight";
            currentWeight.Size = new Size(94, 15);
            currentWeight.TabIndex = 5;
            currentWeight.Text = "Current Weight: ";
            // 
            // maxWeight
            // 
            maxWeight.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            maxWeight.AutoSize = true;
            maxWeight.Location = new Point(-1, 206);
            maxWeight.Name = "maxWeight";
            maxWeight.Size = new Size(74, 15);
            maxWeight.TabIndex = 4;
            maxWeight.Text = "Max Weight:";
            // 
            // locationL
            // 
            locationL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            locationL.AutoSize = true;
            locationL.Location = new Point(-1, 221);
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
            // xp
            // 
            xp.AutoSize = true;
            xp.Location = new Point(-1, 75);
            xp.Margin = new Padding(2, 0, 2, 0);
            xp.Name = "xp";
            xp.Size = new Size(24, 15);
            xp.TabIndex = 8;
            xp.Text = "XP:";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem, menusToolStripMenuItem, optionsToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(630, 24);
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
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            loadToolStripMenuItem.Size = new Size(180, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            quitToolStripMenuItem.Size = new Size(180, 22);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += QuitToolStripMenuItem_Click;
            // 
            // menusToolStripMenuItem
            // 
            menusToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { craftToolStripMenuItem1 });
            menusToolStripMenuItem.Name = "menusToolStripMenuItem";
            menusToolStripMenuItem.Size = new Size(63, 20);
            menusToolStripMenuItem.Text = "Window";
            // 
            // craftToolStripMenuItem1
            // 
            craftToolStripMenuItem1.Image = (Image)resources.GetObject("craftToolStripMenuItem1.Image");
            craftToolStripMenuItem1.Name = "craftToolStripMenuItem1";
            craftToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.M;
            craftToolStripMenuItem1.Size = new Size(188, 30);
            craftToolStripMenuItem1.Text = "Craft";
            craftToolStripMenuItem1.Click += craftToolStripMenuItem1_Click;
            // 
            // optionsToolStripMenuItem1
            // 
            optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            optionsToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.O;
            optionsToolStripMenuItem1.Size = new Size(61, 20);
            optionsToolStripMenuItem1.Text = "Options";
            optionsToolStripMenuItem1.Click += optionsToolStripMenuItem1_Click;
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
            consoleBox.Size = new Size(606, 88);
            consoleBox.TabIndex = 3;
            // 
            // inventoryGrid
            // 
            inventoryGrid.AllowUserToAddRows = false;
            inventoryGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            inventoryGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            inventoryGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inventoryGrid.Location = new Point(323, 40);
            inventoryGrid.Name = "inventoryGrid";
            inventoryGrid.ReadOnly = true;
            inventoryGrid.RowHeadersVisible = false;
            inventoryGrid.RowHeadersWidth = 62;
            inventoryGrid.Size = new Size(295, 238);
            inventoryGrid.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 413);
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
        private Label armor;
        private Button craftButton;
        private ToolStripMenuItem menusToolStripMenuItem;
        private ToolStripMenuItem craftToolStripMenuItem1;
        private Label level;
        private Label xp;
        private ToolStripMenuItem optionsToolStripMenuItem1;
    }
}