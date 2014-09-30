using System;
using System.Net;
using TreeBeard;
using TreeBeard.Outputs;

public class ElasticSearchOutput : AbstractOutput
{
    private Uri _uri;
    public override void Execute(Event value)
    {
        var valueJson = value.AsJson();

        using (WebClient client = new WebClient())
        {
            client.UploadStringAsync(_uri, valueJson);
        };
    }

    public override void Initialize(params string[] args)
    {
        _uri = new UriBuilder(args[0]).Uri;
    }
}

