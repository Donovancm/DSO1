using System;
using System.Collections.Generic;
using UserItem.Data;
using UserItem.Distances;

namespace UserItem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var data = new[,] {
                {1,101,2.5},
                { 1,102,3.5},
                { 1,103,3.0},
                { 1,104,3.5},
                { 1,105,2.5},
                { 1,106,3.0},
                { 2,101,3.0},
                { 2,102,3.5},
                { 2,103,1.5},
                { 2,104,5.0},
                { 2,105,3.5},
                { 2,106,3.0},
                { 3,101,2.5},
                { 3,102,3.0},
                { 3,104,3.5},
                { 3,106,4.0},
                { 4,102,3.5},
                { 4,103,3.0},
                { 4,104,4.0},
                { 4,105,2.5},
                { 4,106,4.5},
                { 5,101,3.0},
                { 5,102,4.0},
                { 5,103,2.0},
                { 5,104,3.0},
                { 5,105,2.0},
                { 5,106,3.0},
                { 6,101,3.0},
                { 6,102,4.0},
                { 6,104,5.0},
                { 6,105,3.5},
                { 6,106,3.0},
                { 7,102,4.5},
                { 7,104,4.0},
                { 7,105,1.0}
        };
        Dictionary<int, double[,]> dictionary = getData(data);
            //Console.WriteLine("Euclidean similarity of User 1 and 2");
            //Console.WriteLine("Answer: " + Cosine.CosineSimilarity(dictionary[1], dictionary[7] ));
            //Console.WriteLine("Answer: " + Cosine.CosineSimilarity(dictionary[7], dictionary[1]));
            Console.WriteLine("NearestNeighbours" + Recommender.NearestNeighbour.ComputeRecommendations(7, dictionary,3));
            
            
            //var clara = new double[,] {
            //    {1,4.75 },
            //    {2,4.5 },
            //    {3,5 },
            //    {4,4.25 },
            //    {5,4 }

            //};
            //var robert = new double[,] {
            //    {1,4 },
            //    {2,3 },
            //    {3,5 },
            //    {4,2 },
            //    {5,1 }

            //};
            //Console.WriteLine("Answer: " + Cosine.CosineSimilarity(, diction);
            Console.ReadLine();
        }
        public static Dictionary<int, double[,]> getData(double[,] data)
        {
            FileReader r = new FileReader();
            Dictionary<int, double[,]> dictionary = r.GetData(data);
            return dictionary;
        }

    }
}
