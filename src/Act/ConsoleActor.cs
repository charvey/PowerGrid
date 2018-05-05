using System;
using System.Collections.Generic;
using System.Linq;
using PowerGrid.Domain;
using PowerGrid.Domain.Actions;

namespace PowerGrid.Act
{
    public class ConsoleActor : IActor
    {
        public void Perform(IEnumerable<GameAction> actions)
        {
            Console.Clear();

            var informations = actions.OfType<InformUser>();
            Console.WriteLine("Here's some information:");
            foreach (var information in informations)
                Console.Out.WriteLine(information.Information);

            var recommendations = actions.OfType<MakeRecommendationGameAction>();
            Console.WriteLine("Here's some recommendations:");
            foreach (var recommendation in recommendations)
                Console.Out.WriteLine(recommendation.Recommendation);
        }
    }
}