using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefReturns
{
    public class BodyWeight
    {
        private int _weight = 0;

        public BodyWeight(int currentWeight)
        {
            _weight = currentWeight;
        }
        public void Increment(int value)
        {
            _weight = _weight + value;
        }

        public int GetWeightValue()
        {
            return _weight;
        }

        public ref int GetWeight()
        {
            return ref _weight;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BodyWeight myWeight = new BodyWeight(58);
            Console.WriteLine("Current weight value: ");
            Console.WriteLine(myWeight.GetWeightValue());
            Console.WriteLine("Increment 2 kilogramans using the public method Increment");
            myWeight.Increment(2);
            Console.WriteLine("Current weight value after increment: ");
            Console.WriteLine(myWeight.GetWeightValue());
            //get a the weight property by reference through method ref int GetWeight()
            ref int teste = ref myWeight.GetWeight();
            // increment 3 kilogramans using the directly the weight property got by ref int GetWeight() method");
            teste++;
            Console.WriteLine("Current weight value after external increment: ");
            Console.WriteLine(myWeight.GetWeightValue());
            Console.ReadKey();
        }
    }
}
