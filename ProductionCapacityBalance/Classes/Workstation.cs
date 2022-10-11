using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionCapacityBalance.Classes
{
    internal class Workstation
    {
        int max { get; set; }
        int min { get; set; }
        Random random;

        public Workstation(int max,int min,Random rnd) 
        { 
            this.max = max;
            this.min = min; 
            random = rnd;
        }

        //Моделирует равномерное дискретное распределение стандартным методом
        public int predictOutcome() 
        {
            double rand=random.NextDouble();
            double probabilityOfOne = (double)1/(max - min + 1); // вероятеность любого попадания числа в диапазон
            double probabilityCounter = 0;
            int outcomeCounter = min;
            while (probabilityCounter <= rand) 
            {
                probabilityCounter += probabilityOfOne;
                outcomeCounter++;
            }
            return outcomeCounter;
        }

    }
    
}
