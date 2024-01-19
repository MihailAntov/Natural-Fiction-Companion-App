

using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items;

namespace NFCombat2.Contracts
{
    public interface IItemService
    {
        public IAddable CheckFormula(string formula);
        

    }
}
