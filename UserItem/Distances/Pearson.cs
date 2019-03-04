using System;
using System.Collections.Generic;
using System.Text;

namespace UserItem.Distances
{
    class Pearson
    {
        public static double ComputePearson(double[,] User1Ratings, double[,] User2Ratings)
        {
            double distance = 0.0;

            double leftUpper = 0.0;
            double rightUpper = 0.0;
            double rightUpper1 = 0.0;
            double rightUpper2 = 0.0;
            double leftdown1 = 0.0;
            double leftdown2 = 0.0;
            double leftdown22 = 0.0;
            double rightdown1 = 0.0;
            double rightdown2 = 0.0;
            double rightdown22 = 0.0;
            int totalArticles = 0;
            double upper = 0.0;
            double down = 0.0;

            int rowLengthUser1 = User1Ratings.GetLength(0);
            int rowLengthUser2 = User2Ratings.GetLength(0);
            int colLength = User1Ratings.GetLength(1);
            for (int i = 0; i < rowLengthUser1; i++)
            {
                for (int j = 0; j < rowLengthUser2; j++)
                {
                    if (User1Ratings[i, 0] == User2Ratings[j, 0])
                    {
                        //leftUpper += (item1.Value * item2.Value);
                        leftUpper += (User1Ratings[i, 1] * User2Ratings[j, 1]);

                        rightUpper1 += User1Ratings[i, 1];
                        rightUpper2 += User2Ratings[j, 1];
                        leftdown1 += Math.Pow(User1Ratings[i, 1],2);
                        leftdown2 += User1Ratings[i, 1];

                        rightdown1 += Math.Pow(User2Ratings[j, 1], 2);
                        rightdown2 += User2Ratings[j, 1];
                        totalArticles++;
                    }
                }
            }
            leftdown22 = Math.Pow(leftdown2, 2);
            rightdown22 = Math.Pow(rightdown2, 2);
            rightUpper = rightUpper1 * rightUpper2;
            upper = leftUpper - (rightUpper / totalArticles);
            down = Math.Sqrt(leftdown1 - (leftdown22 / totalArticles)) * Math.Sqrt(rightdown1 - (rightdown22) / totalArticles); Console.WriteLine(down);
            distance = upper / down;

            return distance;
        }
    }
}
