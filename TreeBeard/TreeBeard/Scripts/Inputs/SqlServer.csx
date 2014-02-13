using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reactive.Linq;
using TreeBeard.Events;
using TreeBeard.Inputs;
using TreeBeard.Interfaces;

public class SqlServerInput : AbstractInput
{
    private string _uri;
    private string _database;
    private string _table;
    private string _idColumn;
    private string _timeStampColumn;
    private string _userName;
    private string _password;

    private SqlConnection _connection;
    private int _lastId;

    public override void Initialize(params string[] args)
    {
        _uri = args[0];
        _database = args[1];
        _table = args[2];
        _idColumn = args[3];
        _timeStampColumn = args[4];
        if (args.Length > 5)
        {
            _userName = args[5];
            _password = args[6];
        }
    }

    public override IObservable<IEvent> Execute()
    {
        return Observable.Interval(TimeSpan.FromSeconds(1)).SelectMany(_ => GetEvents());
    }

    private IEnumerable<IEvent> GetEvents()
    {
        if (_connection == null)
        {
            _connection = GetConnection();
            _lastId = 0;
        }
        if (_connection.State == ConnectionState.Closed)
        {
            _connection.Open();
            _lastId = 0;
        }
        if (_lastId <= 0)
        {
            _lastId = GetLastId();
        }

        string sql = string.Format("SELECT * FROM {0} WHERE {1} > @0 ORDER BY {1} DESC", _table, _idColumn);
        using (SqlCommand command = new SqlCommand(sql, _connection))
        {
            command.Parameters.Add("@0", SqlDbType.Int).Value = _lastId;

            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    int lastId = _lastId;
                    DateTime timeStamp = DateTime.Now;
                    string message = "";
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        if (!string.IsNullOrEmpty(message)) message += ",";
                        message += string.Format("{0}:\"{1}\"", column.ColumnName, row[column]);

                        if (column.ColumnName == _idColumn) lastId = Convert.ToInt32(row[column]);
                        if (column.ColumnName == _timeStampColumn) timeStamp = Convert.ToDateTime(row[column]);
                    }
                    message = "{" + message + "}";
                    yield return new Event(Type, Id, message, timeStamp);
                    _lastId = lastId;
                }
            }
        }
    }

    private SqlConnection GetConnection()
    {
        string connectionString = string.Format("Data Source={0};Initial Catalog={1};", _uri, _database);
        if (string.IsNullOrEmpty(_userName))
        {
            connectionString += "Integrated Security=SSPI";
        }
        else
        {
            connectionString += string.Format("User id={0};Password={1}", _userName, _password);
        }

        return new SqlConnection(connectionString);
    }

    private int GetLastId()
    {
        string sql = string.Format("SELECT MAX({0}) FROM {1}", _idColumn, _table);
        using (SqlCommand command = new SqlCommand(sql, _connection))
        {
            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
