using NFCombat2.Models.Fights;

namespace NFCombat2.Models
{
    public class Consumable : Item
    {
        public Consumable(string label, Action<Fight> effect)
        {
                Label = label;
            Effect = effect;
        }
        public override string Label { get; set; }

        public Action<Fight> Effect { get; set; }
        public override void AffectFight(Fight fight) => Effect(fight);
        
    }
}
