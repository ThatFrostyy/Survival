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
namespace Survival
{
    public class Tools
    {
        Random rand = new();

        public T ChooseWeightedRandom<T>(List<T> list, List<int> weights)
        {
            if (list.Count != weights.Count)
            {
                throw new ArgumentException("The list and weights must be the same size.");
            }

            var totalWeight = weights.Sum();
            var choice = rand.Next(totalWeight);
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
    }
}