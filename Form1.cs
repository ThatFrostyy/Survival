/*  <A text based survival game.>
    Copyright (C) <2024> <ThatFrostyy>

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
namespace Survival
{
    public partial class Form1 : Form
    {
        // I don't know how any of this works, but it does
        public Character Player { get; } = new();
        public Game Game { get; }
        public CharacterMethods PlayerMethods { get; }

        public Form1()
        {
            InitializeComponent();
            UpdateStats();

            Game = new Game(Player, this);
            PlayerMethods = Game.PlayerMethods;
        }


        // GUI
        public void UpdateStats()
        {
            health.Text = "Health: " + Player.healthValue.ToString();
            hunger.Text = "Hunger: " + Player.hungerValue.ToString();
            thirst.Text = "Thirst: " + Player.thirstValue.ToString();
            currentWeight.Text = "Current Weight: " + Player.currentWeightValue.ToString();
            maxWeight.Text = "Max Weight: " + Player.maxWeightValue.ToString();
            locationL.Text = "Location: " + Player.location;
        }
        public void GameOver()
        {
            consoleBox.Clear();
            Output("Your journey comes to an end with a sudden death.");

            Player.healthValue = 100;
            Player.hungerValue = 100;
            Player.thirstValue = 100;
            Player.currentWeightValue = 0;
            Player.maxWeightValue = 30;
            Player.location = "Beach";
            Player.inventory.Clear();

            inventoryGrid.Rows.Clear();
            inventoryGrid.Columns.Clear();
        }


        // Console
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
            var command = inputBox.Text.ToLower();

            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.Message}");
            }
        }


        // Buttons
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
