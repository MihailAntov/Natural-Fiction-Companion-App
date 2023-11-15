

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items;

namespace NFCombat2.Contracts
{
    public interface IItemService
    {
        Task<ICollection<IAddable>> GetAllItems();
        Task<ICollection<IAddable>> GetAllWeapons();
        Task<ICollection<IAddable>> GetAllEquipment();

    }
}
