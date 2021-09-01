using System.Windows.Input;

namespace WPFMediaplayerDapper
{
    public static class TestcaseCommands
    {
        private static RoutedUICommand copyDataRow;

        static TestcaseCommands()
        {
            copyDataRow = new RoutedUICommand("Copy Datarow", "CopyDataRow", typeof(TestcaseCommands));
        }

        public static RoutedUICommand CopyDataRow
        {
            get { return copyDataRow; }
        }

    }
}
