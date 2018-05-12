using Accord.MachineLearning.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzingAlgorithms
{
    public class AprioryAlgorithm
    {
        public void GetSkillsSuggestion()
        {
            SortedSet<int>[] dataset =
            {
                // Each row represents a set of items that have been bought 
                // together. Each number is a SKU identifier for a product.
                new SortedSet<int> { 1, 2, 3, 4 }, // bought 4 items
                new SortedSet<int> { 1, 2, 4 },    // bought 3 items
                new SortedSet<int> { 1, 2 },       // bought 2 items
                new SortedSet<int> { 2, 3, 4 },    // ...
                new SortedSet<int> { 2, 3 },
                new SortedSet<int> { 3, 4 },
                new SortedSet<int> { 2, 4 },
            };

            // We will use Apriori to determine the frequent item sets of this database.
            // To do this, we will say that an item set is frequent if it appears in at 
            // least 3 transactions of the database: the value 3 is the support threshold.

            // Create a new a-priori learning algorithm with support 3
            Apriori apriori = new Apriori(threshold: 3, confidence: 0);

            // Use the algorithm to learn a set matcher
            AssociationRuleMatcher<int> classifier = apriori.Learn(dataset);

            // Use the classifier to find orders that are similar to 
            // orders where clients have bought items 1 and 2 together:
            int[][] matches = classifier.Decide(new[] { 1, 2 });

            // The result should be:
            // 
            //   new int[][]
            //   {
            //       new int[] { 4 },
            //       new int[] { 3 }
            //   };

        }
    }
}
