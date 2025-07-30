namespace FundProcess.Lib
{
    public class PerformanceService : IPerformanceService
    {
        public double GetPerformance(Tuple<DateTime, double>[] dataset, DateTime fromDate, DateTime toDate)
        {
            if (dataset == null || dataset.Length == 0)
                throw new ArgumentException("Aucune donnée !");

            var filtered = dataset
                .Where(x => x.Item1 >= fromDate && x.Item1 <= toDate)
                .OrderBy(x => x.Item1)
                .ToArray();

            if (filtered.Length < 2)
                throw new InvalidOperationException("Pas assez de points");

            double firstValue = filtered.First().Item2;
            double lastValue = filtered.Last().Item2;

            if (firstValue == 0)
                throw new DivideByZeroException("Impossible de diviser par 0");

            return (lastValue / firstValue) - 1;
        }
    }
}
