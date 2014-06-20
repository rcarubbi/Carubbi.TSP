using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carubbi.TSP
{
        /// <summary>
        /// Summary description for Chromosome.
        /// </summary>
        public class Chromosome
        {
            public Chromosome()
            {
                //
                // TODO: Add constructor logic here
                //
            }

            // The cost for the fitness of the chromosome
            protected double cost;
            
            Random randObj = new Random();

            //City myCity =  new City();
            // The list of cities which are the genes of the chromosome
            public int[] CityList {get; set; }

            // The mutation rate at percentage.
            protected double mutationPercent;

            // crossover point.
            protected int crossoverPoint;

            public Chromosome(City[] cities)
            {
                bool[] taken = new bool[cities.Length];
                CityList = new int[cities.Length];
                cost = 0.0;
                for (int i = 0; i < CityList.Length; i++) taken[i] = false;
                for (int i = 0; i < CityList.Length - 1; i++)
                {
                    int icandidate;
                    do
                    {
                        icandidate = (int)(randObj.NextDouble() * (double)CityList.Length);
                    } while (taken[icandidate]);

                    CityList[i] = icandidate;

                    taken[icandidate] = true;

                    if (i == CityList.Length - 2)
                    {
                        icandidate = 0;
                        while (taken[icandidate]) icandidate++;
                        CityList[i + 1] = icandidate;
                    }
                }

                calculateCost(cities);
                crossoverPoint = 1;
            }

            // fitness calculation
            //void calculateCost(myCity cities)
            public void calculateCost(City[] cities)
            {
                cost = 0;

                for (int i = 0; i < CityList.Length - 1; i++)
                {
                    double dist = cities[CityList[i]].proximity(cities[CityList[i + 1]]);
                    cost += dist;
                }
            }

            public double getCost()
            {
                return cost;
            }

            public int getCity(int i)
            {
                return CityList[i];
            }

            public void assignCities(int[] list)
            {
                for (int i = 0; i < CityList.Length; i++)
                {
                    CityList[i] = list[i];
                }
            }

            public void assignCity(int index, int value)
            {
                CityList[index] = value;
            }

            public void assignCut(int cut)
            {
                crossoverPoint = cut;
            }

            public void assignMutation(double prob)
            {
                mutationPercent = prob;
            }

            public int mate(Chromosome father, Chromosome offspring1, Chromosome offspring2)
            {
                int crossoverPostion1 = (int)((randObj.NextDouble()) * (double)(CityList.Length - crossoverPoint));
                int crossoverPostion2 = crossoverPostion1 + crossoverPoint;
                int[] offset1 = new int[CityList.Length];
                int[] offset2 = new int[CityList.Length];
                bool[] taken1 = new bool[CityList.Length];
                bool[] taken2 = new bool[CityList.Length];
                for (int i = 0; i < CityList.Length; i++)
                {
                    taken1[i] = false;
                    taken2[i] = false;
                }

                for (int i = 0; i < CityList.Length; i++)
                {
                    if (i < crossoverPostion1 || i >= crossoverPostion2)
                    {
                        offset1[i] = -1;
                        offset2[i] = -1;
                    }
                    else
                    {
                        int imother = CityList[i];
                        int ifather = father.getCity(i);
                        offset1[i] = ifather;
                        offset2[i] = imother;
                        taken1[ifather] = true;
                        taken2[imother] = true;
                    }
                }

                for (int i = 0; i < crossoverPostion1; i++)
                {
                    if (offset1[i] == -1)
                    {
                        for (int j = 0; j < CityList.Length; j++)
                        {
                            int imother = CityList[j];
                            if (!taken1[imother])
                            {
                                offset1[i] = imother;
                                taken1[imother] = true;
                                break;
                            }
                        }
                    }

                    if (offset2[i] == -1)
                    {
                        for (int j = 0; j < CityList.Length; j++)
                        {
                            int ifather = father.getCity(j);
                            if (!taken2[ifather])
                            {
                                offset2[i] = ifather;
                                taken2[ifather] = true;
                                break;
                            }
                        }
                    }
                }

                for (int i = CityList.Length - 1; i >= crossoverPostion2; i--)
                {
                    if (offset1[i] == -1)
                    {
                        for (int j = CityList.Length - 1; j >= 0; j--)
                        {
                            int imother = CityList[j];
                            if (!taken1[imother])
                            {
                                offset1[i] = imother;
                                taken1[imother] = true;
                                break;
                            }
                        }
                    }

                    if (offset2[i] == -1)
                    {
                        for (int j = CityList.Length - 1; j >= 0; j--)
                        {
                            int ifather = father.getCity(j);
                            if (!taken2[ifather])
                            {
                                offset2[i] = ifather;
                                taken2[ifather] = true;
                                break;
                            }
                        }
                    }
                }

                offspring1.assignCities(offset1);
                offspring2.assignCities(offset2);

                int mutate = 0;
                int swapPoint1 = 0;
                int swapPoint2 = 0;

                if (randObj.NextDouble() < mutationPercent)
                {
                    swapPoint1 = (int)(randObj.NextDouble() * (double)(CityList.Length));
                    swapPoint2 = (int)(randObj.NextDouble() * (double)CityList.Length);
                    int i = offset1[swapPoint1];
                    offset1[swapPoint1] = offset1[swapPoint2];
                    offset1[swapPoint2] = i;
                    mutate++;
                }

                if (randObj.NextDouble() < mutationPercent)
                {
                    swapPoint1 = (int)(randObj.NextDouble() * (double)(CityList.Length));
                    swapPoint2 = (int)(randObj.NextDouble() * (double)CityList.Length);

                    int i = offset2[swapPoint1];

                    offset2[swapPoint1] = offset2[swapPoint2];
                    offset2[swapPoint2] = i;

                    mutate++;
                }

                return mutate;

            }

            public void PrintCity(int i, City[] cities)
            {
                System.Console.WriteLine("City " + i.ToString() + ": (" + cities[CityList[i]].getx().ToString() + ", " + cities[CityList[i]].gety().ToString() + ")");
            }

            // chromosomes -- an array of chromosomes which is sorted
            // num -- the number of the chromosome list
            public static void sortChromosomes(Chromosome[] chromosomes, int num)
            {
                bool swapped = true;
                Chromosome dummy;

                while (swapped)
                {
                    swapped = false;

                    for (int i = 0; i < num - 1; i++)
                    {
                        if (chromosomes[i].getCost() > chromosomes[i + 1].getCost())
                        {
                            dummy = chromosomes[i];
                            chromosomes[i] = chromosomes[i + 1];
                            chromosomes[i + 1] = dummy;
                            swapped = true;
                        }
                    }
                }

                

            }
        }
    }
