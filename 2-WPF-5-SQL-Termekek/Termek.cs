using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace _2_WPF_5_SQL_Termekek
{
    public class Termek
    {
        string nev;
        int darabSzam;
        double maxAr;
        double atlagAr;

                       
         public Termek(string nev, int darabSzam, double maxAr, double atlagAr)  // konstruktor

         {

              this.nev = nev;
              this.darabSzam = darabSzam;
              this.maxAr = maxAr;
              this.atlagAr = atlagAr;

         }
                // CSak olvasható propertie-k ( mezők --> a tábla oszlopai )
             public string Nev { get => nev; }
             public int DarabSzam { get => darabSzam; }
             public double MaxAr { get => maxAr; }
             public double AtlagAr { get => atlagAr; }   

    }
    
}
