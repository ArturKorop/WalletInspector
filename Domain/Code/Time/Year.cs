using System;
using Domain.Code.DatabaseItems;
using Domain.Code.General;

namespace Domain.Code.Time
{
    public class Year
    {
        private readonly Month[] _months;

        public int Name { get; private set; }

        public Year(int name)
        {
            Name = name;
            _months = new Month[12];
            for (int i = 0; i < 12; i++)
            {
                _months[i] = new Month(i + 1, Name);
            }
        }

        public void AddCostItem(CostItem item, DateTime date)
        {
            _months[date.Month - 1].AddCostItem(item, date.Day);
        }

        public Month GetMonth(int monthNumber)
        {
            if(monthNumber < 1 || monthNumber > 12)
                throw new ArgumentOutOfRangeException("monthNumber", "Number of month must be from 1 to 12");

            return _months[monthNumber - 1];
        }
    }
}