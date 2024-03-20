using Newtonsoft.Json;
namespace Settings
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();

            if (!File.Exists("Data/settings.json"))
            {
            }
            else
            {
                var json = File.ReadAllText("Data/settings.json");
                var settings = JsonConvert.DeserializeObject<dynamic>(json);

                if (settings == null)
                {
                    return;
                }

                autoHeal.Checked = settings.AutoHeal;
                healPoint.Text = settings.HealPoint;
                audioBox.Checked = settings.Audio;
            }

            toolTip.SetToolTip(this.autoHeal, "Enable or disable auto heal during combat");
            toolTip.SetToolTip(this.healPoint, "Triggers healing after your health drops bellow this value");
            toolTip.SetToolTip(this.audioBox, "Whether audio will be enabled");

            save.Enabled = false;
        }

        #region Buttons
        private void autoHeal_CheckedChanged(object sender, EventArgs e)
        {
            healPoint.Visible = autoHeal.Checked;
            SettingChanged();
        }

        private void audioBox_CheckedChanged(object sender, EventArgs e)
        {
            SettingChanged();
        }

        private void healPoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            SettingChanged();
        }

        private void save_Click(object sender, EventArgs e)
        {
            var settings = new
            {
                AutoHeal = autoHeal.Checked,
                HealPoint = healPoint.Text,
                Audio = audioBox.Checked
            };

            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }

            var json = JsonConvert.SerializeObject(settings);
            File.WriteAllText("Data/settings.json", json);

            save.Enabled = false;
        }
        #endregion Buttons

        #region Options Methods
        private void SettingChanged()
        {
            save.Enabled = true;
        }
        #endregion Options Methods

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
