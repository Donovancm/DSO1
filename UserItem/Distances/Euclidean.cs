using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserItem.Interfaces;

namespace UserItem.Distances
{
    class Euclidean : IDistance
    {
        static double similarity;

        public double ComputeDistance(double[,] X, double[,] Y)
        {
            double distance = 0.0;
            int row2DArrayX = X.GetLength(0);
            int row2DArrayY = Y.GetLength(0);
            for (int i = 0; i < row2DArrayX; i++)
            {
                for (int j = 0; j < row2DArrayY; j++)
                {
                    if (X[i, 0] == Y[j, 0]) { distance += Math.Pow((X[i, 1] - Y[j, 1]), 2); }
                }
            }
            similarity = 1 / (1 + Math.Sqrt(distance));
            return similarity;
        }
    }
}
