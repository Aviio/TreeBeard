using System.Data.SqlClient;
using TreeBeard;
using TreeBeard.Extensions;
using TreeBeard.Outputs;

/// <summary>
/// Write events to SqlServer table. The table must have the following columns: Type (varchar), Alias (varchar), TimeStamp (datetime), XML (xml). If username and password are not supplied, windows authentication will be applied instead.
/// </summary>
/// <arg name="uri" required="yes" example="127.0.0.1">URI of SQL Server instance.</arg>
/// <arg name="database" required="yes" example="database">Database name</arg>
/// <arg name="table" required="yes" example="table">Table name</arg>
/// <arg name="username" required="no" example="username">Username</arg>
/// <arg name="password" required="no" example="password">Password</arg>
public class SqlServerOutput : AbstractOutput
{
    private string _connectionString;
    private string _queryString;

    public override void Execute(Event value)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            using (SqlCommand command = new SqlCommand(_queryString, connection))
            {
                command.Parameters.AddWithValue("@type", value.EventType);
                command.Parameters.AddWithValue("@alias", value.EventAlias);
                command.Parameters.AddWithValue("@timeStamp", value.EventTimeStamp);
                command.Parameters.AddWithValue("@xml", value.AsXml());

                connection.Open();
                this.Log().Info("SQL connection init");
                command.ExecuteNonQuery();
            }
        }
    }

    public override void Initialize(params string[] args)
    {
        this.Log().Info("Initialized SQL Server Plugin");
        string uri = args[0];
        string database = args[1];
        string userName = (args.Length > 3) ? args[3] : string.Empty;
        string password = (args.Length > 4) ? args[4] : string.Empty;

        _connectionString = GetConnectionString(uri, database, userName, password);
        //TABLE SCHEMA: TYPE | ALIAS | TIMESTAMP | XML
        _queryString = string.Format(@"INSERT INTO {0} (Type, Alias, TimeStamp, XML) VALUES (@type, @alias, @timeStamp, @xml)", args[2]);
    }

    private string GetConnectionString(string uri, string database, string userName = null, string password = "")
    {
        string connectionString = string.Format("Data Source={0};Initial Catalog={1};", uri, database);
        if (string.IsNullOrEmpty(userName))
        {
            connectionString += "Integrated Security=SSPI";
        }
        else
        {
            connectionString += string.Format("User id={0};Password={1}", userName, password);
        }
        return connectionString;
    }
}
