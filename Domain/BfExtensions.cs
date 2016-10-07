using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class BfExtensions
    {
        public static void Deconstruct(this BodyFatSkinfoldProtocol bodyFatProtocol, out string protocolName, out string formuleDescription)
        {
            protocolName = bodyFatProtocol.ProtocolName;
            formuleDescription = bodyFatProtocol.FormuleDescription;
        }
    }
}
