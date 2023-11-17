using NFCombat2.Models.Contracts;

using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.Items
{
    public class Wrench : CombatActiveItem
    {
        public Wrench()
        {
            Label = "Wrench";
            Name = "Wrench";
            IsConsumable = true;
        }


        public override string[] MessageArgs => throw new NotImplementedException();

        public override IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            throw new NotImplementedException();
        }
    }
}
