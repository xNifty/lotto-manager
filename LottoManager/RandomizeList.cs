/*
 * RandomizeList.cs
 * @author xNifty
 * 
 * Generate a winner from the list, rolling a set number of times
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace LottoManager {
    public static class RandomizeList {
        public static Tuple<string, List<string>> SelectWinner(int rolls, List<string> randomList) {
            string winner = null;
            List<String> winnerList = new List<string>();

            if (randomList.Any()) {
                for (int i = 0; i < rolls; i++) {
                    int r = RandomNumber.Between(0, randomList.Count - 1);
                    winnerList.Add(randomList[r]);

                    // Because we start rolling at i = 0, because computer science!
                    // I'm not breaking logic of starting the count at 0. Deal with it.
                    if (i == rolls - 1) {
                        winner = randomList[r];
                    }
                }
            }
            
            Tuple<string, List<string>> returnValues = new Tuple<string, List<string>>(winner, winnerList);
            
            //return tuple with the winner and the history list;
            return returnValues;
        }
    }
}
