using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserItem.Data;
using UserItem.Interfaces;

namespace UserItem.Recommender
{
    class RecommendNearestNeighbour
    {
        public static Dictionary<int, double> neighbors;
        public static void Run(double threshhold, int targetUser, IDistance iDistance, Dictionary<int, double[,]> dataSet, int K)
        {
            neighbors = new Dictionary<int, double>();
            var userRatings = dataSet[targetUser];
            Dictionary<int, List<Tuple<int, double>>> convertedDataSet = ConvertToDictionary.ConvertData(dataSet);
            foreach (var userID in dataSet.Keys)
            {
                if (userID != targetUser)
                {
                    double similarity = iDistance.ComputeDistance(userRatings, dataSet[userID]);
                    if (similarity > threshhold)
                    {
                        if (hasMoreProductRated(targetUser, userID, convertedDataSet))
                        {
                            neighbors.Add(userID, similarity);
                        }
                    }
                }
            }

            var sorted = neighbors.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value).Take(K);
           // var sorted = from pair in neighbors
           //             orderby pair.Value descending
           //             select pair;

            foreach (var neighbor in sorted)
            {
                Console.WriteLine("Neighbor id:"+ neighbor.Key+", similarity "+neighbor.Value);
            }
        }

        private static bool hasMoreProductRated(int targetUser, int userRating, Dictionary<int, List<Tuple<int, double>>> convertedDataSet)
        {
            var targetUserRatings = convertedDataSet[targetUser];
            var userRatings = convertedDataSet[userRating];
            var targetUserRatedProducts = targetUserRatings.Select(x => x.Item1);
            foreach (var productID in targetUserRatedProducts)
            {
                if (userRatings.Any(x => x.Item1 != productID))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
