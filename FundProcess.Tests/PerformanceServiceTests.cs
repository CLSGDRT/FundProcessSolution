using System;
using Xunit;
using FundProcess.Lib;

namespace FundProcess.Tests
{
    public class PerformanceServiceTests
    {
        private readonly PerformanceService _service = new();

        [Fact]
        public void Calculates_Correct_Performance()
        {
            var dataset = new[]
            {
                Tuple.Create(new DateTime(2020, 1, 1), 100.0),
                Tuple.Create(new DateTime(2020, 6, 1), 120.0),
                Tuple.Create(new DateTime(2020, 12, 31), 150.0),
            };

            double result = _service.GetPerformance(dataset, new DateTime(2020, 1, 1), new DateTime(2020, 12, 31));
            Assert.Equal(0.5, result); // (150 / 100) - 1 = 0.5
        }

        [Fact]
        public void Throws_If_EmptyDataset()
        {
            var dataset = Array.Empty<Tuple<DateTime, double>>();
            Assert.Throws<ArgumentException>(() =>
                _service.GetPerformance(dataset, DateTime.Now.AddDays(-1), DateTime.Now));
        }

        [Fact]
        public void Throws_If_NotEnoughData()
        {
            var dataset = new[]
            {
                Tuple.Create(new DateTime(2020, 1, 1), 100.0),
            };
            Assert.Throws<InvalidOperationException>(() =>
                _service.GetPerformance(dataset, new DateTime(2020, 1, 1), new DateTime(2020, 12, 31)));
        }

        [Fact]
        public void Throws_If_FirstValueZero()
        {
            var dataset = new[]
            {
                Tuple.Create(new DateTime(2020, 1, 1), 0.0),
                Tuple.Create(new DateTime(2020, 12, 31), 150.0),
            };
            Assert.Throws<DivideByZeroException>(() =>
                _service.GetPerformance(dataset, new DateTime(2020, 1, 1), new DateTime(2020, 12, 31)));
        }
    }
}

