using System.Collections.Generic;
using Domain.Code.Common;
using Domain.Code.Main;
using Domain.Interfaces;
using Microsoft.Practices.Unity;

namespace Domain.Code.Factories
{
    public class CostItemFactory
    {
        private readonly ITagRepository _tagRepository;

        public CostItemFactory()
        {
            _tagRepository = DIServiceLocator.Current.Resolve<ITagRepository>();
        }

        public CostItem CreateCostItem(CostItemForDataBase item)
        {
            var costItem = new CostItem
                {
                    Name = item.Name,
                    Price = item.Price,
                    Tags = new List<string>()
                };

            foreach (var tag in item.Tags)
            {
                costItem.Tags.Add(_tagRepository.GetTag(tag));
            }

            return costItem;
        }
    }
}