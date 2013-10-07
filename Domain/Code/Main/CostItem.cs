using System;
using System.Collections.Generic;

namespace Domain.Code.Main
{
    public class CostItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public List<string> Tags { get; set; } 
    }
}