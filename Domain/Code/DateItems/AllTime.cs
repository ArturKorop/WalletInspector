using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Code.Factories;
using Domain.Code.Main;

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
    }
}