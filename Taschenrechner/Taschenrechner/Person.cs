using System;
using System.Collections.Generic;
using System.Text;

namespace Taschenrechner
{
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }

        public override bool Equals(object obj)
        {
            // Anforderungen:
            /* Gleicher Typ ?
             * Eines null ?
             * Referenzvergleich
             * Wertevergleich falls Referenzvergleich fehlschlägt
             */

            if (obj is null)
                throw new ArgumentNullException();

            if (obj is Person p) // obj.GetType() == typeof(Person)
            {
                //Referenzvergleich
                if (obj == this)
                    return true;
                else // Referenzen nicht gleich, stattdessen werte vergleichen
                {   // "Hässliche" Variante ohne GetHashcode();
                    return Vorname.Equals(p.Vorname) &&
                           Nachname.Equals(p.Nachname) &&
                           Alter.Equals(p.Alter) &&
                           Kontostand.Equals(p.Kontostand);
                }
            }
            else
                return false;
        }
    }
}
