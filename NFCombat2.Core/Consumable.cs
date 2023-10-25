using NFCombat2.Models.Fights;

namespace NFCombat2.Models
{
    public class Consumable : Item
    {
        public override string Label => "Test Label";

        public override void AffectFight(Fight fight)
        {
            foreach (var enemy in fight.Enemies)
            {
                enemy.Health -= 3;
            }
        }
    }
}
