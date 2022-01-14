using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sekretariat
{
    public partial class MainWindow : Window
    {
        private List<Uczen> GetStudents()
        {
            students.Clear();

            string path = Path.Combine(Directory.GetCurrentDirectory(), @"baza_danych\Uczniowie.txt");
            bool clearFile = false;

            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader reader = File.OpenText(path))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line == "")
                            {
                                clearFile = true;
                                break;
                            }

                            var pola = line.Split("\t").ToList();

                            var student = new Uczen()
                            {
                                Imie = pola[0],
                                Imie_drugie = pola[1],
                                Nazwisko = pola[2],
                                Nazwisko_rodowe = pola[3],
                                Imie_matki = pola[4],
                                Imie_ojca = pola[5],
                                Data_urodzenia = pola[6],
                                Pesel = pola[7],
                                Plec = pola[8],
                                Klasa = pola[9],
                                Grupy = pola[10],
                                Zdjecie_absolute = null,
                                Zdjecie_relative = null
                            };

                            student.Zdjecie_relative = (pola.Count == 12)
                                ? pola[11]
                                : null;

                            student.Zdjecie_absolute = (student.Zdjecie_relative != null)
                                ? Path.Combine(Directory.GetCurrentDirectory(), @"zdjecia\" + student.Zdjecie_relative)
                                : NoImage;

                            students.Add(student);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Chwilka na domkniêcie pliku!");
                }

                if (clearFile)
                    File.Create(path);
            }

            return students;
        }

        private List<Uczen> SearchStudents()
        {
            students.Clear();

            string path = Path.Combine(Directory.GetCurrentDirectory(), @"baza_danych\Uczniowie.txt");
            bool clearFile = false;

            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader reader = File.OpenText(path))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line == "")
                            {
                                clearFile = true;
                                break;
                            }

                            var pola = line.Split("\t").ToList();

                            var student = new Uczen()
                            {
                                Imie = pola[0],
                                Imie_drugie = pola[1],
                                Nazwisko = pola[2],
                                Nazwisko_rodowe = pola[3],
                                Imie_matki = pola[4],
                                Imie_ojca = pola[5],
                                Data_urodzenia = pola[6],
                                Pesel = pola[7],
                                Plec = pola[8],
                                Klasa = pola[9],
                                Grupy = pola[10],
                                Zdjecie_absolute = null,
                                Zdjecie_relative = null
                            };

                            student.Zdjecie_relative = (pola.Count == 12)
                                ? pola[11]
                                : null;

                            student.Zdjecie_absolute = (student.Zdjecie_relative != null)
                                ? Path.Combine(Directory.GetCurrentDirectory(), @"zdjecia\" + student.Zdjecie_relative)
                                : NoImage;

                            bool toShow = false;

                            if (Uczniowie_SearchColNum.SelectedIndex != 6 && Uczniowie_SearchText.Text != null)
                            {
                                switch (Uczniowie_SearchColNum.SelectedIndex)
                                {
                                    case 0:
                                        {
                                            if (student.Imie.Equals(Uczniowie_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 1:
                                        {
                                            if (student.Imie_drugie.Equals(Uczniowie_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 2:
                                        {
                                            if (student.Nazwisko.Equals(Uczniowie_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 3:
                                        {
                                            if (student.Nazwisko_rodowe.Equals(Uczniowie_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 4:
                                        {
                                            if (student.Imie_matki.Equals(Uczniowie_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 5:
                                        {
                                            if (student.Imie_ojca.Equals(Uczniowie_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 7:
                                        {
                                            if (student.Pesel.Equals(Uczniowie_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 8:
                                        {
                                            if (student.Plec.Equals(Uczniowie_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 9:
                                        {
                                            if (student.Klasa.Equals(Uczniowie_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 10:
                                        {
                                            if (student.Grupy.Equals(Uczniowie_SearchText.Text))
                                            {
                                                toShow = true;
                                                break;
                                            }

                                            string[] groups = student.Grupy.Split(", ");
                                            bool anyGroupGood = false;

                                            foreach (string group in groups)
                                            {
                                                if (group.Equals(Uczniowie_SearchText.Text))
                                                {
                                                    anyGroupGood = true;
                                                    break;
                                                }
                                            }

                                            if (anyGroupGood)
                                                toShow = true;

                                            break;
                                        }
                                }
                            }
                            else if (Uczniowie_SearchColNum.SelectedIndex == 6 && Uczniowie_SelectedDate.SelectedDate != null)
                            {
                                DateTime studentDate = DateTime.Parse(student.Data_urodzenia);
                                DateTime selectedDate = (DateTime)Uczniowie_SelectedDate.SelectedDate;

                                switch (Uczniowie_SearchForDate.SelectedIndex)
                                {
                                    case 0:
                                        toShow = studentDate < selectedDate;
                                        break;

                                    case 1:
                                        toShow = studentDate <= selectedDate;
                                        break;

                                    case 2:
                                        toShow = selectedDate < studentDate;
                                        break;

                                    case 3:
                                        toShow = selectedDate <= studentDate;
                                        break;

                                    case 4:
                                        toShow = studentDate == selectedDate;
                                        break;
                                }
                            }

                            if (toShow)
                                students.Add(student);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Chwilka na domkniêcie pliku!");
                }

                if (clearFile)
                    File.Create(path);
            }
            return students;
        }

        private void ClearSortUczniowie()
        {
            Uczniowie_SortColNum.SelectedIndex = 0;
            Uczniowie_SortAscDesc.SelectedIndex = 0;
            ClearSortDataGrid(DG_Dane_Uczniowie);
        }

        private void Uczniowie_ComboBoxChange(object sender, SelectionChangedEventArgs e)
        {
            var CB = sender as ComboBox;

            Uczniowie_SearchText.IsEnabled = CB.SelectedIndex != 6;
            Uczniowie_SearchForDate.IsEnabled = CB.SelectedIndex == 6;
            Uczniowie_SelectedDate.IsEnabled = CB.SelectedIndex == 6;

            Uczniowie_SearchText.Text = "";
            Uczniowie_SearchForDate.SelectedIndex = 0;
            Uczniowie_SelectedDate.SelectedDate = default;
        }

        private void SearchUczniowie(object sender, RoutedEventArgs e)
        {
            ClearSortUczniowie();
            DG_Dane_Uczniowie.ItemsSource = SearchStudents();
            DG_Dane_Uczniowie.Items.Refresh();
        }

        private void ClearSearchUczniowie(object sender, RoutedEventArgs e)
        {
            ClearSortUczniowie();
            Uczniowie_SearchColNum.SelectedIndex = 0;
            Uczniowie_SearchText.IsEnabled = true;
            Uczniowie_SearchText.Text = "";
            Uczniowie_SearchForDate.IsEnabled = false;
            Uczniowie_SearchForDate.SelectedIndex = 0;
            ReportUpdate();
        }

        private void SortUczniowie()
        {
            if (Uczniowie_SortColNum.SelectedItem != null && Uczniowie_SortAscDesc.SelectedItem != null)
                SortDataGrid(DG_Dane_Uczniowie,
                    Uczniowie_SortColNum.SelectedIndex + 2,
                    (Uczniowie_SortAscDesc.SelectedIndex == 0)
                        ? ListSortDirection.Ascending
                        : ListSortDirection.Descending
                );
        }

        private void AddStudent()
        {
            List<string> properties = new List<string>()
            {
                Uczen_DodajImie.Text,
                Uczen_DodajDrugieImie.Text,
                Uczen_DodajNazwisko.Text,
                Uczen_DodajNazwiskoRodowe.Text,
                Uczen_DodajImieMatki.Text,
                Uczen_DodajImieOjca.Text,
                Uczen_DodajDateUrodzenia.Text,
                Uczen_DodajPesel.Text,
                Uczen_DodajPlec.Text,
                Uczen_DodajKlase.Text,
                Uczen_DodajGrupy.Text
            };

            string studentProperties = "";

            foreach (string prop in properties)
            {
                if(prop == "")
                {
                    MessageBox.Show("Proszê wype³niæ wszystkie pola!");
                    return;
                }

                studentProperties += prop + "\t";
            }

            studentProperties = studentProperties.Trim();

            string img = Uczen_Zdjecie.Source.ToString()[(Uczen_Zdjecie.Source.ToString().LastIndexOf("/") + 1)..];

            if (img != "IMAGE.png")
                studentProperties += "\t" + img;

            SaveIntoDatabase("Uczniowie", studentProperties, true);

            MessageBox.Show("Uczeñ dodany do bazy danych!");
        }

        private void DeleteStudent(Uczen StudentToDelete)
        {
            List<Uczen> AllStudents = GetStudents();

            string StudentsToSave = "";

            foreach (Uczen tempStudent in AllStudents)
            {
                if (StudentToDelete.ToString() != tempStudent.ToString())
                    StudentsToSave += tempStudent.ToString() + Environment.NewLine;
            }

            StudentsToSave = StudentsToSave.Trim();

            SaveIntoDatabase("Uczniowie", StudentsToSave, false);

            ReportUpdate();
        }

        private void EditStudent(Uczen StudentToEdit)
        {
            List<string> properties = new List<string>()
            {
                Uczen_EdytujImie.Text,
                Uczen_EdytujDrugieImie.Text,
                Uczen_EdytujNazwisko.Text,
                Uczen_EdytujNazwiskoRodowe.Text,
                Uczen_EdytujImieMatki.Text,
                Uczen_EdytujImieOjca.Text,
                Uczen_EdytujDateUrodzenia.Text,
                Uczen_EdytujPesel.Text,
                Uczen_EdytujPlec.Text,
                Uczen_EdytujKlase.Text,
                Uczen_EdytujGrupy.Text
            };

            foreach (string prop in properties)
            {
                if (prop == "")
                {
                    MessageBox.Show("Proszê wype³niæ wszystkie pola!");
                    return;
                }
            }

            string img = Uczen_EdytujZdjecie.Source.ToString()[(Uczen_EdytujZdjecie.Source.ToString().LastIndexOf("/") + 1)..];

            if (img != "IMAGE.png")
                properties.Add(img);

            List<Uczen> AllStudents = GetStudents();

            string StudentsToSave = "";

            foreach (Uczen tempStudent in AllStudents)
            {
                if (StudentToEdit.ToString() == tempStudent.ToString())
                {
                    tempStudent.Imie = properties[0];
                    tempStudent.Imie_drugie = properties[1];
                    tempStudent.Nazwisko = properties[2];
                    tempStudent.Nazwisko_rodowe = properties[3];
                    tempStudent.Imie_matki = properties[4];
                    tempStudent.Imie_ojca = properties[5];
                    tempStudent.Data_urodzenia = properties[6];
                    tempStudent.Pesel = properties[7];
                    tempStudent.Plec = properties[8];
                    tempStudent.Klasa = properties[9];
                    tempStudent.Grupy = properties[10];

                    if (properties.Count == 12)
                        tempStudent.Zdjecie_relative = properties[11];
                }

                StudentsToSave += tempStudent + Environment.NewLine;
            }

            StudentsToSave = StudentsToSave.Trim();

            SaveIntoDatabase("Uczniowie", StudentsToSave, false);

            MessageBox.Show("Uczeñ zosta³ zmodyfikowany!");

            ReportUpdate();
            Sekretariat.SelectedIndex = 0;
        }
    }
}
