using System;
using System.Collections.Generic;

namespace UserItem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var data = new[,] { { 1, 101, 2.5 },
                                { 1, 102, 3.5 },
                                { 3,104,3.5 }};
            var dictionary = new Dictionary<double, double[,]>();
            int rowLength = data.GetLength(0);
            int colLenght = data.GetLength(1);
            bool checkeNewRow = false;

            for (int i = 0; i < rowLength; i++)
            {
                double key = -1;
                double productvalue = -1;
                double userRating = -1;
                checkeNewRow = false;


                for (int j = 0; j < colLenght; j++)
                {
                    Console.WriteLine(data[i,j]);
                    if(!checkeNewRow)
                    {
                        key = data[i, j];
                        checkeNewRow = true;

                    }

                    else if(j == 1 ){
                        productvalue = data[i, j];
                    }
                    else if (j == 2)
                    {
                        userRating = data[i, j];
                        var userdata = new double[,] { { productvalue },{ userRating } };
                        if (dictionary.ContainsKey(key))
                        {
                            var data2 = new double[,] { };
                            data2 = dictionary[key];
                            int rowLengthdata2 = data2.GetLength(0);
                            if(rowLengthdata2 == 0)
                            {
                                rowLengthdata2 = 1;
                            }
                            int colLenghtdata2 = data2.GetLength(1);
                            var data3 = new double[rowLengthdata2 + 2, colLenghtdata2];
                            data3 = data2;
                            data3[rowLengthdata2 + 1, 0] = productvalue;
                            data3[rowLengthdata2 + 2, 1] = userRating;
                            dictionary[key] = data3;

                        }
                        else { dictionary.Add(key, userdata); }
                      
                    }
                    
                }
            }
            Console.ReadLine();
        }
    }
}
