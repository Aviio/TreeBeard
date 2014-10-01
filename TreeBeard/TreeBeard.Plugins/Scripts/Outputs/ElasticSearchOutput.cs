using System;
using System.IO;
using System.Net;
using Microsoft.SqlServer.Server;
using TreeBeard;
using TreeBeard.Outputs;

/// <summary>
/// Writes event to elasticsearch instance.
/// </summary>
/// <arg name="uri" required="yes" example="http://localhost:9200">URI of elasticsearch instance</arg>
public class ElasticSearchOutput : AbstractOutput
{
    private string _uri;

    public override void Execute(Event value)
    {
        string index = string.Format("treebeard-{0:yyyy-MM-dd}", value.EventTimeStamp);
        _uri = string.Format("{0}/{1}/{2}", _uri, index, value.EventAlias);
        var httpWebRequest = (HttpWebRequest) WebRequest.Create(_uri);
        httpWebRequest.ContentType = "text/json";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
           
            streamWriter.Write(value.AsJson(true));
            streamWriter.Flush();
            streamWriter.Close();

            var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                streamReader.ReadToEnd();
            }
        }
    }

    public override void Initialize(params string[] args)
    {
        _uri = args[0];
    }
}