using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reactive.Linq;
using TreeBeard;
using TreeBeard.Inputs;

public class SqlServerInput : AbstractInputWithPosition<int>
{
    private string _idColumn;
    private string _timeStampColumn;
    private string _connectionString;
    private string _queryEventsString;
    private string _queryLastIdString;

    public override void Initialize(params string[] args)
    {
        string uri = args[0];
        string database = args[1];
        string table = args[2];
        string userName = (args.Length > 5) ? args[5] : string.Empty;
        string password = (args.Length > 6) ? args[6] : string.Empty;

        _idColumn = args[3];
        _timeStampColumn = args[4];
        _connectionString = GetConnectionString(uri, database, userName, password);
        _queryEventsString = string.Format("SELECT * FROM {0} WHERE {1} > @0 ORDER BY {1} DESC", table, _idColumn);
        _queryLastIdString = string.Format("SELECT MAX({0}) FROM {1}", _idColumn, table);

        InitPosition(GetLastId());
    }

    public override IObservable<Event> Execute()
    {
        return Observable.Interval(TimeSpan.FromSeconds(1)).SelectMany(_ => GetEvents());
    }

    private IEnumerable<Event> GetEvents()
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            using (SqlCommand command = new SqlCommand(_queryEventsString, connection))
            {
                command.Parameters.Add("@0", SqlDbType.Int).Value = GetPosition();
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        int position = GetPosition();
                        dynamic ev = new Event(Type, Alias);
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            ev.SetMember(column.ColumnName.ToLower(), row[column]);

                            if (column.ColumnName == _idColumn) position = Convert.ToInt32(row[column]);
                            if (column.ColumnName == _timeStampColumn) ev.TimeStamp = Convert.ToDateTime(row[column]);
                        }
                        yield return ev;
                        SetPosition(position);
                    }
                }
            }
        }
    }

    private int GetLastId()
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            using (SqlCommand command = new SqlCommand(_queryLastIdString, connection))
            {
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
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