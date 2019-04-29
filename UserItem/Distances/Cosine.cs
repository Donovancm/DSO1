using System;
using System.Collections.Generic;
using System.Text;

namespace UserItem.Distances
{
    /// <summary>
    /// No extra points are given :'(
    /// </summary>
    class Cosine
    {
        public static double CosineSimilarity(double[,] user1Rating, double[,] user2Rating)
        {
            double part1 = 0.0;
            double part2 = 0.0;
            double part3 = 0.0;

            double[,] User1Ratings = user1Rating;
            double[,] User2Ratings = user2Rating;


            int rowLengthUser1 = User1Ratings.GetLength(0);
            int rowLengthUser2 = User2Ratings.GetLength(0);
            int colLength = User1Ratings.GetLength(1);

            //Checks for product in User1
            for (int i = 0; i < rowLengthUser1-1; i++)
            {
                int rowwLengthUser2 = User2Ratings.GetLength(0);
                for (int j = 0; j <= rowwLengthUser2-1; j++)
                {
                    if (User1Ratings[i, 0].Equals(User2Ratings[j, 0]))
                    {
                        break;
                    }
                    else if (i>= rowLengthUser2 || !User1Ratings[i, 0].Equals( User2Ratings[j, 0]))
                    {
                        if ( j == rowLengthUser2-1)
                        {
                            int newRowLengthUser2 = User2Ratings.GetLength(0);
                            int newRow2Ddata3 = newRowLengthUser2 + 1;
                            var data3 = new double[newRow2Ddata3, 2];

                            for (int r = 0; r < newRowLengthUser2; r++)
                            {
                                for (int c = 0; c < 2; c++)
                                {
                                    data3[r, c] = User2Ratings[r, c];
                                }

                            }
                            data3[newRow2Ddata3 - 1, 0] = User1Ratings[i, 0];
                            data3[newRow2Ddata3 - 1, 1] = 0;
                            User2Ratings = null;
                            User2Ratings = data3;
                        }
                        
                    }
                }
            }


            //Checks for product in User2
            for (int i = 0; i <= rowLengthUser2-1; i++)
            {
                int rowwLengthUser1 = User1Ratings.GetLength(0);
                for (int j = 0; j <= rowwLengthUser1-1; j++)
                {
                    if(User2Ratings[i, 0].Equals(User1Ratings[j, 0]))
                    {
                        break;
                    }
                    else if (i >= rowLengthUser1 || !User2Ratings[i, 0].Equals(User1Ratings[j, 0]))
                    {
                        if (j == (rowLengthUser1-1))
                        {
                            //int rowLengthdata3 = (rowLengthUser1-1) + 1;
                            int newRowLengthUser1 = User1Ratings.GetLength(0);
                            int newRow2Ddata3 = newRowLengthUser1 + 1;
                            var data3 = new double[newRow2Ddata3,2];

                            for (int r = 0; r < newRowLengthUser1; r++)
                            {
                                for (int c = 0; c < 2; c++)
                                {
                                    data3[r, c] = User1Ratings[r, c];
                                }

                            }
                            data3[newRow2Ddata3-1, 0] = User2Ratings[i, 0];
                            data3[newRow2Ddata3-1, 1] = 0.0;
                            User1Ratings = null;
                            User1Ratings = data3;
                        }
                       
                    }
                }
            }

            int newRowwLengthUser1 = User1Ratings.GetLength(0);
            int newRowwLengthUser2 = User2Ratings.GetLength(0);
            for (int i = 0; i < newRowwLengthUser1-1; i++)
            {
                part2 += Math.Pow(User1Ratings[i, 1], 2);
                part3 += Math.Pow(User2Ratings[i, 1], 2);

            }

            for (int i = 0; i < newRowwLengthUser1 - 1; i++)
            {
                for (int j = 0; j < newRowwLengthUser1 - 1; j++)
                {
                    if (User1Ratings[i, 0].Equals(User2Ratings[j, 0]))
                    {
                        part1 += User1Ratings[i, 1] * User2Ratings[j, 1];
                    }
                    
                }
            }

            var result = part1 / (Math.Sqrt(part2) * Math.Sqrt(part3));
            return result;
        }
    }
}
