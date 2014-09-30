using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using TreeBeard.Extensions;
using TreeBeard.Outputs;

namespace TreeBeard.Plugins.Scripts.Outputs
{
    public class SqlServerOutput : AbstractOutput
    {

        private string _uri;
        private string _database;
        private string _table;
        private string _userName;
        private string _password;


       

        public override void Execute(Event value)
        {
            
            using (SqlConnection connection = GetConnection())
            
            {

                //TABLE SCHEMA TREEBEARDDEV: ID | TYPEID | TYPE | TIMESTAMP | XML
                
                var xmlResults = value.AsXml();
                var type = value.Type;
                var typeId = value.Id; //TODO:Change to TypeID
                var timeStamp = value.TimeStamp;

                var insertQuery = string.Format(@"INSERT INTO {0} (TypeId, Type, TimeStamp, XML) VALUES @typeId, @type, @timeStamp, @xml", _table);

                var command = new SqlCommand(insertQuery);
                command.Parameters.AddWithValue("@typeId", typeId);
                command.Parameters.AddWithValue("@type", type);
                command.Parameters.AddWithValue("@timeStamp", timeStamp);
                command.Parameters.AddWithValue("@xml", xmlResults);

                connection.Open();
                this.Log().Info("SQL connection init");
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                
                
            }

        }

        public override void Initialize(params string[] args)
        {
            this.Log().Info("Initialized SQL Server Plugin");
            _uri = args[0];
            _database = args[1];
            _table = args[2];
            if (args.Length > 2)
            {
                this.Log().Info("args > 2");
                _userName = args[3];
                _password = args[4];
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
    }
}

