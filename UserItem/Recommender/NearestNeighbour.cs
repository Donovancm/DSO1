using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UserItem.Distances;
using UserItem.Interfaces;

namespace UserItem.Recommender
{
    class UserNearestNeighbour
    {
        public int user_id;
        public double distance;
    }


    class NearestNeighbour
    {
        public static double[,] ComputeNearestNeighbour(int UserID,  Dictionary<int, double[,]> users )
        {
            IDistance iDistance = null;
            iDistance = new Pearson();
            int row = users.Count-1;
            var distances_neighbours = new double[row, 2 ];
            var list_users = users;
            foreach (var item in list_users)
            {
                if (!item.Key.Equals(UserID))
                {
                    var user_id = item.Key;
                    var distance = iDistance.ComputeDistance(users[UserID], users[item.Key]);
                    for (int i = 0; i <= row-1; i++)
                    {
                        if (distances_neighbours[i,0]==0)
                        {
                                distances_neighbours[i, 0] = user_id;
                                distances_neighbours[i, 1] = distance;
                                break;
                        }

                    }

                }

            }
            // forloop voor sorteren
            distances_neighbours = InsertionSort(distances_neighbours);
            return distances_neighbours;
        }

        public static double[,] InsertionSort(double[,] datas)
        {
            var data = datas;
            var number = data.GetLength(0);
            var array = new double[number];
            var newArray = new double[number, 2];
            for (int i = 0; i <= data.GetLength(0) - 1; i++)
            {
                array[i] = data[i,1];
            }
            Array.Sort(array);
            Array.Reverse(array);
            for (int a = 0; a <= data.GetLength(0) - 1; a++)
            {
                for (int b = 0; b <= data.GetLength(0) - 1; b++)
                {
                    if (array[a] == data[b,1])
                    {
                        newArray[a, 0] = data[b, 0];
                        newArray[a, 1] = data[b, 1];
                    }
                }
            }
            return newArray;
        }

        public static void ComputeRecommendations(int UserID, Dictionary<int, double[,]> users, int k)
        {
            var nearest = ComputeNearestNeighbour(UserID, users);
            var recommendations = new double[k, 2];
            var userRatings = users[UserID];
            double total_distance = 0.0;
            var recommendationRanking = new Dictionary<double, double[,]>();
            for (int i = 0; i < k-1; i++)
            {
                total_distance += nearest[i,1];

            }
            for (int i = 0; i <= k-1; i++)
            {
                var weight = nearest[i, 1] / total_distance;
                double user_id = nearest[i, 0];
                var neighborRatings = users[int.Parse(user_id.ToString())];
                int row = neighborRatings.GetLength(0);

                for (int j = 0; j <= row -1 ; j++)
                {
                    for (int a = 0; a <= userRatings.GetLength(0)-1; a++)
                    {
                        if (neighborRatings[j, 0].Equals(userRatings[a, 0]))
                        {
                            break;
                        }
                       else if (!neighborRatings[j,0].Equals(userRatings[a,0]) && a==userRatings.GetLength(0)-1)
                        {
                            var userdata = new double[,]
                            {
                                {neighborRatings[j, 0],neighborRatings[j, 1]}
                            };
                            if (recommendationRanking.ContainsKey(user_id))
                            {
                                var data2 = new double[,] { };
                                data2 = recommendationRanking[user_id];
                                int rowLengthdata2 = data2.GetLength(0) - 1;
                                int colLenghtdata2 = 2;
                                int rowLengthdata3 = rowLengthdata2 + 1;
                                int newRow2Ddata3 = data2.GetLength(0) + 1;
                                var data3 = new double[newRow2Ddata3, colLenghtdata2];

                                for (int r = 0; r <= rowLengthdata2; r++)
                                {
                                    for (int c = 0; c < colLenghtdata2; c++)
                                    {
                                        data3[r, c] = data2[r, c];
                                    }

                                }
                                data3[rowLengthdata3, 0] = neighborRatings[j, 0];
                                data3[rowLengthdata3, 1] = neighborRatings[j, 1];
                                recommendationRanking[user_id] = data3;

                            }
                            else { recommendationRanking.Add(user_id, userdata); }
                        }
                    }
                }
            }
            //Ranking van predictedvalue berekenen
            var productCount = recommendationRanking.Count;
            var predictedRanking = new double[3, 3];
            // var usersCount = nearest.GetLength(0) - 1;
           
            for (int i = 0; i <= productCount-1; i++)
            {
                double sumPearson = 0;
               // int reset= 0;
              // double productValue= 
                for (int j = 0; j <= k-1; j++)
                {
                    double key = recommendationRanking.ElementAt(j).Key;
                    var data = recommendationRanking[key];
                    for (int d = 0; d <= data.GetLength(0) - 1; d++)
                    {
                        if (predictedRanking[i, 0] == 0 )
                        {
                            double similarity = nearest[j, 1];
                            double ranking = data[i, 1];
                            sumPearson += similarity;
                            predictedRanking[i, 0] = data[i, 0];
                            predictedRanking[i, 1] += similarity * ranking;
                            predictedRanking[i, 2] += (predictedRanking[0, 1] / sumPearson);
                            break;
                        }
                        else if (predictedRanking[i, 0] == data[d, 0] && i==0)
                        {
                            double similarity = nearest[j, 1];
                            double ranking = data[i, 1];
                            sumPearson += similarity;
                            predictedRanking[i, 0] = data[i, 0];
                            predictedRanking[i, 1] += similarity * ranking;
                            predictedRanking[i, 2] = (predictedRanking[i, 1] / sumPearson);
                            break;
                        }
                        else if (predictedRanking[i, 0] == data[d, 0] )
                        {
                            double similarity = nearest[j, 1];
                            double ranking = data[d, 1];
                            sumPearson += similarity;
                            predictedRanking[i, 0] = data[d, 0];
                            predictedRanking[i, 1] += similarity * ranking;
                            predictedRanking[i, 2] = (predictedRanking[i, 1] / sumPearson);
                            break;
                        }
                    }

                }
            }
            //sorteren tot k en dichtbij
            predictedRanking = Sort(predictedRanking);
            for (int i = 0; i <= predictedRanking.GetLength(0)-1; i++)
            {
                Console.WriteLine("Product id: " + predictedRanking[i, 0]);
                Console.WriteLine("Predicted value: " + predictedRanking[i, 2]);

            }
        }
        public static double[,] Sort(double[,] datas)
        {
            var data = datas;
            var number = data.GetLength(0);
            var array = new double[number];
            var newArray = new double[number, 3];
            for (int i = 0; i <= data.GetLength(0) - 1; i++)
            {
                array[i] = data[i, 2];
            }
            Array.Sort(array);
            Array.Reverse(array);
            for (int a = 0; a <= data.GetLength(0) - 1; a++)
            {
                for (int b = 0; b <= data.GetLength(0) - 1; b++)
                {
                    if (array[a] == data[b, 2])
                    {
                        newArray[a, 0] = data[b, 0];
                        newArray[a, 1] = data[b, 1];
                        newArray[a, 2] = data[b, 2];
                    }
                }
            }
            return newArray;
        }
    }



}
