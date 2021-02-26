using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net;
using System.IO;
using System.Xml;
using System;
using System.Xml.Serialization;

namespace CommonTypes
{
    //TODO: Diese Klasse muss das Interface System.IEquatable implementieren,
    //um in Collections die generischen Funktionen nutzen zu können
    public class KFZ
    {
        public long Id;
        public string FahrgestNr;
        public string Kennzeichen;
        public int Leistung;
        public string Typ;

        public KFZ()
        {

        }

        
        public override string ToString()
        {
            return string.Format("{0} ({1})", this.Kennzeichen, this.Typ);
        }

        
    }
}
