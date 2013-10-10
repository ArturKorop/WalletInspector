using System;
using System.Globalization;
using Domain.Code.DatabaseItems;
using Domain.Code.General;

namespace Domain.Code.Time
{
    public class Month
    {
        private readonly Day[] _days;
        private readonly int _daysInMonth;

        public string Name { get; private set; }
        public int MonthNumber { get; private set; }
        public int ThisYear { get;private set; }

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
        }

        public void AddCostItem(CostItem item, int day)
        {
            _days[day - 1].Add(item);
        }
    }
}