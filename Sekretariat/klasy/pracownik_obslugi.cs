using System;

namespace Sekretariat
{
    public class Pracownik_obslugi : Osoba
    {
        public string Etat { get; set; }
        public string Opis_stanowiska { get; set; }
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
                   Etat + "\t" +
                   Opis_stanowiska + "\t" +
                   Data_zatrudnienia;

            if (Zdjecie_relative != null)
                data += "\t" + Zdjecie_relative;

            return data;
        }
    }
}