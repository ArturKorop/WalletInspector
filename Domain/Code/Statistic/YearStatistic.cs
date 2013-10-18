using System.Linq;
using Domain.Code.Time;

namespace Domain.Code.Statistic
{
    public class YearStatistic
    {
        private readonly Year _year;

        public YearStatistic(Year year)
        {
            _year = year;
        }

        public double GetYearTotalSum()
        {
            return _year.Months.Sum(month => month.Statistic.GetMonthTotalSum());
        }
    }
}