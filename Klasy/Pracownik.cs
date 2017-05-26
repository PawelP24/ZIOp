using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_biblioteczny
{
    public class Pracownik
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string PESEL { get; set; }
        public string Nr_telefonu { get; set; }
        public Pracownik(string imie,string nazwisko,string PESEL, string nr_telefonu)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.PESEL = PESEL;
            this.Nr_telefonu = nr_telefonu;
        }
    }
}
