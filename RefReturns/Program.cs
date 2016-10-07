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

            // Mostra valor atual e incrementa 2kg usando a maneira padrão de incrementar 
            // que é método Increment
            Console.WriteLine("Current weight value: ");
            Console.WriteLine(myWeight.GetWeightValue());
            Console.WriteLine("Increment 2 kilogramans using the public method Increment");
            myWeight.Increment(2);

            Console.WriteLine("Current weight value after increment: ");
            Console.WriteLine(myWeight.GetWeightValue());
           
            // Pega a propriedade disponibilizada por referência 
            // e modifica diretamente a propriedade interna do objeto
            ref int teste = ref myWeight.GetWeight();
            // incrementa em 1 kg utilizando diretamente a propriedade weight obtida através do método ref int GetWeight();
            teste++;
            Console.WriteLine("Current weight value after external increment: ");
            Console.WriteLine(myWeight.GetWeightValue());
            Console.ReadKey();
        }
    }
}
