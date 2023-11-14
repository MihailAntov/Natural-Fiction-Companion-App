using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;


namespace NFCombat2.Models.Items.Consumables
{
    public class SaltPotion : Consumable
    {
        public SaltPotion()
        {
            Label = "Salt Potion";
            Name = "Salt potion";
            Description = "Does what a salt potion does.";
        }

        public override string[] MessageArgs => throw new NotImplementedException();

        public override IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            throw new NotImplementedException();
        }
    }
}
