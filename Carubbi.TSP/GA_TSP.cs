using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Carubbi.TSP
{

    public class NewCityEventArgs : EventArgs
    {
        public City NewCity { get; set; }
    }

    public class GenerationCreatedEventArgs : EventArgs
    {
        public Chromosome[] Generation { get; set; }
        public int GenerationNumber { get; set; }
    }

    public class GA_TSP
    {
        protected int cityCount;
        protected int populationSize;
        protected double mutationPercent;
        protected int matingPopulationSize;
        protected int favoredPopulationSize;
        protected int cutLength;
        protected int generation;
      
        protected bool started = false;
        public City[] Cities;
        protected Chromosome[] chromosomes;
        public event EventHandler<NewCityEventArgs> CityCreated;
        

        public GA_TSP()
        {

        }

        public void Initialization()
        {
            Random randObj = new Random();
            thisCost = 500.0;
            oldCost = 0.0;
            dcost = 500.0;
            countSame = 0;
          

            try
            {
                cityCount = 10;
                populationSize = 2000;
                mutationPercent = 1.5;
            }
            catch (Exception e)
            {
                cityCount = 100;
            }

            matingPopulationSize = populationSize / 2;
            favoredPopulationSize = matingPopulationSize / 2;
            cutLength = cityCount / 5;

            

            // create a random list of cities
            Cities = new City[cityCount];

            for (int i = 0; i < cityCount; i++)
            {
                Cities[i] = new City(
                (int)(randObj.NextDouble() * 30), (int)(randObj.NextDouble() * 15));
                if (CityCreated != null)
                    CityCreated(this, new NewCityEventArgs() { NewCity = Cities[i] });
            }

            // create the initial chromosomes
            chromosomes = new Chromosome[populationSize];

            for (int i = 0; i < populationSize; i++)
            {
                chromosomes[i] = new Chromosome(Cities);
                chromosomes[i].assignCut(cutLength);
                chromosomes[i].assignMutation(mutationPercent);
            }

            Chromosome.sortChromosomes(chromosomes, populationSize);
       
            if (GenerationCreated != null)
                    GenerationCreated(this, new GenerationCreatedEventArgs() { Generation = chromosomes, GenerationNumber = generation });

            started = true;

            generation = 0;

        }

        public event EventHandler<GenerationCreatedEventArgs> GenerationCreated;
        private double thisCost = 500.0;
        private double oldCost = 0.0;
        private double dcost = 500.0;
        private int countSame = 0;
        private Random randObj = new Random();

        public bool NextGeneration()
        {
            if (countSame < 120 && oldCost == thisCost)
            {
                CreateGeneration(ref thisCost, ref oldCost, ref dcost, ref countSame, randObj);
                return false;
            }
            else if (countSame >= 120)
            {
                return true;
            }
            else
            {
                CreateGeneration(ref thisCost, ref oldCost, ref dcost, ref countSame, randObj);
                return true;
            }
 
        }

        private void CreateGeneration(ref double thisCost, ref double oldCost, ref double dcost, ref int countSame, Random randObj)
        {
            generation++;
            int ioffset = matingPopulationSize;
            int mutated = 0;
            for (int i = 0; i < favoredPopulationSize; i++)
            {
                Chromosome cmother = chromosomes[i];
                int father = (int)(randObj.NextDouble() * (double)matingPopulationSize);
                Chromosome cfather = chromosomes[father];
                mutated += cmother.mate(cfather, chromosomes[ioffset], chromosomes[ioffset + 1]);
                ioffset += 2;
            }

            for (int i = 0; i < matingPopulationSize; i++)
            {
                chromosomes[i] = chromosomes[i + matingPopulationSize];
                chromosomes[i].calculateCost(Cities);
            }

            // Now sort the new population
            Chromosome.sortChromosomes(chromosomes, matingPopulationSize);


            double cost = chromosomes[0].getCost();
            dcost = Math.Abs(cost - thisCost);
            thisCost = cost;
            double mutationRate = 100.0 * (double)mutated / (double)matingPopulationSize;

            if ((int)thisCost == (int)oldCost)
            {
                countSame++;
            }
            else
            {
                countSame = 0;
                oldCost = thisCost;
                //System.Console.WriteLine("oldCost = " + oldCost.ToString());
            }

            if (GenerationCreated != null)
                GenerationCreated(this, new GenerationCreatedEventArgs() { Generation = chromosomes, GenerationNumber = generation });

        }
    }
}
