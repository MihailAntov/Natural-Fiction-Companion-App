using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Programs
{
    public class Program : IStandardAction
    {
        public Program(string label, IEnumerable<IProgramEffect> effects)
        {
            Label = label;
            Effects = effects;
        }
        public string Label { get; set; }
        public bool AreaOfEffect { get; set; }
        public bool BonusAction {  get; set; }
        public int Cost { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
        IEnumerable<IProgramEffect> Effects { get; set; }
        public void AffectFight(Fight fight)
        {
            foreach (var effect in Effects)
            {
                effect.AffectFight(fight);
            }
        }



    }
}
