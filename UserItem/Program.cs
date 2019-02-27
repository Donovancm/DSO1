using System;
using System.Collections.Generic;

namespace UserItem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var data = new[,] { {1,101,2.5},{1,102,3.5},{1,105,2.5},{3,104,3.5},{2,102,3.5},{1,106,3.0},{2,101,3.0},
{5,103,2.0},
{2,103,1.5},
{2,104,5.0},
{6,105,3.5},
{2,106,3.0},
{3,101,2.5},
{6,104,5.0},
{3,102,3.0},
{5,106,3.0},
{3,106,4.0},
{4,102,3.5},
{6,106,3.0},
{4,104,4.0},
{7,104,4.0},
{4,105,2.5},
{1,104,3.5},
{1,103,3.0},
{2,105,3.5},
{4,106,4.5},
{5,101,3.0},
{5,102,4.0},
{6,102,4.0},
{5,104,3.0},
{4,103,3.0},
{5,105,2.0},
{6,101,3.0},
{7,102,4.5},
{7,105,1.0}};
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
                        var userdata = new double[,]
                        {
                            {productvalue,userRating}
                        };
                        //Console.Write(userdata[0,0]+" , "+userdata[0,1]);
                        if (dictionary.ContainsKey(key))
                        {
                            var data2 = new double[,] { };
                            data2 = dictionary[key];
                            int rowLengthdata2 = data2.GetLength(0)-1;
                            //if(rowLengthdata2 == 0)
                            //{
                            //    rowLengthdata2 = 1;
                            //}
                            int colLenghtdata2 = 2;
                            int rowLengthdata3 = rowLengthdata2 + 1;
                            int newRow2Ddata3 = data2.GetLength(0) + 1;

                             var data3 = new double[newRow2Ddata3, colLenghtdata2];
                            //var data3 = new double[2, 2];

                            for (int r = 0; r <= rowLengthdata2; r++)
                            {
                                for (int c = 0; c < colLenghtdata2; c++)
                                {
                                    data3[r,c]= data2[r, c];
                                }

                            }
                            //data3 = data2;
                            data3[rowLengthdata3, 0] = productvalue;
                            data3[rowLengthdata3, 1] = userRating;
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
