using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserItem.Interfaces;

namespace UserItem.Distances
{
    /// <summary>
    /// Computation of Euclidean similarity with as input of X and Y
    /// </summary>
    class Euclidean : IDistance
    {
        static double similarity;

        /// <summary>
        ///  Formula of Euclidean is executed
        /// </summary>
        /// <param name="X">X as User 1</param>
        /// <param name="Y">Y as User 2</param>
        /// <returns>Similarity in double</returns>
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
