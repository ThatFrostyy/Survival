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

using Core;
using Player;
using Shop;
namespace Survival
{
    public partial class Form1 : Form
    {
        // I don't know how any of this works, but it does
        public Character Player { get; set; } = new();
        public CharacterMethods PlayerMethods { get; }
        public ShopCore Shop { get; } = new();
        public ShopMethods ShopMethods { get; }
        public Game Game { get; }

        public Form1()
        {
            InitializeComponent();
            UpdateStats();

            Game = new Game(Shop, Player, this);
            PlayerMethods = Game.PlayerMethods;
            ShopMethods = Game.ShopMethods;

            PlayerMethods.OnPlayerCreate();
            ShopMethods.OnShopCreate();
        }


        /// <summary>
        /// Update the stats GUI
        /// </summary>
        public void UpdateStats()
        {
            health.Text = "Health: " + Player.healthValue.ToString();
            hunger.Text = "Hunger: " + Player.hungerValue.ToString();
            thirst.Text = "Thirst: " + Player.thirstValue.ToString();
            armor.Text = "Armor: " + Player.armorValue.ToString();
            currentWeight.Text = "Current Weight: " + Player.currentWeightValue.ToString();
            maxWeight.Text = "Max Weight: " + Player.maxWeightValue.ToString();
            locationL.Text = "Location: " + Player.location;
        }
        /// <summary>
        /// Resets the game
        /// </summary>
        public void GameOver()
        {
            consoleBox.Clear();
            Output("Your journey comes to an end with a sudden death.");

            Player.strengthValue = 15;
            Player.healthValue = 100;
            Player.hungerValue = 100;
            Player.thirstValue = 100;
            Player.armorValue = 0;
            Player.currentWeightValue = 0;
            Player.maxWeightValue = 30;
            Player.location = "Beach";
            Player.inCombat = false;
            Player.equippedItem = Guid.Empty;
            Player.inventory.Clear();

            inventoryGrid.Rows.Clear();
            inventoryGrid.Columns.Clear();
        }


        /// <summary>
        /// Output something to the console
        /// </summary>
        public void Output(string output)
        {
            consoleBox.AppendText(output + Environment.NewLine);
            inputBox.Clear();
        }


        // Input
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
                if (Player.inShop)
                {
                    Game.ShopCommands(command);
                }
                else if (!Player.inCombat)
                {
                    switch (Player.location)
                    {
                        case "Beach":
                            Game.BeachCommands(command);
                            break;
                        case "Forest":
                            Game.ForestCommands(command);
                            break;
                        case "Plains":
                            Game.PlainsCommands(command);
                            break;
                        case "Hills":
                            Game.HillsCommands(command);
                            break;
                        case "Mountains":
                            Game.MountainsCommands(command);
                            break;
                        case "Village":
                            Game.VillageCommands(command);
                            break;
                        default:
                            Output("Error");
                            break;
                    }
                }
                else
                {
                    Game.CombatCommands(command);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
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

        // Buttons
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void craftButton_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }

        private void craftToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }

    public class Command
    {
        public string? Action { get; set; }
        public string? Argument { get; set; }
    }
}
