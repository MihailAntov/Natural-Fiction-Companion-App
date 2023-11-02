using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items
{
    public class Wrench : Consumable
    {
        public Wrench()
        {

        }

        public override string Label { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string[] MessageArgs => throw new NotImplementedException();

        public override IEnumerable<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            throw new NotImplementedException();
        }
    }
}
