using System.Collections.Generic;
using System.Linq;
using Domain.Code.Time;

namespace Domain.Code.Statistic
{
    public class MonthStatistic
    {
        private readonly Month _month;

        public MonthStatistic(Month month)
        {
            _month = month;
        }

        public double GetMonthTotalSum()
        {
            return _month.Days.SelectMany(day => day.CostItems).Sum(item => item.Price);
        }

        public Dictionary<string, double> GetEachCostItemStatistic()
        {
            var result = new Dictionary<string, double>();
            foreach (var costItem in _month.Days.SelectMany(day => day.CostItems))
            {
                if (result.ContainsKey(costItem.Name))
                    result[costItem.Name] += costItem.Price;
                else
                    result.Add(costItem.Name, costItem.Price);
            }

            return result;
        }

        public Dictionary<string, double> GetEachTagStatistic()
        {
            var result = new Dictionary<string, double>();
            foreach (var costItem in _month.Days.SelectMany(day => day.CostItems))
            {
                if (result.ContainsKey(costItem.TagNames[0]))
                    result[costItem.TagNames[0]] += costItem.Price;
                else
                    result.Add(costItem.TagNames[0], costItem.Price);
            }

            return result;
        }
    }
}