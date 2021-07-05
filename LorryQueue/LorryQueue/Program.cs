using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryQueue
{
    class Program
    {
        class LorryCustomer
        {
            public int Weight;
            public int WeightMoved;
            public int WeightDefecit;
            public int LorriesMoved;

            public LorryCustomer(int WeightInput)
            {
                Weight = WeightInput;
                WeightMoved = 0;
                WeightDefecit = 0;
                LorriesMoved = 0;
            }
        }

        static void Main(string[] args)
        {           
            Random Rand = new Random();

            List<LorryCustomer> Lorries = new List<LorryCustomer>();
            Lorries.Add(new LorryCustomer(100));
            Lorries.Add(new LorryCustomer(50));
            Lorries.Add(new LorryCustomer(25));
            Lorries.Add(new LorryCustomer(10));

            int LorriesMovablePerDay = 10;        

            for (int Day = 0; Day < 2; Day++)
            {
                Console.WriteLine("");
                Console.WriteLine("New Day - " + (Day + 1).ToString());
                Console.WriteLine("");

                int HighestWeightMoved = 0;

                for (int i = 0; i< Lorries.Count; i++)
                {
                    Lorries[i].WeightMoved = 0 - Lorries[i].WeightDefecit;
                }

                for (int i = 0; i < LorriesMovablePerDay; i++)
                {
                    int LowestWeight = Lorries[0].WeightMoved;
                    int LowestIndex = 0;
                    for (int j = 0; j < Lorries.Count; j++)
                    {
                        if (Lorries[j].WeightMoved < LowestWeight)
                        {
                            //Check if present, rand upper is exclusive
                            int Chance = Rand.Next(0, 101);
                            //10% chance failure of truck to arrive at dock.
                            if (Chance > 10)
                            {
                                LowestWeight = Lorries[j].WeightMoved;
                                LowestIndex = j;
                            }                            
                        }
                    }

                    Lorries[LowestIndex].WeightMoved += Lorries[LowestIndex].Weight;
                    Lorries[LowestIndex].LorriesMoved++;
                    Console.WriteLine("Lorry " + LowestIndex.ToString() + " was moved, with " + Lorries[LowestIndex].Weight.ToString() + "kg of cargo.");
                    Console.WriteLine("Company " + LowestIndex.ToString() + " has a total of " + Lorries[LowestIndex].WeightMoved.ToString() + " weight moved.");

                    if (Lorries[LowestIndex].WeightMoved > HighestWeightMoved) HighestWeightMoved = Lorries[LowestIndex].WeightMoved;
                }

                for (int i = 0; i < Lorries.Count; i++)
                {
                    Lorries[i].WeightDefecit = HighestWeightMoved - Lorries[i].WeightMoved;
                    Console.WriteLine(Lorries[i].LorriesMoved.ToString());
                }
                
            }

            Console.WriteLine("");
            Console.ReadKey();
            
        }
    }
}
