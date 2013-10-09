using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Domain.Code.DatabaseItems;
using Domain.Code.General;

namespace Domain.Code.Time
{
    public class Day
    {
        public List<CostItem> CostItems { get;private set; }

        public DateTime Date { get;private set; }

        public string Name { get;private set; }

        public Day(DateTime date)
        {
            Date = date;
            Name = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(Date.DayOfWeek);
            CostItems = new List<CostItem>();
        }

        public void Add(CostItem costItem)
        {
            CostItems.Add(costItem);
        }

        public void Remove(CostItem costItem)
        {
            CostItems.Remove(costItem);
        }

        public void Remove(int id)
        {
            CostItems.Remove(CostItems.Single(x => x.Id == id));
        }
    }
}