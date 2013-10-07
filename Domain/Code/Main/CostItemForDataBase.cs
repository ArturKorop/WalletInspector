using System;
using System.Collections.Generic;

namespace Domain.Code.Main
{
    public class CostItemForDataBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public List<int> Tags { get; set; }
        public int UserId { get; set; }
    }
}