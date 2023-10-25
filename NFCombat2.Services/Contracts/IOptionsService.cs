

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Services.Contracts
{
    public interface IOptionsService
    {
        ICollection<IStandardAction> GetPrograms(Fight fight);
        ICollection<IMoveAction> GetItems(Fight fight);
        ICollection<string> GetCategories(Fight fight);
    }
}
