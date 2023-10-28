

using NFCombat2.Models.Actions;
using NFCombat2.Models.Combat;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Programs
{
    public class DamageComponent : IProgramEffect
    {
        private readonly IDiceService _diceService;
        public DamageComponent(IDiceService diceService)
        {
            _diceService = diceService;
        }

        public int NumberOfDice { get; set; }
        public int FlatDamage { get; set; }
        public int DelayedNumberOfDice { get; set; }
        public int DelayedFlatDamage { get; set; }
        public int DelayedDuration { get; set; }

        public void AffectFight(Fight fight)
        {
            
        }

        public void AreaAffectFight(Fight fight)
        {
            foreach(var enemy in fight.Enemies)
            {
                fight.Effects.Enqueue(new DealDamage());
            }
        }
    }
}
