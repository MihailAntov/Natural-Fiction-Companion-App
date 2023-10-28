using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Programs
{
    public class Program : IStandardAction, ITarget
    {
        public Program(string label)
        {
            Label = label;
        }
        public string Label { get; set; }
        public bool AreaOfEffect { get; set; }
        public bool BonusAction {  get; set; }
        public int Cost { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
        public IEnumerable<IProgramEffect> Effects { get; set; }
        public ICollection<Enemy> Targets { get; set; }

        public void AffectFight(Fight fight)
        {
            foreach (var effect in Effects)
            {
                effect.AffectFight(fight);
            }
        }



    }
}
