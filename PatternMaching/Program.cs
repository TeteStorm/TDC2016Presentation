using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMaching
{
    class Program
    {
        public static void ExibirInformacoesCotacao(Cotacao cotacao)
        {
            //double valorCotacao = cotacao match
            //              (
            //                  case CotacaoDolar dolar: dolar.ValorComercial
            //                  case CotacaoEuro euro: euro.ValorCotacao
            //                  case * : 0
            //              );


            double valorCotacao = 0;
            if (cotacao is CotacaoDolar dolar)
                valorCotacao = dolar.ValorComercial;
            else if (cotacao is CotacaoEuro euro)
                valorCotacao = euro.ValorCotacao;

            Console.WriteLine(new String('-', 40));
            Console.WriteLine($"Data: {cotacao.DataCotacao:dd/MM/yyyy}");
            Console.WriteLine($"Sigla: {cotacao.SiglaMoeda}");
            Console.WriteLine($"Moeda: {cotacao.NomeMoeda}");
            Console.WriteLine($"Valor: {valorCotacao:0.0000}");
        }

        static void Main(string[] args)
        {
            CotacaoDolar dolar = new CotacaoDolar();
            dolar.DataCotacao = new DateTime(2016, 4, 29);
            dolar.ValorComercial = 3.440;
            dolar.ValorTurismo = 3.580;
            ExibirInformacoesCotacao(dolar);

            CotacaoEuro euro = new CotacaoEuro();
            euro.DataCotacao = new DateTime(2016, 4, 29);
            euro.ValorCotacao = 3.938;
            ExibirInformacoesCotacao(euro);

            Console.ReadKey();
        }

        public static void CalculateBodyFatCotacao(BodyFatSkinfoldProtocol bodyFatProtocol)
        {
            //double valorCotacao = cotacao match
            //              (
            //                  case CotacaoDolar dolar: dolar.ValorComercial
            //                  case CotacaoEuro euro: euro.ValorCotacao
            //                  case * : 0
            //              );


            decimal bodyFat = 0;
            if (bodyFatProtocol is Guedes protocol)
            {
                bodyFat = protocol.Height;
            }
                
            else if (bodyFatProtocol is Faulkner protocol)
                bodyFat = protocol.Height;
            else if (bodyFatProtocol is PollockFive protocol)
                bodyFat = protocol.Height;
            else if (bodyFatProtocol is PollockSeven protocol)
                bodyFat = protocol.Height;
            else if (bodyFatProtocol is Yuhasz protocol)
                bodyFat = protocol.Height;
            else if (bodyFatProtocol is Lohman protocol)
                bodyFat = protocol.Height;

            Console.WriteLine($"Used Protocol : {bodyFatProtocol.ProtocolName}");
            Console.WriteLine($"Valor: {bodyFat:0.0000}");
        }

    }

    public enum Genre
    {
        Female = 0,
        Male = 1
    }


    public abstract class BodyFatSkinfoldProtocol
    {
        public abstract string ProtocolName { get; }

        public abstract int SkinfoldCount { get; }

        public abstract string FormuleDescription { get; }

        public Genre Sex { get; set; } 


        public decimal Height { get; set; }


        public decimal Weight { get; set; }

        public decimal Tricep { get; set; }
    }

    public class Guedes : BodyFatSkinfoldProtocol
    {
        public int Age { get; set; }
        public override string FormuleDescription
        {
            get
            {
                return "";
            }
        }

        public override string ProtocolName
        {
            get
            {
                return "Guedes";
            }
        }

        public override int SkinfoldCount
        {
            get
            {
                return 2;
            }
        }

        public decimal Subscapular { get; set; }
    }

    public class Faulkner : Guedes
    {
        public override string FormuleDescription
        {
            get
            {
                return "";
            }
        }

        public override string ProtocolName
        {
            get
            {
                return "Faulkner";
            }
        }

        public override int SkinfoldCount
        {
            get
            {
                return 4;
            }
        }
        public decimal Abdominal { get; set; }
        public decimal Suprailiac { get; set; }
    }

    public class PollockFive : BodyFatSkinfoldProtocol
    {
        public override string FormuleDescription
        {
            get
            {
                return "5 Dobras cutâneas (DC): Tríceps; coxa; supra-ilíaca; abdome e peitoral (X1=somatória de peitoral, abdome e coxa; X2=somatória de tríceps, supra-ilíaca e coxa, X3= idade em anos)";
            }
        }

        public override string ProtocolName
        {
            get
            {
                return "Pollock Five";
            }
        }

        public override int SkinfoldCount
        {
            get
            {
                return 5;
            }
        }
        public int Age { get; set; }
        public decimal Abdominal { get; set; }
        public decimal Suprailiac { get; set; }
        public decimal Chest { get; set; }

        public decimal Thigh { get; set; }
    }

    public class PollockSeven : PollockFive
    {
        public override string FormuleDescription
        {
            get
            {
                return "Dobras cutâneas (DC): Subescapular, axilar média, tríceps; coxa; supra-ilíaca; abdome e peitoral (ST= soma de todas)";
            }
        }

        public override string ProtocolName
        {
            get
            {
                return "Pollock Seven";
            }
        }

        public override int SkinfoldCount
        {
            get
            {
                return 7;
            }
        }
        public decimal Midaxilary { get; set; }

        public decimal Subscapular { get; set; }
    }

    public class Yuhasz : Faulkner
    {
        public override string FormuleDescription
        {
            get
            {
                return " 6 Dobras cutâneas (DC): Subescapular, tríceps; coxa; supra-ilíaca; abdome e peitoral (S6=somatória de todas)";
            }
        }

        public override string ProtocolName
        {
            get
            {
                return "Yuhasz";
            }
        }

        public override int SkinfoldCount
        {
            get
            {
                return 6;
            }
        }
        public decimal Chest { get; set; }
    }

    public class Lohman : BodyFatSkinfoldProtocol
    {
        public override string FormuleDescription
        {
            get
            {
                return " 2 Dobras cutâneas (DC): Tríceps e Perna";
            }
        }

        public override string ProtocolName
        {
            get
            {
                return "Lohman";
            }
        }

        public override int SkinfoldCount
        {
            get
            {
                return 2;
            }
        }
        public int Age { get; set; }


        public decimal Thigh { get; set; }
    }

    public abstract class Cotacao
    {
        public DateTime DataCotacao { get; set; }
        public abstract string SiglaMoeda { get; }
        public abstract string NomeMoeda { get; }
    }

    public class CotacaoDolar : Cotacao
    {
        public override string SiglaMoeda
        { get { return "USD"; } }

        public override string NomeMoeda
        { get { return "Dólar norte-americano"; } }

        public double ValorComercial { get; set; }
        public double ValorTurismo { get; set; }
    }

    public class CotacaoEuro : Cotacao
    {
        public override string SiglaMoeda
        { get { return "EUR"; } }

        public override string NomeMoeda
        { get { return "Euro"; } }

        public double ValorCotacao { get; set; }
    }
}
