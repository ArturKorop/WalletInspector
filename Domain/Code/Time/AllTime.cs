using System.Collections.Generic;
using System.Linq;
using Domain.Code.DatabaseItems;
using Domain.Code.General;

namespace Domain.Code.Time
{
    public class AllTime
    {
        public List<Year> Years;

        public AllTime()
        {
            Years = new List<Year>();
        }

        public AllTime(IEnumerable<CostItem> costItems)
        {
            Years = new List<Year>();
            foreach (var items in costItems)
            {
                var year = items.Date.Year;
                var tempYear = Years.SingleOrDefault(x => x.Name == year);
                if (tempYear == null)
                {
                    tempYear = new Year(year);
                    Years.Add(tempYear);
                }

                tempYear.AddCostItem(items, items.Date);
            }
        }

        public Year GetYear(int yearName)
        {
            var year = Years.SingleOrDefault(x => x.Name == yearName) ?? new Year(yearName);

            return year;
        }

        public Day GetDay(int year, int month, int day)
        {
            var yearTemp = Years.SingleOrDefault(x => x.Name == year) ?? new Year(year);
            var monthTemp = yearTemp.GetMonth(month);
            var dayTemp = monthTemp.GetDay(day);

            return dayTemp;
        }
    }
}