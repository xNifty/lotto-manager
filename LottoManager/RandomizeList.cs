/*
 * RandomizeList.cs
 * @author TD
 * 
 * Generate a winner from the list, rolling a set number of times
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoManager {
    public static class RandomizeList {
        public static Tuple<string, List<string>> selectWinner(int rolls, List<string> randomList) {
            string winner = null;
            List<String> winnerList = new List<string>();

            Console.WriteLine("Rolls: {0}", rolls);

            if (randomList.Any()) {
                Console.WriteLine("Size: {0}", randomList.Count);

                for (int i = 0; i < rolls; i++) {
                    int r = FDL.Library.Numeric.RandomNumber.Between(0, randomList.Count - 1);

                    Console.WriteLine("Index {0}: {1}", r, randomList[r]);
                    winnerList.Add(randomList[r]);

                    // Because we start rolling at i = 0, because computer science!
                    // I'm not breaking logic of starting the count at 0. Deal with it.
                    if (i == rolls - 1) {
                        winner = randomList[r];
                    }
                }
            }
            Tuple<string, List<string>> returnValues = new Tuple<string, List<string>>(winner, winnerList);
            Console.WriteLine("Winner: {0}", winner);
            //return tuple with the winner and the history list;
            return returnValues;
        }
    }
}
