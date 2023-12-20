

using Microsoft.VisualBasic;
using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Fights
{
    public class Variant
    {
        public VariantDescription Type { get; set; }
        public string Text { get; set; }
        public int AnthenasBlocked { get; set; } = 0;
        public Enemy DisarmedEnemy { get; set; } 
        public void Apply(Fight fight)
        {
            if(Type == VariantDescription.AnthenasBlocked)
            {
                fight.Enemies.FirstOrDefault().Health -= 20 * AnthenasBlocked;
            }

            if(Type == VariantDescription.IceSpark)
            {
                fight.Result = FightResult.Won;
            }

            if(Type == VariantDescription.MagnetDiscs)
            {
                fight.Enemies.Clear();
                fight.Enemies.Add(DisarmedEnemy);
            }
        }
    }
}
