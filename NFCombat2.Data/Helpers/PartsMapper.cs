

using NFCombat2.Data.Entities.Items;
using NFCombat2.Models.Items.Parts;
using System.Reflection;

namespace NFCombat2.Data.Helpers
{
    public static class PartsMapper
    {
        public static void SaveParts(PartBag bag, PartBagEntity entity)
        {
            foreach (var category in bag.Categories)
            {
                foreach (var part in category.Parts)
                {
                    string partName = part.WorkCoefficient.ToString();
                    PropertyInfo? property = entity.GetType().GetProperty(partName);
                    if (property != null)
                    {
                        property.SetValue(entity, part.Quantity);
                    }
                }
            }

        }

        public static void LoadParts(PartBagEntity entity, PartBag bag)
        {
            var properties = entity.GetType().GetProperties().Where(p => p.Name.Length == 1);
            var parts = bag.Categories.SelectMany(c=> c.Parts);
            foreach (var property in properties)
            {
                var part = parts.FirstOrDefault(p=> p.WorkCoefficient.ToString() == property.Name);
                if(part == null)
                {
                    continue;
                }

                var value = property.GetValue(entity, null);
                if(value is int quantity) 
                {
                    part.Quantity = quantity;
                }

            }
        }
    }
}
