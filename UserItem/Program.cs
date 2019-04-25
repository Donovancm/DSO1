using System;
using System.Collections.Generic;
using System.IO;
using UserItem.Data;
using UserItem.Distances;
using UserItem.Interfaces;

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
            Console.WriteLine("Hello World!");

            PickAlgorithm();
            Console.ReadLine();
        }
        public static void PickAlgorithm()
        {
            IDistance iDistance = null;
            IReader iReader = null;
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
                    iReader = new FileReader();
                    dictionaryBasic = iReader.GetData();

                    break;
                case 2:
                    iReader = new DataReader();
                    dictionaryAdvanced = iReader.GetData();
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
                    PickTargetUsers();
                    Console.WriteLine("You have chosen Euclidian");
                    if (choiceData == 1)
                    {
                        iDistance = new Euclidean();
                        Console.WriteLine("The similarity is: " + iDistance.ComputeDistance(dictionaryBasic[targetUser], dictionaryBasic[secTargetUser]));
                    }
                    else
                    {
                        iDistance = new Euclidean();
                        Console.WriteLine("The similarity is: " + iDistance.ComputeDistance(dictionaryAdvanced[targetUser], dictionaryAdvanced[secTargetUser]));
                    }
                    break;
                case 2:

                    PickTargetUsers();
                    Console.WriteLine("You have chosen Pearson");
                    if (choiceData == 1)
                    {
                        iDistance = new Pearson();
                        //Console.WriteLine("The similarity is: " + Distances.Pearson.ComputePearson(dictionaryBasic[targetUser], dictionaryBasic[secTargetUser]));
                        Console.WriteLine("The similarity is: " + iDistance.ComputeDistance(dictionaryBasic[targetUser], dictionaryBasic[secTargetUser]));
                    }
                    else
                    {
                        //iDistance = new Pearson();
                        //Console.WriteLine("The similarity is: " + iDistance.ComputeDistance(dictionaryAdvanced[targetUser], dictionaryAdvanced[secTargetUser]));
                    }
                    break;
                case 3:
                    PickTargetUsers();
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
        public static void PickTargetUsers()
        {
            Console.WriteLine("Select Targeted User");
            targetUser = int.Parse(Console.ReadLine());
            Console.WriteLine("Select Second Targeted User");
            secTargetUser = int.Parse(Console.ReadLine());
        }
        
        //public static Dictionary<int, double[,]> getData(double[,] data)
        //{
        //    FileReader r = new FileReader();
        //    Dictionary<int, double[,]> dictionary = r.GetData(data);
        //    return dictionary;
        //}

    }
}
