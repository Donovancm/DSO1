using System;
using System.Collections.Generic;
using System.Text;

namespace UserItem.Interfaces
{
    interface IReader
    {
        Dictionary<int, double[,]> GetData();
    }
}
