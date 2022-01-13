namespace Sekretariat
{
    public class Uczen : Osoba
    {
        public string Klasa { get; set; }
        public string Grupy { get; set; }

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
                   Klasa + "\t" +
                   Grupy;

            if (Zdjecie_relative != null)
                data += "\t" + Zdjecie_relative;

            return data;
        }
    }
}