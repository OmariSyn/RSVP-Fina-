using RsV__Application_Final;
using SQLite;
using YourAppNamespace.Services;

public partial class App : Application
{
    // Add the missing DatabaseService property to resolve the CS0117 error.
    public static DatabaseService DatabaseService { get; private set; }

    public App()
    {
        object appInitialization = InitializeComponent();

        // Initialize the DatabaseService instance.
        DatabaseService = new DatabaseService();

        MainPage = new NavigationPage(new MainPage());
    }

    private object InitializeComponent()
    {
        throw new NotImplementedException();
    }
}

namespace RsV__Application_Final.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _connection;

        public DatabaseService()
        {
            // Initialize the SQLite connection here.
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserEntries.db3");
            _connection = new SQLiteAsyncConnection(databasePath);
            _connection.CreateTableAsync<Models.UserEntry>().Wait();
        }

        public SQLiteAsyncConnection GetConnection()
        {
            return _connection;
        }
    }
}