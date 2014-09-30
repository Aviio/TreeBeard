###Description

Log/event management tool that resembles [logstash](http://logstash.net/) but written entirely in C# for .NET/Windows environments.

### Useful pages

* [Projects](https://github.com/csuzw/TreeBeard/wiki/Projects)
* [Configuration Types](https://github.com/csuzw/TreeBeard/wiki/Configuration-Types)
* [Plugins](https://github.com/csuzw/TreeBeard/wiki/Plugins)
* [Filter Predicates](https://github.com/csuzw/TreeBeard/wiki/Filter-Predicates)

### Example
```C#
IConfiguration configuration = new JsonConfiguration(args[0]);
using (EventHerder eventHerder = new EventHerder(configuration))
{
  Console.WriteLine("Press ENTER to exit...");
  Console.ReadLine();
}
```
