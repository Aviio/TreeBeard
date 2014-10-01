﻿using System;
using System.IO;
using System.Net;
using Microsoft.SqlServer.Server;
using TreeBeard;
using TreeBeard.Outputs;

public class ElasticSearchOutput : AbstractOutput
{
    private string _uri;

    public override void Execute(Event value)
    {
        string index = string.Format("treebeard-{0:yyyy-MM-dd}", value.EventTimeStamp);
        _uri = string.Format("{0}/{1}/{2}/{3}", _uri, index, value.EventType, value.EventAlias);
        var httpWebRequest = (HttpWebRequest) WebRequest.Create(_uri);
        httpWebRequest.ContentType = "text/json";
        httpWebRequest.Method = "PUT";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
           
            streamWriter.Write(value.AsJson());
            streamWriter.Flush();
            streamWriter.Close();

            var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
            }
        }
    }

    public override void Initialize(params string[] args)
    {
        _uri = args[0];
    }
}