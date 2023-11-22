

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.SpecOps;

namespace NFCombat2.Models.Player
{
    public class SpecOps : Player
    {
        public IList<Technique> Techniques { get; set; } = new List<Technique>();
        public SpecOps()
        {
            Class = PlayerClass.SpecOps;
        }

        public override IList<IModifyAction> ActionModifiers
        {
            get
            {
                var result = new List<IModifyAction>();
                foreach(var modification in base.ActionModifiers)
                {
                    result.Add(modification);
                }
                foreach(IModifyAction technique in Techniques)
                {
                    result.Add(technique);
                }

                return result;
            }
        }
    }
}
