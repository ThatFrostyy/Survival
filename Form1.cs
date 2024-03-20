/*  <A text based survival game.>
    Copyright (C) <2024> <Frostyy>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>. */
using Settings;
namespace Survival
{
    public partial class Form1 : Form
    {
        private readonly Options _options;
        private readonly Tools _tools;
        private readonly Database _database;
        private readonly Character _character;
        private readonly Shop _shop;
        private readonly Game _game;

        public Form1()
        {
            InitializeComponent();

            _options = new Options();
            _tools = new Tools();
            _database = new Database();
            _character = new Character(this, _database, _tools);
            _shop = new Shop(this, _character, _database);
            _game = new Game(this, _character, _database, _shop, _tools, _options);

            _character.OnPlayerCreate();
            _shop.OnShopCreate();

            UpdateStats();
        }

        #region GUI
        /// <summary>
        /// Update the stats GUI
        /// </summary>
        public void UpdateStats()
        {
            level.Text = "Level: " + _character.levelValue.ToString();
            xp.Text = "XP: " + _character.xpValue.ToString();

            health.Text = "Health: " + _character.healthValue.ToString();
            hunger.Text = "Hunger: " + _character.hungerValue.ToString();
            thirst.Text = "Thirst: " + _character.thirstValue.ToString();
            armor.Text = "Armor: " + _character.armorValue.ToString();
            currentWeight.Text = "Current Weight: " + _character.currentWeightValue.ToString();
            maxWeight.Text = "Max Weight: " + _character.maxWeightValue.ToString();

            locationL.Text = "Location: " + _character.location;
        }

        /// <summary>
        /// Output something to the console
        /// </summary>
        public void Output(string output)
        {
            consoleBox.AppendText(output + Environment.NewLine);
            inputBox.Clear();
        }
        #endregion

        #region Game
        /// <summary>
        /// Resets the game
        /// </summary>
        public void GameOver()
        {
            consoleBox.Clear();
            Output("Your journey comes to an end with a sudden death.");

            _character.levelValue = 1;
            _character.xpValue = 0;
            _character.strengthValue = 15;

            _character.healthValue = 100;
            _character.hungerValue = 100;
            _character.thirstValue = 100;
            _character.armorValue = 0;
            _character.currentWeightValue = 0;
            _character.maxWeightValue = 30;

            _character.location = "Beach";
            _character.inCombat = false;
            _character.inShop = false;

            _character.equippedItem = Guid.Empty;

            _character.inventory.Clear();
            inventoryGrid.Rows.Clear();
            inventoryGrid.Columns.Clear();
            _character.OnPlayerCreate();
            _shop.OnShopCreate();
        }

        public void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            e.SuppressKeyPress = true;

            var input = inputBox.Text.ToLower();
            var command = ParseCommand(input);

            try
            {
                if (_character.inShop)
                {
                    _game.ShopCommands(command);
                }
                else if (!_character.inCombat)
                {
                    switch (_character.location)
                    {
                        case "Beach":
                            _game.BeachCommands(command);
                            break;
                        case "Forest":
                            _game.ForestCommands(command);
                            break;
                        case "Plains":
                            _game.PlainsCommands(command);
                            break;
                        case "Hills":
                            _game.HillsCommands(command);
                            break;
                        case "Mountains":
                            _game.MountainsCommands(command);
                            break;
                        case "Village":
                            _game.VillageCommands(command);
                            break;
                        default:
                            MessageBox.Show("There was an error while executing the command.");
                            break;
                    }
                }
                else
                {
                    _game.CombatCommands(command);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        #endregion

        #region Buttons
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void craftButton_Click(object sender, EventArgs e)
        {
            var form2 = new CraftForm();
            form2.Show();
        }

        private void craftToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form2 = new CraftForm();
            form2.Show();
        }

        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _options.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        #endregion Buttons

        /// <summary>
        /// Parse the input
        /// </summary>
        public Command ParseCommand(string input)
        {
            var commandParts = input.Split(' ');
            var action = commandParts[0];
            var argument = commandParts.Length > 1 ? string.Join(" ", commandParts.Skip(1)) : null;

            return new Command
            {
                Action = action,
                Argument = argument
            };
        }
    }

    public class Command
    {
        public string? Action { get; set; }
        public string? Argument { get; set; }
    }
}
