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
        private List<Nauczyciel> GetTeachers()
        {
            teachers.Clear();

            string path = Path.Combine(Directory.GetCurrentDirectory(), @"baza_danych\Nauczyciele.txt");
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

                            var teacher = new Nauczyciel()
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
                                Wychowawstwo = Convert.ToBoolean(pola[9]),
                                Przedmioty = pola[10],
                                Ile_naucza = pola[11],
                                Data_zatrudnienia = pola[12],
                                Zdjecie_absolute = null,
                                Zdjecie_relative = null
                            };

                            teacher.Zdjecie_relative = (pola.Count == 14)
                                ? pola[13]
                                : null;

                            teacher.Zdjecie_absolute = (teacher.Zdjecie_relative != null)
                                ? Path.Combine(Directory.GetCurrentDirectory(), @"zdjecia\" + teacher.Zdjecie_relative)
                                : NoImage;

                            teachers.Add(teacher);
                        }
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Chwilka na domknięcie pliku!");
                }
                
                if (clearFile)
                    File.Create(path);
            }
            return teachers;
        }

        private List<Nauczyciel> SearchTeachers()
        {
            bool error = false;

            teachers.Clear();

            string path = Path.Combine(Directory.GetCurrentDirectory(), @"baza_danych\Nauczyciele.txt");
            bool clearFile = false;

            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader reader = File.OpenText(path))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null && !error)
                        {
                            if (line == "")
                            {
                                clearFile = true;
                                break;
                            }

                            var pola = line.Split("\t").ToList();

                            var teacher = new Nauczyciel()
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
                                Wychowawstwo = Convert.ToBoolean(pola[9]),
                                Przedmioty = pola[10],
                                Ile_naucza = pola[11],
                                Data_zatrudnienia = pola[12],
                                Zdjecie_absolute = null,
                                Zdjecie_relative = null
                            };

                            teacher.Zdjecie_relative = (pola.Count == 12)
                                ? pola[11]
                                : null;

                            teacher.Zdjecie_absolute = (teacher.Zdjecie_relative != null)
                                ? Path.Combine(Directory.GetCurrentDirectory(), @"zdjecia\" + teacher.Zdjecie_relative)
                                : NoImage;

                            bool toShow = false;

                            if (Nauczyciele_SearchColNum.SelectedIndex != 6 && Nauczyciele_SearchColNum.SelectedIndex != 11 && Nauczyciele_SearchColNum.SelectedIndex != 12 && Nauczyciele_SearchText.Text != null)
                            {
                                switch (Nauczyciele_SearchColNum.SelectedIndex)
                                {
                                    case 0:
                                        {
                                            if (teacher.Imie.Equals(Nauczyciele_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 1:
                                        {
                                            if (teacher.Imie_drugie.Equals(Nauczyciele_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 2:
                                        {
                                            if (teacher.Nazwisko.Equals(Nauczyciele_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 3:
                                        {
                                            if (teacher.Nazwisko_rodowe.Equals(Nauczyciele_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 4:
                                        {
                                            if (teacher.Imie_matki.Equals(Nauczyciele_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 5:
                                        {
                                            if (teacher.Imie_ojca.Equals(Nauczyciele_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 7:
                                        {
                                            if (teacher.Pesel.Equals(Nauczyciele_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 8:
                                        {
                                            if (teacher.Plec.Equals(Nauczyciele_SearchText.Text))
                                                toShow = true;
                                            break;
                                        }
                                    case 9:
                                        {
                                            try
                                            {
                                                if (teacher.Wychowawstwo.Equals(Convert.ToBoolean(Nauczyciele_SearchText.Text)))
                                                    toShow = true;
                                            }
                                            catch (FormatException)
                                            {
                                                MessageBox.Show("Wychowawstwo przyjmuje tylko wartoci True lub False!");
                                                error = true;
                                            }
                                            break;
                                        }
                                    case 10:
                                        {
                                            if (teacher.Przedmioty.Equals(Nauczyciele_SearchText.Text))
                                            {
                                                toShow = true;
                                                break;
                                            }

                                            string[] subjects = teacher.Przedmioty.Split(", ");
                                            bool anySubjectGood = false;

                                            foreach (string subject in subjects)
                                            {
                                                if (subject.Equals(Nauczyciele_SearchText.Text))
                                                {
                                                    anySubjectGood = true;
                                                    break;
                                                }
                                            }

                                            if (anySubjectGood)
                                                toShow = true;

                                            break;
                                        }
                                }
                            }
                            else if (Nauczyciele_SearchColNum.SelectedIndex == 11 && Nauczyciele_SearchHoursNum != null)
                            {
                                try
                                {
                                    int searchHours = int.Parse(Nauczyciele_SearchHoursNum.Text);

                                    int sumOfHours = 0;

                                    string[] classes = teacher.Ile_naucza.Split(", ");

                                    foreach (string c in classes)
                                    {
                                        sumOfHours += int.Parse(c.Split(" ")[1]);
                                    }

                                    switch (Nauczyciele_SearchHours.SelectedIndex)
                                    {
                                        case 0:
                                            toShow = sumOfHours < searchHours;
                                            break;

                                        case 1:
                                            toShow = sumOfHours <= searchHours;
                                            break;

                                        case 2:
                                            toShow = searchHours < sumOfHours;
                                            break;

                                        case 3:
                                            toShow = searchHours <= sumOfHours;
                                            break;

                                        case 4:
                                            toShow = sumOfHours == searchHours;
                                            break;
                                    }
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Niepoprawna liczba!");
                                    error = true;
                                }
                            }
                            else if ((Nauczyciele_SearchColNum.SelectedIndex == 6 || Nauczyciele_SearchColNum.SelectedIndex == 12) && Nauczyciele_SelectedDate.SelectedDate != null)
                            {
                                DateTime teacherDate;

                                if (Nauczyciele_SearchColNum.SelectedIndex == 6)
                                    teacherDate = DateTime.Parse(teacher.Data_urodzenia);
                                else
                                    teacherDate = DateTime.Parse(teacher.Data_zatrudnienia);

                                DateTime selectedDate = (DateTime)Nauczyciele_SelectedDate.SelectedDate;

                                switch (Nauczyciele_SearchForDate.SelectedIndex)
                                {
                                    case 0:
                                        toShow = teacherDate < selectedDate;
                                        break;

                                    case 1:
                                        toShow = teacherDate <= selectedDate;
                                        break;

                                    case 2:
                                        toShow = selectedDate < teacherDate;
                                        break;

                                    case 3:
                                        toShow = selectedDate <= teacherDate;
                                        break;

                                    case 4:
                                        toShow = teacherDate == selectedDate;
                                        break;
                                }
                            }

                            if (toShow)
                                teachers.Add(teacher);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Chwilka na domknięcie pliku!");
                }

                if (clearFile)
                    File.Create(path);
            }

            return teachers;
        }

        private void Nauczyciele_ClearSortButtonClick(object sender, RoutedEventArgs e) => ClearSortNauczyciele();

        private void ClearSortNauczyciele()
        {
            Nauczyciele_SortColNum.SelectedIndex = 0;
            Nauczyciele_SortAscDesc.SelectedIndex = 0;
            ClearSortDataGrid(DG_Dane_Nauczyciele);
        }

        private void Nauczyciele_ComboBoxChange(object sender, SelectionChangedEventArgs e)
        {
            var CB = sender as ComboBox;

            Nauczyciele_SearchText.IsEnabled = CB.SelectedIndex != 6 && CB.SelectedIndex != 11 && CB.SelectedIndex != 12;
            Nauczyciele_SearchHours.IsEnabled = CB.SelectedIndex == 11;
            Nauczyciele_SearchHoursNum.IsEnabled = CB.SelectedIndex == 11;
            Nauczyciele_SearchForDate.IsEnabled = CB.SelectedIndex == 6 || CB.SelectedIndex == 12;
            Nauczyciele_SelectedDate.IsEnabled = CB.SelectedIndex == 6 || CB.SelectedIndex == 12;

            Nauczyciele_SearchText.Text = "";
            Nauczyciele_SearchHours.SelectedIndex = 0;
            Nauczyciele_SearchHoursNum.Text = "";
            Nauczyciele_SearchForDate.SelectedIndex = 0;
            Nauczyciele_SelectedDate.SelectedDate = default;
        }

        private void SearchNauczyciele(object sender, RoutedEventArgs e)
        {
            ClearSortNauczyciele();
            DG_Dane_Nauczyciele.ItemsSource = SearchTeachers();
            DG_Dane_Nauczyciele.Items.Refresh();
        }

        private void ClearSearchNauczyciele(object sender, RoutedEventArgs e)
        {
            ClearSortNauczyciele();
            Nauczyciele_SearchColNum.SelectedIndex = 0;
            Nauczyciele_SearchText.IsEnabled = true;
            Nauczyciele_SearchText.Text = "";
            Nauczyciele_SearchForDate.IsEnabled = false;
            Nauczyciele_SearchForDate.SelectedIndex = 0;
            ReportUpdate();
        }

        private void Nauczyciele_SortButtonClick(object sender, RoutedEventArgs e) => SortNauczyciele();

        private void SortNauczyciele()
        {
            if (Nauczyciele_SortColNum.SelectedItem != null && Nauczyciele_SortAscDesc.SelectedItem != null)
                SortDataGrid(DG_Dane_Nauczyciele,
                    Nauczyciele_SortColNum.SelectedIndex + 2,
                    (Nauczyciele_SortAscDesc.SelectedIndex == 0)
                        ? ListSortDirection.Ascending
                        : ListSortDirection.Descending
                );
        }

        private void AddTeacher()
        {
            List<string> properties = new List<string>()
            {
                Nauczyciel_DodajImie.Text,
                Nauczyciel_DodajDrugieImie.Text,
                Nauczyciel_DodajNazwisko.Text,
                Nauczyciel_DodajNazwiskoRodowe.Text,
                Nauczyciel_DodajImieMatki.Text,
                Nauczyciel_DodajImieOjca.Text,
                Nauczyciel_DodajDateUrodzenia.Text,
                Nauczyciel_DodajPesel.Text,
                Nauczyciel_DodajPlec.Text,
                Nauczyciel_DodajWychowawstwo.IsChecked.ToString(),
                Nauczyciel_DodajPrzedmioty.Text,
                Nauczyciel_DodajIleNaucza.Text,
                Nauczyciel_DodajDateZatrudnienia.Text
            };

            string teacherProperties = "";

            foreach (string prop in properties)
            {
                if (prop == "")
                {
                    MessageBox.Show("Proszę wypełnić wszystkie pola!");
                    return;
                }

                teacherProperties += prop + "\t";
            }

            teacherProperties = teacherProperties.Trim();

            string img = Nauczyciel_Zdjecie.Source.ToString()[(Nauczyciel_Zdjecie.Source.ToString().LastIndexOf("/") + 1)..];

            if (img != "IMAGE.png")
                teacherProperties += "\t" + img;

            SaveIntoDatabase("Nauczyciele", teacherProperties, true);

            MessageBox.Show("Nauczyciel dodany do bazy danych!");
        }

        private void DeleteTeacher(Nauczyciel TeacherToDelete)
        {
            List<Nauczyciel> AllTeachers = GetTeachers();

            string TeachersToSave = "";

            foreach (Nauczyciel tempTeacher in AllTeachers)
            {
                if (TeacherToDelete.ToString() != tempTeacher.ToString())
                    TeachersToSave += tempTeacher.ToString() + Environment.NewLine;
            }

            TeachersToSave = TeachersToSave.Trim();

            SaveIntoDatabase("Nauczyciele", TeachersToSave, false);

            ReportUpdate();
        }

        private void EditTeacher(Nauczyciel TeacherToEdit)
        {
            List<string> properties = new List<string>()
            {
                Nauczyciel_EdytujImie.Text,
                Nauczyciel_EdytujDrugieImie.Text,
                Nauczyciel_EdytujNazwisko.Text,
                Nauczyciel_EdytujNazwiskoRodowe.Text,
                Nauczyciel_EdytujImieMatki.Text,
                Nauczyciel_EdytujImieOjca.Text,
                Nauczyciel_EdytujDateUrodzenia.Text,
                Nauczyciel_EdytujPesel.Text,
                Nauczyciel_EdytujPlec.Text,
                Nauczyciel_EdytujWychowawstwo.IsChecked.ToString(),
                Nauczyciel_EdytujPrzedmioty.Text,
                Nauczyciel_EdytujIleNaucza.Text,
                Nauczyciel_EdytujDateZatrudnienia.Text
            };

            foreach (string prop in properties)
            {
                if (prop == "")
                {
                    MessageBox.Show("Proszę wypełnić wszystkie pola!");
                    return;
                }
            }

            string img = Nauczyciel_EdytujZdjecie.Source.ToString()[(Nauczyciel_EdytujZdjecie.Source.ToString().LastIndexOf("/") + 1)..];

            if (img != "IMAGE.png")
                properties.Add(img);

            List<Nauczyciel> AllTeachers = GetTeachers();

            string TeachersToSave = "";

            foreach (Nauczyciel tempTeacher in AllTeachers)
            {
                if (TeacherToEdit.ToString() == tempTeacher.ToString())
                {
                    tempTeacher.Imie = properties[0];
                    tempTeacher.Imie_drugie = properties[1];
                    tempTeacher.Nazwisko = properties[2];
                    tempTeacher.Nazwisko_rodowe = properties[3];
                    tempTeacher.Imie_matki = properties[4];
                    tempTeacher.Imie_ojca = properties[5];
                    tempTeacher.Data_urodzenia = properties[6];
                    tempTeacher.Pesel = properties[7];
                    tempTeacher.Plec = properties[8];
                    tempTeacher.Wychowawstwo = bool.Parse(properties[9]);
                    tempTeacher.Przedmioty = properties[10];
                    tempTeacher.Ile_naucza = properties[11];
                    tempTeacher.Data_zatrudnienia = properties[12];

                    if (properties.Count == 14)
                        tempTeacher.Zdjecie_relative = properties[13];
                }

                TeachersToSave += tempTeacher.ToString() + Environment.NewLine;
            }

            TeachersToSave = TeachersToSave.Trim();

            SaveIntoDatabase("Nauczyciele", TeachersToSave, false);

            MessageBox.Show("Nauczyciel został zmodyfikowany!");

            ReportUpdate();
            Sekretariat.SelectedIndex = 1;
        }
    }
}
