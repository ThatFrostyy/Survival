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

using Items;
using System.Media;
using Settings;
namespace Survival
{
    public class Tools
    {
        private readonly Random _rand = new();
        private readonly Options _options;

        public Tools(Options options)
        {
            _options = options;
        }

        public T ChooseWeightedRandom<T>(List<T> list, List<int> weights)
        {
            if (list.Count != weights.Count)
            {
                throw new ArgumentException("The list and weights must be the same size.");
            }

            var totalWeight = weights.Sum();
            var choice = _rand.Next(totalWeight);
            for (var i = 0; i < list.Count; i++)
            {
                if (choice < weights[i])
                {
                    return list[i];
                }

                choice -= weights[i];
            }

            throw new InvalidOperationException("The weights must sum to a value greater than zero.");
        }

        #region Sound
        public void PlaySound(string location, Weapon weapon = null, bool shoot = false, bool equip = false)
        {
            if (!_options.audioBox.Checked)
            {
                return;
            }

            if (shoot && equip)
            {
                throw new ArgumentException("Parameters 'shoot' and 'equip' cannot both be true.");
            }

            var soundFile = location;
            if (weapon != null)
            {
                if (shoot)
                {
                    soundFile = $@"./Assets/Sounds/Items/Weapons/{weapon.Name}.wav";
                }
                else if (equip)
                {
                    soundFile = $@"./Assets/Sounds/Items/Weapons/{weapon.Name}Equip.wav";
                }
            }

            using (var soundPlayer = new SoundPlayer(soundFile))
            {
                soundPlayer.Play();
            }
        }
        #endregion Sound
    }
}