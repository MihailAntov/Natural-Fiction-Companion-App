using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Actions
{
    public class ProgramFizzle : ICombatAction
    {
        private ProgramExecutionResult _result;
        public ProgramFizzle(ProgramExecutionResult result)
        {
            _result = result;
        }
        public MessageType MessageType => MessageType.None;

        public string[] MessageArgs => Array.Empty<string>();

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var resolutions = new List<ICombatResolution>()
            {
                new ProgramNoEffect(){}
            };

            if(_result == ProgramExecutionResult.NoEffect)
            {
                resolutions.Add(new LearnProgram());
            }


            return resolutions;

        }
    }
}
