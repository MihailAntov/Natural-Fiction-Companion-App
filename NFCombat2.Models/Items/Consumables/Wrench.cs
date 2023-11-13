using NFCombat2.Models.Contracts;

using NFCombat2.Models.Fights;


namespace NFCombat2.Models.Items.Consumables
{
    public class Wrench : Consumable
    {
        public Wrench()
        {
            Label = "Wrench";
        }


        public override string[] MessageArgs => throw new NotImplementedException();

        public override IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            throw new NotImplementedException();
        }
    }
}
