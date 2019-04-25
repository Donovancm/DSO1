using System;
using System.Collections.Generic;
using System.Text;
using UserItem.Interfaces;

namespace UserItem.Distances
{
    class Pearson : IDistance
    {
        public double ComputeDistance(double[,] X, double[,] Y)
        {
            double distance = 0.0;

            double denominatorSumX = 0.0;
            double denominatorSumY = 0.0;

            double denominatorMultiplierXY = 0.0;
            double denominatorAvgXY = 0.0;


            double numaratorSumTotalPowerX = 0.0;
            double numaratorSumX = 0.0;
            double numaratorSumPowerX = 0.0;
            double numaratorSumTotalPowerY = 0.0;
            double numaratorSumY = 0.0;
            double numaratorSumPowerY = 0.0;
            int totalArticles = 0;
            double denominator = 0.0;
            double numarator = 0.0;

            int rowLengthUser1 = X.GetLength(0);
            int rowLengthUser2 = Y.GetLength(0);
            int colLength = X.GetLength(1);
            for (int i = 0; i < rowLengthUser1; i++)
            {
                for (int j = 0; j < rowLengthUser2; j++)
                {
                    if (X[i, 0] == Y[j, 0])
                    {
                        denominatorMultiplierXY += (X[i, 1] * Y[j, 1]);

                        denominatorSumX += X[i, 1];
                        denominatorSumY += Y[j, 1];
                        numaratorSumTotalPowerX += Math.Pow(X[i, 1], 2);
                        numaratorSumX += X[i, 1];

                        numaratorSumTotalPowerY += Math.Pow(Y[j, 1], 2);
                        numaratorSumY += Y[j, 1];
                        totalArticles++;
                    }
                }
            }
            numaratorSumPowerX = Math.Pow(numaratorSumX, 2);
            numaratorSumPowerY = Math.Pow(numaratorSumY, 2);
            denominatorAvgXY = denominatorSumX * denominatorSumY;
            denominator = denominatorMultiplierXY - (denominatorAvgXY / totalArticles);
            numarator = Math.Sqrt(numaratorSumTotalPowerX - (numaratorSumPowerX / totalArticles)) * Math.Sqrt(numaratorSumTotalPowerY - (numaratorSumPowerY) / totalArticles);
            distance = denominator / numarator;

            return distance;
        }
    }
}
