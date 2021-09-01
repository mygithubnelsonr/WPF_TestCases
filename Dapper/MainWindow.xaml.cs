using System.Configuration;
using System.Windows;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using Data.DapperSample.Model;

namespace Data.DapperSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            string connection = GetConnectionString("MyJukebox");
            var conn = new SqlConnection(connection);

            #region hardcoded connection

            //conn.ConnectionString =
            //              "Server=(LocalDb)\\MSSQLLocalDb;" +
            //              "Initial Catalog=MyJukebox;" +
            //              "Integrated Security=true;";
            //conn.Open();
            //conn.Close();
            #endregion

            var genres = conn.Query<Genre>("select * from dbo.tgenres");
            listbox.ItemsSource = genres;
        }

        public string GetConnectionString(string name = "MyJukebox")
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
