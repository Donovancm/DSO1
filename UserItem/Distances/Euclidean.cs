using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserItem.Distances
{
    class Euclidean
    {
        static double similarity;
        public static double ComputeEuclidean(double[,] User1Ratings, double[,] User2Ratings)
        {
            double distance = 0.0;
            Console.WriteLine(distance);
            //foreach (var user1 in User)
            //{
            //    foreach (var user2 in User2.Where(x => x.Key == user1.Key))
            //    {
            //        distance += Math.Pow((user1.Value - user2.Value), 2);
            //    }
            //    similarity = 1 / (1 + Math.Sqrt(distance));
            //    //return similarity;
            //}
            int rowLengthUser1 = User1Ratings.GetLength(0);
            int rowLengthUser2 = User2Ratings.GetLength(0);
            int colLength = User1Ratings.GetLength(1);
            for (int i = 0; i < rowLengthUser1; i++)
            {
                for (int j = 0; j < rowLengthUser2; j++)
                {
                    if (User1Ratings[i, 0] == User2Ratings[j, 0]) { distance += Math.Pow((User1Ratings[i, 1] - User2Ratings[j, 1]), 2); }
                }
            }
            similarity = 1 / (1 + Math.Sqrt(distance));
            return similarity;
        }
    }
}
