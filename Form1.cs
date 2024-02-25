using Core;
using Player;

namespace Survival
{
    public partial class Form1 : Form
    {
        // Idk how any of this works but it does
        Character player = new Character();
        Game game;
        CharacterMethods playerMethods;

        public Form1()
        {
            InitializeComponent();
            UpdateStats();

            game = new Game(player, this);
            playerMethods = game.playerMethods;
        }


        // GUI
        public void UpdateStats()
        {
            health.Text = "Health: " + player.healthValue.ToString();
            hunger.Text = "Hunger: " + player.hungerValue.ToString();
            thirst.Text = "Thirst: " + player.thirstValue.ToString();
            currentWeight.Text = "Current Weight: " + player.currentWeightValue.ToString();
            maxWeight.Text = "Max Weight: " + player.maxWeightValue.ToString();
            locationL.Text = "Location: " + player.location;
        }
        public void GameOver()
        {
            consoleBox.Clear();
            Output("Your journey comes to an end with a sudden death.");

            player.healthValue = 100;
            player.hungerValue = 100;
            player.thirstValue = 100;
            player.location = "Beach";
            player.inventory.Clear();
        }


        // Console
        public void Output(string output)
        {
            consoleBox.AppendText(output + Environment.NewLine);
            inputBox.Clear();
        }


        // Input
        public void inputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string command = inputBox.Text.ToLower();

                try
                {
                    switch (player.location)
                    {
                        case "Beach":
                            game.BeachCommands(command);
                            break;
                        case "Forest":
                            game.ForestCommands(command);
                            break;
                        case "Plains":
                            game.PlainsCommands(command);
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
        }


        // Buttons
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
