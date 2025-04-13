

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Player;
using NFCombat2.Models;
using NFCombat2.Models.Actions;
using NFCombat2.Models.Items.Equipments;

namespace NFCombat2.Contracts
{
    public interface IOptionsService
    {
        //ICollection<IAction> GetPrograms(Fight fight);
        //ICollection<IAction> GetItems(Fight fight);
        //ICollection<Enemy> GetTargets(Fight fight, int minRange = 0, int maxRange = 1000);
        //ICollection<string> GetCategories (Fight fight);    
        //ICollection<string> GetBonusCategories(Fight fight);

        IOptionList GetPrograms(Fight fight);
        IOptionList GetItems(Fight fight);
        IOptionList GetTargets(Fight fight, int minRange = 0, int maxRange = 1000);
        IOptionList GetStandardActions(Fight fight);
        IOptionList GetMoveActions(Fight fight);
        IOptionList GetBonusActions(Fight fight);
        IOptionList GetFirstStrikeActions(Fight fight);
        IOptionList GetWeapons(Fight fight, bool alreadyShot);
        IOptionList GetModes(IHaveModes itemWithModes);
        IOptionList GetEndTurn(Fight fight);
        IOptionList GetAdrenalineActions(Fight fight);
        IOptionList GetVariants(int episode);
        ICollection<IModificationOption> GetModificationOptions(WeaponModification modification);

        bool CanShoot(Fight fight);
    }
}
