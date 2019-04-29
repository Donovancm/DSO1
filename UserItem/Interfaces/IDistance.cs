using System;
using System.Collections.Generic;
using System.Text;

namespace UserItem.Interfaces
{
    /// <summary>
    /// Interface for Computing distances, interface method is being used for Euclidean and Pearson
    /// </summary>
    interface IDistance
    {
        double ComputeDistance(double[,] X, double[,] Y);
    }
}
