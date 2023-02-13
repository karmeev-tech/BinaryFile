// See https://aka.ms/new-console-template for more information

using Tests;

Metric metric = new();

Task t = metric.Start();
t.Wait();

Console.WriteLine(metric._result);
Console.WriteLine("Затраченное время: " + metric._resultTime);
Console.WriteLine("Размер: {0} ", metric._size);