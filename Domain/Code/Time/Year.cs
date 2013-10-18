using System;
using System.Collections.Generic;
using Domain.Code.General;
using Domain.Code.Statistic;

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

        public YearStatistic Statistic { get; private set; }

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
            Statistic = new YearStatistic(this);
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

        /// <summary>
        /// Return <see cref="Month"/> where MonthNumber from 1 to 12
        /// </summary>
        /// <param name="monthNumber">Number of month, which must be return</param>
        /// <returns><see cref="Month"/> which number was inputed</returns>
        public Month GetMonth(int monthNumber)
        {
            if(monthNumber < 1 || monthNumber > 12)
                throw new ArgumentOutOfRangeException("monthNumber", "Number of month must be from 1 to 12");

            return _months[monthNumber - 1];
        }
    }
}