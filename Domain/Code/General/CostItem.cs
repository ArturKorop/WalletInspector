using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Domain.Code.Common;
using Domain.Interfaces;
using Microsoft.Practices.Unity;

namespace Domain.Code.General
{
    [Table("CostItems")]
    [Serializable]
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
        public string TagIdString { get; set; }

        [Required]
        public int UserId { get; set; }

        [NotMapped]
        public List<string> TagNames { get; set; }

        [NotMapped]
        public List<int> TagIds { get; set; }

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
            int temp;
            Int32.TryParse(TagIdString, out temp);
            if(temp > 0)
                TagIds.Add(temp);

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

            TagIdString = TagIds.Count == 0 ? String.Empty : TagIds[0].ToString(CultureInfo.InvariantCulture);
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

        public bool IsValid()
        {
            return !String.IsNullOrWhiteSpace(Name);
        }
    }
}