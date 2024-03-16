using Items;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Utilities
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