using System;
using System.Collections.Generic;
using System.IO;
using UserItem.Data;
using UserItem.Distances;

namespace UserItem
{
    class Program
    {
        public static int choice;
        public static int choiceData;
        public static int targetUser;
        public static int secTargetUser;
        static void Main(string[] args)
        {
            DataReader.GetData();
            Console.WriteLine("Hello World!");

            PickAlgorithm();
            //Console.WriteLine("Euclidean similarity of User 1 and 2");
            //Console.WriteLine("Answer: " + Cosine.CosineSimilarity(dictionary[1], dictionary[7] ));
            //Console.WriteLine("Answer: " + Cosine.CosineSimilarity(dictionary[7], dictionary[1]));
            //Console.WriteLine("NearestNeighbours" + Recommender.NearestNeighbour.ComputeRecommendations(7, dictionary, 3));
            //Console.WriteLine("NearestNeighbours" + Recommender.NearestNeighbour.ComputeRecommendations(7, DataReader.GetData(), 3));
            Console.ReadLine();
        }
        public static void PickAlgorithm()
        {
         
            Console.WriteLine("Pick 1 for Euclidean");
            Console.WriteLine("Pick 2 for Pearson");
            Console.WriteLine("Pick 3 for Cosine");
            Console.WriteLine("Pick 4 for Recommendation");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Pick 1 for Basic Dataset");
            Console.WriteLine("Pick 2 for Advanced Dataset");
            choiceData = int.Parse(Console.ReadLine());
            Dictionary<int, double[,]> dictionaryBasic= new Dictionary<int, double[,]>();
            Dictionary<int, double[,]> dictionaryAdvanced = new Dictionary<int, double[,]>();
            switch (choiceData)
            {
                case 1:
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
                    dictionaryBasic = FileReader.GetData(data);

                    break;
                case 2:
                    dictionaryAdvanced = DataReader.GetData();
                    break;
                default:
                    Console.WriteLine("Closed");
                    Console.ReadLine();
                    break;
            }

            //var user1 = SelectUser.selectUserCosine(dictionary);
            //var user2 = SelectUser.selectUserCosine(dictionary);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Select Targeted User");
                    targetUser = int.Parse(Console.ReadLine());
                    Console.WriteLine("Select Second Targeted User");
                    secTargetUser = int.Parse(Console.ReadLine());
                    Console.WriteLine("You have chosen Euclidian");
                    if (choiceData == 1)
                    {
                        Console.WriteLine("The similarity is: " + Euclidean.ComputeEuclidean(dictionaryBasic[targetUser], dictionaryBasic[secTargetUser]));
                    }
                    else
                    {
                        Console.WriteLine("The similarity is: " + Euclidean.ComputeEuclidean(dictionaryAdvanced[targetUser], dictionaryAdvanced[secTargetUser]));
                    }
                    break;
                case 2:
                   
                    Console.WriteLine("Select Targeted User");
                    targetUser = int.Parse(Console.ReadLine());
                    Console.WriteLine("Select Second Targeted User");
                    secTargetUser = int.Parse(Console.ReadLine());
                    Console.WriteLine("You have chosen Pearson");
                    if (choiceData == 1)
                    {
                        Console.WriteLine("The similarity is: " + Pearson.ComputePearson(dictionaryBasic[targetUser], dictionaryBasic[secTargetUser]));
                    }
                    else
                    {
                        Console.WriteLine("The similarity is: " + Pearson.ComputePearson(dictionaryAdvanced[targetUser], dictionaryAdvanced[secTargetUser]));
                    }
                    break;
                case 3:
                    Console.WriteLine("Select Targeted User");
                    targetUser = int.Parse(Console.ReadLine());
                    Console.WriteLine("Select Second Targeted User");
                    secTargetUser = int.Parse(Console.ReadLine());
                    Console.WriteLine("You have chosen Cosine");
                    if (choiceData == 1)
                    {
                        Console.WriteLine("The similarity is: " + Cosine.CosineSimilarity(dictionaryBasic[targetUser], dictionaryBasic[secTargetUser]));
                    }
                    else
                    {
                        Console.WriteLine("The similarity is: " + Cosine.CosineSimilarity(dictionaryAdvanced[targetUser], dictionaryAdvanced[secTargetUser]));
                    }
                    break;
                case 4:
                    Console.WriteLine("Select Targeted User");
                    targetUser = int.Parse(Console.ReadLine());
                    Console.WriteLine("You have chosen Recommendation");
                    Console.WriteLine("Select Top numbers of ranking");
                    int k = int.Parse(Console.ReadLine());

                    if (choiceData == 1)
                    {
                        Recommender.NearestNeighbour.ComputeRecommendations(targetUser, dictionaryBasic, k);
                    }
                    else
                    {
                       Recommender.NearestNeighbour.ComputeRecommendations(targetUser, dictionaryAdvanced,k);
                    }
                    break;
                default:
                    Console.WriteLine("Closed");
                    Console.ReadLine();
                    break;
            }
        }
        //public static Dictionary<int, double[,]> getData(double[,] data)
        //{
        //    FileReader r = new FileReader();
        //    Dictionary<int, double[,]> dictionary = r.GetData(data);
        //    return dictionary;
        //}

    }
}
