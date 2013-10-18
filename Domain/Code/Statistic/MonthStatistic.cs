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
    }
}