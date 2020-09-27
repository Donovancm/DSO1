using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UserItem.Data;
using UserItem.Distances;
using UserItem.Interfaces;
using UserItem.Recommender;

namespace UserItem
{
    class Program
    {
        public static int choice;
        public static int choiceData;
        public static int targetUser;
        static void Main(string[] args)
        {
            Console.WriteLine("UserItem");
            PickAlgorithm();
            Console.ReadLine();
        }
        /// <summary>
        /// User gets number of choices to compute similaries and recommendations
        /// </summary>
        public static void PickAlgorithm()
        {
            IDistance iDistance = null;
            IReader iReader = null;
            Console.WriteLine("Pick 1 for Euclidean");
            Console.WriteLine("Pick 2 for Pearson");
            Console.WriteLine("Pick 3 for Cosine");
            Console.WriteLine("Pick 4 for Recommendation");
            Console.WriteLine("Pick 5 for NearestNeighbor");
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

            switch (choice)
            {
                case 1:
                    PickTargetUsers();
                    Console.WriteLine("You have chosen Euclidian");
                    if (choiceData == 1)
                    {
                        iDistance = new Euclidean();
                        IterateSimilarity(dictionaryBasic, targetUser, iDistance);
                    }
                    else
                    {
                        iDistance = new Euclidean();
                        IterateSimilarity(dictionaryAdvanced, targetUser, iDistance);
                    }
                    break;
                case 2:

                    PickTargetUsers();
                    Console.WriteLine("You have chosen Pearson");
                    if (choiceData == 1)
                    {
                        iDistance = new Pearson();
                        IterateSimilarity(dictionaryBasic, targetUser, iDistance);
                    }
                    else
                    {
                        iDistance = new Pearson();
                        IterateSimilarity(dictionaryAdvanced, targetUser, iDistance);
                    }
                    break;
                case 3:
                    PickTargetUsers();
                    Console.WriteLine("You have chosen Cosine");
                    if (choiceData == 1)
                    {
                        iDistance = new Cosine();
                        IterateSimilarity(dictionaryBasic, targetUser, iDistance);
                    }
                    else
                    {
                        iDistance = new Cosine();
                        IterateSimilarity(dictionaryAdvanced, targetUser, iDistance);
                    }
                    break;
                case 4:
                    Console.WriteLine("Select Targeted User");
                    targetUser = int.Parse(Console.ReadLine());
                    Console.WriteLine("You have chosen Recommendation");
                    Console.WriteLine("Select Top numbers of ranking");
                    int k = int.Parse(Console.ReadLine());
                    Console.WriteLine("Set up your threshold");
                    double threshold = double.Parse(Console.ReadLine());


                    if (choiceData == 1)
                    {
                        Recommender.NearestNeighbour.ComputeRecommendations(targetUser, dictionaryBasic, k, threshold);
                    }
                    else
                    {
                       Recommender.NearestNeighbour.ComputeRecommendations(targetUser, dictionaryAdvanced,k, threshold);
                    }
                    break;
                case 5:
                    Console.WriteLine("Select Targeted User");
                    targetUser = int.Parse(Console.ReadLine());
                    Console.WriteLine("You have chosen NearestNeighbor");
                    Console.WriteLine("Select K");
                    k = int.Parse(Console.ReadLine());
                    Console.WriteLine("Set up your threshold");
                    threshold = double.Parse(Console.ReadLine());
         
                    iDistance = new Pearson();
                    
                    if (choiceData == 1)
                    {
                        RecommendNearestNeighbour.Run(threshold,targetUser,iDistance, dictionaryBasic, k);
                    }
                    else
                    {
                        Console.WriteLine("How many users");
                        int amount = int.Parse(Console.ReadLine());
                        RecommendNearestNeighbour.Run(threshold, targetUser, iDistance, dictionaryAdvanced.OrderBy(x => x.Key).Take(amount).ToDictionary(pair => pair.Key, pair => pair.Value), k);
                    }
                    break;
                default:
                    Console.WriteLine("Closed");
                    Console.ReadLine();
                    break;
            }
        }
        /// <summary>
        /// Type and read user input
        /// </summary>
        public static void PickTargetUsers()
        {
            Console.WriteLine("Select Targeted User");
            targetUser = int.Parse(Console.ReadLine());
        }
        
        public static void IterateSimilarity(Dictionary<int, double[,]> dataSet, int targetUser, IDistance iDistance)
        {
            var userRatings = dataSet[targetUser];
            foreach (var userID in dataSet.Keys)
            {
                if (userID != targetUser)
                {
                    Console.WriteLine("UserId:" + userID + ", The similarity is: " + iDistance.ComputeDistance(userRatings, dataSet[userID]));

                }
            }
        }

    }
}
