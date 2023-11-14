using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;


namespace NFCombat2.Models.Items.Consumables
{
    public class StrengthPotion : Consumable
    {
        public StrengthPotion()
        {
            Label = "Strength Potion";
            Name = "Strength potion";
            Description = "Does what a strength potion does.";
        }

        public override string[] MessageArgs => throw new NotImplementedException();

        public override IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            throw new NotImplementedException();
        }
    }
}
