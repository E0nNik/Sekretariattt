using System.Windows.Input;

namespace Sekretariat
{
    public static class CustomShortcuts
    {
        public static RoutedUICommand OpenStudents = new RoutedUICommand
            (
                "Otwórz uczniów",
                "OpenStudents",
                typeof(CustomShortcuts),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.U, ModifierKeys.Control)
                }
            );

        public static RoutedUICommand OpenTeachers = new RoutedUICommand
            (
                "Otwórz nauczycieli",
                "OpenTeachers",
                typeof(CustomShortcuts),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.N, ModifierKeys.Control)
                }
            );

        public static RoutedUICommand OpenStaffMembers = new RoutedUICommand
            (
                "Otwórz pracowników obsługi",
                "OpenStaffMembers",
                typeof(CustomShortcuts),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.P, ModifierKeys.Control)
                }
            );

        public static RoutedUICommand OpenShortcuts = new RoutedUICommand
            (
                "Otwórz edytor skrótów klawiszowych",
                "OpenShortcuts",
                typeof(CustomShortcuts),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.E, ModifierKeys.Control)
                }
            );

        public static RoutedUICommand OpenAddStudent = new RoutedUICommand
            (
                "Otwórz dodawanie uczniów",
                "OpenAddStudent",
                typeof(CustomShortcuts),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.U, ModifierKeys.Control | ModifierKeys.Shift)
                }
            );

        public static RoutedUICommand OpenAddTeacher = new RoutedUICommand
            (
                "Otwórz dodawanie nauczycieli",
                "OpenAddTeacher",
                typeof(CustomShortcuts),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.N, ModifierKeys.Control | ModifierKeys.Shift)
                }
            );

        public static RoutedUICommand OpenAddStaffMember = new RoutedUICommand
            (
                "Otwórz dodawanie pracowników obsługi",
                "OpenAddStaffMember",
                typeof(CustomShortcuts),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.P, ModifierKeys.Control | ModifierKeys.Shift)
                }
            );

        public static RoutedUICommand LoadFromFileToDB = new RoutedUICommand
            (
                "Wczytaj z pliku do bazy",
                "LoadFromFileToDB",
                typeof(CustomShortcuts),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.O, ModifierKeys.Control)
                }
            );

        public static RoutedUICommand ImportImage = new RoutedUICommand
            (
                "Dodaj zdjęcie do bazy",
                "ImportImage",
                typeof(CustomShortcuts),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.I, ModifierKeys.Control)
                }
            );

        public static RoutedUICommand GenerateWindowReport = new RoutedUICommand
            (
                "Generuj raport tego okna",
                "GenerateWindowReport",
                typeof(CustomShortcuts),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.L, ModifierKeys.Control)
                }
            );

        public static RoutedUICommand GenerateAllDBReport = new RoutedUICommand
            (
                "Generuj raport całej bazy",
                "GenerateAllDBReport",
                typeof(CustomShortcuts),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.G, ModifierKeys.Control)
                }
            );
    }
}
