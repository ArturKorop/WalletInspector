using System;
using System.Collections.Generic;
using System.Globalization;
using Domain.Code.General;
using Domain.Code.Statistic;

namespace Domain.Code.Time
{
    public class Month
    {
        private readonly Day[] _days;
        private readonly int _daysInMonth;

        public string Name { get; private set; }
        public int MonthNumber { get; private set; }
        public int ThisYear { get;private set; }
        public MonthStatistic Statistic { get; private set; }

        public Day[] Days
        {
            get
            {
                return _days;
            }
        }

        public Day GetDay(int dayNumber)
        {
            if (dayNumber < 1 || dayNumber > _daysInMonth)
                throw new ArgumentOutOfRangeException("dayNumber",
                                                      String.Format("Day number must be from 1 to {0}", _daysInMonth));

            return _days[dayNumber - 1];
        }

        public Month(int yearName, int monthNumber)
        {
            ThisYear = yearName;
            MonthNumber = monthNumber;
            Name = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MonthNumber);
            _daysInMonth = DateTime.DaysInMonth(yearName, monthNumber);
            _days = new Day[_daysInMonth];
            for (int i = 0; i < _daysInMonth; i++)
            {
                _days[i] = new Day(new DateTime(yearName, monthNumber, i + 1));
            }
            Statistic = new MonthStatistic(this);
        }

        public void AddCostItem(CostItem item)
        {
            if (item.Date.Year != ThisYear || item.Date.Month != MonthNumber)
                throw new ArgumentException("Wrong month", "item");

            _days[item.Date.Day - 1].Add(item);
        }

        public void AddCostItems(IEnumerable<CostItem> items)
        {
            foreach (var item in items)
            {
                AddCostItem(item);
            }
        }
    }
}