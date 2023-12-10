

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items.Equipments;

namespace NFCombat2.Models.Items.ActiveEquipments
{
    public class ArcWhip : ActiveEquipment
    {
        public ArcWhip()
        {
            IsInvention = true;
            IsCraftOnly = true;
        }

        public override IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            if(fight is TentacleFight tentacleFight)
            {
                tentacleFight.ProtectedFromMaser = true;
                return new List<ICombatResolution>() { new DisableMaser() };
            }
            return new List<ICombatResolution>() { new NoEffect(this.Name) };
        }

    }
}
