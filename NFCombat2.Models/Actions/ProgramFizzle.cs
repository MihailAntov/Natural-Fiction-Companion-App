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
        private int _overloadCost;
        public ProgramFizzle(ProgramExecutionResult result, int overloadCost)
        {
            _result = result;
            _overloadCost = overloadCost;
        }
        public MessageType MessageType => MessageType.None;

        public string[] MessageArgs => Array.Empty<string>();

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var resolutions = new List<ICombatResolution>();

            if(_result == ProgramExecutionResult.NoEffect)
            {
                resolutions.Add(new ProgramNoEffect(MessageType.ProgramNoEffect, _overloadCost));
            }
            else
            {
                resolutions.Add(new ProgramNoEffect(MessageType.ProgramNotExist, _overloadCost));
            }

            foreach(var resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }
             return resolutions;

        }
    }
}
