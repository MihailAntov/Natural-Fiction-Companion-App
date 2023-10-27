using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models
{
    public class Program : IStandardAction
    {
        public Program(string label, Action<Fight> effect)
        {
            Label = label;
            Effect = effect;
        }
        public string Label { get; set; }
        Action<Fight> Effect { get; set; } 
        public void AffectFight(Fight fight) => Effect(fight);

    }
}
