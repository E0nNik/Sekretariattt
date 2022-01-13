using System;
using System.Collections.Generic;

namespace Sekretariat
{
    public class Nauczyciel : Osoba
    {
        public bool Wychowawstwo { get; set; }
        public string Przedmioty { get; set; }
        public string Ile_naucza { get; set; }
        public string Data_zatrudnienia { get; set; }

        public override string ToString()
        {
            string data = 
                   Imie + "\t" +
                   Imie_drugie + "\t" +
                   Nazwisko + "\t" +
                   Nazwisko_rodowe + "\t" +
                   Imie_matki + "\t" +
                   Imie_ojca + "\t" +
                   Data_urodzenia + "\t" +
                   Pesel + "\t" +
                   Plec + "\t" +
                   Wychowawstwo + "\t" +
                   Przedmioty + "\t" +
                   Ile_naucza + "\t" +
                   Data_zatrudnienia;

            if (Zdjecie_relative != null)
                data += "\t" + Zdjecie_relative;

            return data;
        }
    }
}