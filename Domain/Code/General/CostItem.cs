using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Code.Common;
using Domain.Interfaces;
using Microsoft.Practices.Unity;

namespace Domain.Code.General
{
    [Table("CostItems")]
    public class CostItem : IEquatable<CostItem>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double Price { get; set; }
        [Column("Tags")]
        public List<int> TagIds { get; set; }
        [Required]
        public int UserId { get; set; }
        [NotMapped]
        public List<string> TagNames { get; set; }

        private static readonly ITagRepository TagRepository;

        static CostItem()
        {
            TagRepository = DIServiceLocator.Current.Resolve<ITagRepository>();
        }

        public CostItem()
        {
            TagNames = new List<string>();
            TagIds = new List<int>();
        }

        public CostItem(string name, DateTime date, double price)
        {
            TagNames = new List<string>();
            TagIds = new List<int>();
            Name = name;
            Date = date;
            Price = price;
        }

        public void SetTagNames()
        {
            TagNames.Clear();
            foreach (var tagId in TagIds)
            {
                TagNames.Add(TagRepository.GetTagName(tagId));
            }
        }

        public void SetTagIds()
        {
            TagIds.Clear();
            foreach (var tagName in TagNames)
            {
                TagIds.Add(TagRepository.GetTagId(tagName));
            }
        }

        public bool Equals(CostItem other)
        {
            return Id == other.Id;
        }

        public void Update(CostItem item)
        {
            Name = item.Name;
            Price = item.Price;
            TagNames = item.TagNames;
            TagIds = item.TagIds;
            SetTagIds();
        }
    }
}