

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items.Equipments;

namespace NFCombat2.Models.Items.ActiveEquipments
{
    public class ArcWhip : Equipment
    {
        public ArcWhip()
        {
            IsInvention = true;
            IsCraftOnly = true;
        }
        //public override MessageType MessageType => throw new NotImplementedException();
        //public override string[] MessageArgs => throw new NotImplementedException();

        //public override IList<ICombatResolution> AddToCombatEffects(Fight fight)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
