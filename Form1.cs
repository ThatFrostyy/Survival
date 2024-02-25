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
            Player.location = "Beach";
            Player.inventory.Clear();
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
