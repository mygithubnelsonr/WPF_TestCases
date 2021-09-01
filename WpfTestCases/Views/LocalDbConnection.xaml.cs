using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using WpfTestCases.Model;


namespace WpfTestCases.Views
{
    /// <summary>
    /// Interaction logic for LocalDbConnection.xaml
    /// </summary>
    public partial class LocalDbConnection : Window
    {
        public LocalDbConnection()
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
