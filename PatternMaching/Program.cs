using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMaching
{
    class Program
    {

        static void Main(string[] args)
        {
           

            Console.ReadKey();
        }

  

        public static void CalculateBodyFat(BodyFatSkinfoldProtocol bodyFatProtocol)
        {
            decimal bodyFat = 0;
            var bodyFatPercent = 0D;

            //Utilização do "is"

            // Constant pattern
            // Antes podíamos validar se o valor era nulo ou se o valor era de um determinado tipo
            // if (bodyFatProtocol == null) { ... }
            // if (bodyFatProtocol is BodyFatSkinfoldProtocol) { ... }
            // Agora podemos validar diretamente em constantes (ou números)
            if (bodyFatProtocol is null)
                throw new ArgumentNullException("Protocol must not be null");

            // Var pattern
            // Aqui sempre vai dar match, a comparação simplemente coloca o valor obtido 
            // numa nova variável que será do tipo do input, vale lembrar que ela funciona somente dentro do scopo do if
            if (bodyFatPercent is var bf)
            {
                Console.WriteLine(bf);
            }

            // Type pattern
            // Aqui além de testar o tipo extraímos o valor em uma nova variável do tipo proposto
            if (bodyFatProtocol is Guedes protocol)
            {
                //{ ... }
                bodyFat = protocol.Height;
            }   
            else if (bodyFatProtocol is Faulkner protocol)
            {
                //{ ... }
                bodyFat = protocol.Height;
            }
            else if (bodyFatProtocol is PollockFive protocol)
            {
                //{ ... }
                bodyFat = protocol.Height;
            }
            else if (bodyFatProtocol is PollockSeven protocol)
            {
                //{ ... }
                bodyFat = protocol.Height;
            }
            else if (bodyFatProtocol is Yuhasz protocol)
            {
                //{ ... }
                bodyFat = protocol.Height;
            }
            else if (bodyFatProtocol is Lohman protocol)
            {
                //{ ... }
                bodyFat = protocol.Height;
            }


            Console.WriteLine($"Used Protocol : {bodyFatProtocol.ProtocolName}");
            Console.WriteLine($"Valor: {bodyFat:0.0000}");
        }

        public static void PrintRoules(BodyFatSkinfoldProtocol bodyFatProtocol)
        {
            //Utilização do swith
            switch (bodyFatProtocol)
            {
                case Faulkner faulkner when faulkner.Age > 18:
                    Console.WriteLine($"Used Protocol Formule : {bodyFatProtocol.FormuleDescription}");
                    break;
                case Guedes guedes:
                    Console.WriteLine(guedes.FormuleDescription);
                    break;

                default:
                    break;
            }
        }

    }

}
