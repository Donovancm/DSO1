using System;
using System.Collections.Generic;
using System.Text;

namespace UserItem.Interfaces
{
    interface IDistance
    {
        double ComputeDistance(double[,] X, double[,] Y);
    }
}
