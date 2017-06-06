using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_biblioteczny
{
    public class Wypozyczenie
    {
        public string ISBN { get; set; }
        public string PESELCzytelnik { get; set; }
        public string PESELPracownik { get; set; }
        public int Okres_wypozyczenie { get; set; }
    }
}
