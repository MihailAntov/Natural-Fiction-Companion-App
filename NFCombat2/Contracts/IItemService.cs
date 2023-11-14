

using NFCombat2.Models.Items;

namespace NFCombat2.Contracts
{
    public interface IItemService
    {
        Task<ICollection<Item>> GetAllItems();

    }
}
