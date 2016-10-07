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
            PrintDesconstruction();
           // PrintProtocolDetais();
           // PrintNamedProtocolDetais();
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

        // Retorna 3 valores dentro de um elemento literal de tupla de maneira nomeada que podem ser acessados atráves dos nomes das propriedades 
        // especificados mas somente dentro do scopo onde está sendo criado, externamente só acessaríamos novamente por Item1, Item2, Item3
        static (decimal, decimal , string ) GetLiteralProtocolValues(BodyFatSkinfoldProtocol bodyFatProtocol)
        {
            var returnValues = (Weight: bodyFatProtocol.Weight, TotalBodyFat: bodyFatProtocol.BodyFatPercent, Protocol: bodyFatProtocol.ProtocolName);
            Console.WriteLine($"Weight:{returnValues.Weight} Total Body Fat:{returnValues.TotalBodyFat} Protocol:{returnValues.Protocol}");
            return returnValues;
        }


        // Deconstruct
        // Automaticamente chama o método ou extension method Desconstruct implementado no objeto
        public static void PrintDesconstruction()
        {
            var guedes = new Guedes() { Height = 167, Weight = 58 };
            (var name, var description) = guedes;
            Console.WriteLine($"Protocol name: {name}");
            Console.WriteLine($"Protocol description: {description}");
        }
    }
}
