using java.sql;

namespace Task3Bd.H2
{
    public class ConnectionH2
    {
        private readonly string _url;
        private readonly string _user;
        private readonly string _password;
        private Connection _connection;

        public ConnectionH2(string url, string user, string password)
        {
            _url = url;
            _user = user;
            _password = password;
        }

        public void OpenConnection()
        {
            org.h2.Driver.load();
            _connection = DriverManager.getConnection(_url, _user, _password);
        }

        public Connection GetConnection()
        {
            return _connection;
        }
    }
}
