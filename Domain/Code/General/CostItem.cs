using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Code.General
{
    [Table("CostItems")]
    public class CostItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        [Column("Tags")]
        public List<int> TagsIds { get; set; }
        public int UserId { get; set; }
        [NotMapped]
        public List<string> TagNames { get; set; }

        public CostItem()
        {
            TagNames = new List<string>();
            TagsIds = new List<int>();
        }

        public void SetTagNames(ITagRepository tagRepository)
        {
            foreach (var tagsId in TagsIds)
            {
                TagNames.Add(tagRepository.GetTag(tagsId));
            }
        }
    }
}