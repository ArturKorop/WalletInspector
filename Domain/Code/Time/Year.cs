using System;
using System.Collections.Generic;
using Domain.Code.General;

namespace Domain.Code.Time
{
    public class Year
    {
        private readonly Month[] _months;

        public int Name { get; private set; }

        public Month[] Months
        {
            get { return _months; }
        }

        public Year(int name)
        {
            if(name < 1900 || name > 2100)
                throw new ArgumentOutOfRangeException("name", "Year must be from 1900 to 2100");

            Name = name;
            _months = new Month[12];
            for (int i = 0; i < 12; i++)
            {
                _months[i] = new Month(Name, i + 1);
            }
        }

        public void AddCostItem(CostItem item)
        {
            if (item.Date.Year != Name)
                throw new ArgumentException("Wrong year","item");

            _months[item.Date.Month - 1].AddCostItem(item);
        }

        public void AddCostItems(IEnumerable<CostItem> items)
        {
            foreach (var item in items)
            {
                AddCostItem(item);
            }
        }

        public Month GetMonth(int monthNumber)
        {
            if(monthNumber < 1 || monthNumber > 12)
                throw new ArgumentOutOfRangeException("monthNumber", "Number of month must be from 1 to 12");

            return _months[monthNumber - 1];
        }
    }
}