using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintOutVars("50");
            PrintDesconstruction();
            PrintProtocolDetais();
            PrintNamedProtocolDetais();

            var tupleLiteralIncrement = IncrementWeight(new Guedes() { Weight = 50, TotalBodyFat = 22 }, new List<decimal>() { 1.3M, 1.8M, 3.2M, 2, 4 });
            Console.WriteLine($"Current weigth: {tupleLiteralIncrement.currentWeight}");
            Console.WriteLine($"Month increase average: {tupleLiteralIncrement.average}");


            //Como ainda existe restrição de escopo para conseguir acessar as variáveis pelo nome precisamos criar um para poder acessá-las
            if (DesconstructionInOutVariablesScoped(out string name, out string description))
            {
                Console.WriteLine($"Protocol name: {name}");
                Console.WriteLine($"Protocol description: {description}");
            }
            Console.ReadLine();
        }

        // Tuples and Desconstruction

        // Retorna 3 valores dentro de um elemento tupla que podem ser acessados atráves das propriedades Item1, Item2, Item3
        static (decimal, decimal, string) GetProtocolValues(BodyFatSkinfoldProtocol bodyFatProtocol)
        {
            return (bodyFatProtocol.Weight, bodyFatProtocol.BodyFatPercent, bodyFatProtocol.ProtocolName);
        }

        static void PrintProtocolDetais()
        {
            var protocolDetails = GetProtocolValues(new Guedes() { Height = 167, Weight = 58 });
            Console.WriteLine($"Weight:{protocolDetails.Item1} Total Body Fat:{protocolDetails.Item2} Protocol:{protocolDetails.Item3}");
        }


        // Retorna 3 valores dentro de um elemento tupla mas de maneira nomeada com variáveis explícitas
        // que poderão ser acessadas atráves dos nomes das propriedades
        static (decimal Weight, decimal TotalBodyFat, string Protocol) GetNamedProtocolValues(BodyFatSkinfoldProtocol bodyFatProtocol)
        {
            var returnValues = (bodyFatProtocol.Weight, bodyFatProtocol.BodyFatPercent, bodyFatProtocol.ProtocolName);
            return returnValues;
        }

        //Tuple literal
        // Retorna 2 valores dentro de um elemento literal de tupla de maneira nomeada que podem ser acessados atráves dos nomes das propriedades 
        static (decimal currentWeight, decimal average) IncrementWeight(BodyFatSkinfoldProtocol bodyFatProtocol, IEnumerable<decimal> monthKilogramIncrease)
        {
            var res = (currentWeight: 0M, average: 0M);
            var totalIncrease = 0M;
            var returnValues = (Weight: bodyFatProtocol.Weight, TotalBodyFat: bodyFatProtocol.BodyFatPercent, Protocol: bodyFatProtocol.ProtocolName);
            foreach (var item in monthKilogramIncrease)
            {
                returnValues.Weight += item;
                res.currentWeight = returnValues.Weight;
                totalIncrease += item;
                res.average = totalIncrease / monthKilogramIncrease.Count();

            }

            Console.WriteLine($"Weight:{returnValues.Weight} Total Body Fat:{returnValues.TotalBodyFat} Protocol:{returnValues.Protocol}");
            return res;
        }


        //Desconstruction
        static void PrintNamedProtocolDetais()
        {
            //Em variáveis pré declaradas
            decimal weight, totalFat;
            string protocol;

            (weight, totalFat, protocol) = GetNamedProtocolValues(new Guedes() { Height = 167, Weight = 58 });
            
            // Em uma variável anônima
            var protocolDetails = GetNamedProtocolValues(new Guedes() { Height = 167, Weight = 58 });        
            Console.WriteLine($"Weight:{protocolDetails.Weight} Total Body Fat:{protocolDetails.TotalBodyFat} Protocol:{protocolDetails.Protocol}");

            // Em variáveis explícitas 
            (var we, var bft, var pn) = GetNamedProtocolValues(new Guedes() { Height = 167, Weight = 58 });
            Console.WriteLine($"Weight:{we} Total Body Fat:{bft} Protocol:{pn}");

            // Em variáveis explícitas tipadas
            (decimal w, decimal bf, string p) = GetNamedProtocolValues(new Guedes() { Height = 167, Weight = 58 });
            Console.WriteLine($"Weight:{w} Total Body Fat:{bf} Protocol:{p}");

        }

      
        // Automaticamente chama o método ou extension method Desconstruct implementado no objeto
        public static void PrintDesconstruction()
        {
            
            var guedes = new Guedes() { Height = 167, Weight = 58 };
            (var name, var description) = guedes; //calls method Deconstruct
            Console.WriteLine($"Protocol name: {name}");
            Console.WriteLine($"Protocol description: {description}");

            //maneira antiga
            string x;
            guedes.Deconstruct(out x);
            Console.WriteLine($"Protocol and description: {x}");
        }

        // Deconstruct in new Out 
        public static bool DesconstructionInOutVariablesScoped(out string name, out string description)
        {

            var guedes = new Guedes() { Height = 167, Weight = 58 };
            (name, description) = guedes; //calls method Deconstruct
            return true;
        }

        // Deconstruct in new Out 
        public static void DesconstructionInOutVariables(out string name, out string description)
        {

            var guedes = new Guedes() { Height = 167, Weight = 58 };
            (name, description) = guedes; //calls method Deconstruct
        }

        // Out Var
        public static void PrintOutVars(string weight)
        {
            if (int.TryParse(weight, out var intWeight))
            {
                Console.WriteLine(new string('*', intWeight));
            }

        }
    }
}
