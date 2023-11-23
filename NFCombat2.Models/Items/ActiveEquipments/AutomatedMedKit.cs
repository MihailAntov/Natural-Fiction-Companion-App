
using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.ActiveEquipments
{
    public class AutomatedMedKit : ActiveEquipment
    {
        public override string Label { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override MessageType MessageType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string[] MessageArgs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            throw new NotImplementedException();
        }
    }
}
