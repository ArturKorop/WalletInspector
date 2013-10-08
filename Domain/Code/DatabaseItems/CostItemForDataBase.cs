using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Code.DatabaseItems
{
    [Table("CostItems")]
    public class CostItemForDataBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public List<int> Tags { get; set; }
        public int UserId { get; set; }
    }
}