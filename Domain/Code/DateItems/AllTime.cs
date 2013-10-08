using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Code.DatabaseItems;
using Domain.Code.Factories;

namespace Domain.Code.DateItems
{
    public class AllTime
    {
        public List<Year> Years;

        public AllTime()
        {
            Years = new List<Year>();
        }

        public AllTime(IEnumerable<CostItemForDataBase> costItems)
        {
            Years = new List<Year>();
            var factory = new CostItemFactory();
            foreach (var items in costItems)
            {
                var year = items.Date.Year;
                var tempYear = Years.SingleOrDefault(x => x.Name == year);
                if (tempYear == null)
                {
                    tempYear = new Year(year);
                    Years.Add(tempYear);
                }

                tempYear.AddCostItem(factory.CreateCostItem(items), items.Date);
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