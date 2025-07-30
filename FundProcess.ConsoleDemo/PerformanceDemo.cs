using System;
using System.Collections.Generic;
using FundProcess.Lib;

class Program
{
    static void Main(string[] args)
    {
        var dataset = new[]
            {
                Tuple.Create(new DateTime(2020, 1, 1), 100.0),
                Tuple.Create(new DateTime(2020, 6, 1), 120.0),
                Tuple.Create(new DateTime(2020, 12, 31), 150.0),
            };

        var from = new DateTime(2019, 01, 01);
        var to = new DateTime(2024, 06, 01);

        var service = new PerformanceService();
        double performance = service.GetPerformance(dataset, from, to);

        Console.WriteLine($"Performance: {performance:P2}");
    }
}
