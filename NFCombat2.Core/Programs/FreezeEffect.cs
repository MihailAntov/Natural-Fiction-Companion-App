

using NFCombat2.Models.Combat;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Programs
{
    public class FreezeEffect : IProgramEffect
    {
        private int _turns;
        private bool _areaOfEffect;

        public Enemy Target { get; set; }
        public FreezeEffect(int turns, bool areaOfEffect)
        {
                _turns = turns;
            _areaOfEffect = areaOfEffect;
        }
        public void AffectFight(Fight fight)
        {
            IList<Enemy> targets = new List<Enemy>();
            if(!_areaOfEffect)
            {
                targets.Add(Target);
            }
            else
            {
                targets = fight.Enemies;
            }

            fight.Effects.Enqueue(new Freeze(_turns, targets));
            
            
        }

        
    }
}
