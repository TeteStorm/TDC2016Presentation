using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum Genre
    {
        Female = 0,
        Male = 1
    }


    public abstract class BodyFatSkinfoldProtocol
    {
        public abstract string ProtocolName { get; }

        public abstract int SkinfoldCount { get; }

        public decimal TotalBodyFat { get; set; }

        public decimal BodyFatPercent { get; set; } 

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
}
