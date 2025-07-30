namespace FundProcess.Lib
{
    public interface IPerformanceService
    {
        double GetPerformance(Tuple<DateTime, double>[] dataset, DateTime fromDate, DateTime toDate);
    }
}

