using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Domain.Code.Main;

namespace Domain.Code.DateItems
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

        public void Add(CostItem costItemForDataBase)
        {
            CostItems.Add(costItemForDataBase);
        }

        public void Remove(CostItem costItemForDataBase)
        {
            CostItems.Remove(costItemForDataBase);
        }

        public void Remove(string name, int price)
        {
            CostItems.Remove(CostItems.Single(x => x.Price == price && x.Name == name));
        }
    }
}