using System;
using System.Globalization;
using Domain.Code.DatabaseItems;
using Domain.Code.General;

namespace Domain.Code.Time
{
    public class Month
    {
        private readonly Day[] _days;
        private readonly int _dayInMonth;

        public string Name { get;private set; }
        public int MonthNumber { get;private set; }

        public Day GetDay(int dayNumber)
        {
            if (dayNumber < 1 || dayNumber > _dayInMonth)
                throw new ArgumentOutOfRangeException("dayNumber",
                                                      String.Format("Day number must be from 1 to {0}", _dayInMonth));

            return _days[dayNumber - 1];
        }

        public Month(int monthNumber, int yearName)
        {
            MonthNumber = monthNumber;
            Name = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MonthNumber);
            _dayInMonth = DateTime.DaysInMonth(yearName, monthNumber);
            _days = new Day[_dayInMonth];
            for (int i = 0; i < _dayInMonth; i++)
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