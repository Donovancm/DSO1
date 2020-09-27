using System;
using System.Collections.Generic;
using System.Text;

namespace UserItem.Data
{
    class ConvertToDictionary
    {
        public static Dictionary<int, List<Tuple<int, double>>> userData;

        public static Dictionary<int, List<Tuple<int, double>>> ConvertData(Dictionary<int, double[,]> dataSet)
        {
            userData = new Dictionary<int, List<Tuple<int, double>>>();
            foreach (var user in dataSet)
            {
                List<Tuple<int, double>> productRatings = new List<Tuple<int, double>>();
                double[,] arrayProductRatings = user.Value;
                int row = arrayProductRatings.GetLength(1);
                int column = arrayProductRatings.GetLength(0);
                int productId = 0;
                double rating = 0.0;
                for (int i = 0; i < row; i++)
                {
                    productId = (int)arrayProductRatings[i, 0];
                    for (int j = 0; j < column; j++)
                    {
                        rating = arrayProductRatings[i, 1];
                        productRatings.Add(new Tuple<int, double>(productId, rating));
                    }
                }
                userData.Add(user.Key, productRatings);
            }
            return userData;
        }
    }
}
