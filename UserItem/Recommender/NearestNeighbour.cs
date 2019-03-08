using System;
using System.Collections.Generic;
using System.Text;

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
            int row = users.Count-1;
            var distances_neighbours = new double[row, 2 ];
            var list_users = users;
            foreach (var item in list_users)
            {
                if (!item.Key.Equals(UserID))
                {
                    var user_id = item.Key;
                    var distance = Distances.Pearson.ComputePearson(users[UserID], users[item.Key]);
                    
                   for (int i = 0; i < row-1; i++)
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
            return distances_neighbours;
        }

        public static double[,] ComputeRecommendations(int UserID, Dictionary<int, double[,]> users, int k)
        {
            var nearest = ComputeNearestNeighbour(UserID, users);
            var recommendations = new double[k, 2];
            var userRatings = users[UserID];
            double total_distance = 0.0;
            for (int i = 0; i < k-1; i++)
            {
                total_distance += nearest[i,1];

            }
            for (int i = 0; i < k-1; i++)
            {
                var weight = nearest[i, 1] / total_distance;
                double user_id = nearest[i, 0];
                var neighborRatings = users[int.Parse(user_id.ToString())];
                int row = neighborRatings.GetLength(0);

                for (int j = 0; j < row -1 ; j++)
                {
                    for (int a = 0; a < userRatings.GetLength(0)-1; a++)
                    {
                        if (!neighborRatings[j,0].Equals(userRatings[a,0]))
                        {
                            for (int b = 0; b < recommendations.GetLength(0)-1; b++)
                            {
                                if (recommendations[b, 0] == null && recommendations[0, 0]!=null || !user_id.Equals(recommendations[b,0]) )
                                {
                                    recommendations[b, 0] = user_id;
                                    recommendations[b, 1] = (neighborRatings[j, 1]* weight);
                                }
                                else
                                {
                                    if (recommendations[0, 0] == null)
                                    {
                                        recommendations[b, 0] = user_id;
                                        recommendations[b, 1] = (neighborRatings[j, 1] * weight);
                                    }
                                    else
                                    {
                                        recommendations[b, 1] += (neighborRatings[j, 1] * weight);
                                    }
                                    
                                }
                            }
                        }
                    }
                }
            }
            //sorteren tot k en dichtbij
            return recommendations;
        }
    }
    //def computeNearestNeighbor(self, username):
    //        """creates a sorted list of users based on their distance to
    //        username"""
    //        distances = []
    //        for instance in self.data:
    //            if instance != username:
    //                distance = self.fn(self.data[username],
    //                                   self.data[instance])
    //                distances.append((instance, distance))
    //        # sort based on distance -- closest first
    //        distances.sort(key=lambda artistTuple: artistTuple[1],
    //                       reverse=True)
    //        return distances

}

//def recommend(self, user):
//       """Give list of recommendations"""
//       recommendations = {}
//       # first get list of users  ordered by nearness
//       nearest = self.computeNearestNeighbor(user)
//#
//# now get the ratings for the user
//#
//       userRatings = self.data[user]
//       #
//       # determine the total distance
//       totalDistance = 0.0
//       for i in range(self.k) :
//          totalDistance += nearest[i][1]
//       # now iterate through the k nearest neighbors
//       # accumulating their ratings
//       for i in range(self.k) :
//          # compute slice of pie 
//          weight = nearest[i][1] / totalDistance
//# get the name of the person
//          name = nearest[i][0]
//          # get the ratings for this person
//          neighborRatings = self.data[name]
//          # get the name of the person
//          # now find bands neighbor rated that user didn't
//          for artist in neighborRatings:
//             if not artist in userRatings:
//                if artist not in recommendations:
//                   recommendations[artist] = (neighborRatings[artist]
//                                              * weight)
//                else:
//                   recommendations[artist] = (recommendations[artist]
//                                              + neighborRatings[artist]
//                                              * weight)
//       # now make list from dictionary
//       recommendations = list(recommendations.items())
//       recommendations = [(self.convertProductID2name(k), v)
//                          for (k, v) in recommendations]
//# finally sort and return
//recommendations.sort(key=lambda artistTuple: artistTuple[1],
//                            reverse = True)
//       # Return the first n items
//       return recommendations[:self.n]

