﻿

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Programs
{
    public class TentacleDisableProgramEffect : IProgramEffect
    {
        public MessageType MessageType => MessageType.ProgramDisableTentacleMessage;

        public string[] MessageArgs => Array.Empty<string>();

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            if (fight is TentacleFight tentacleFight)
            {
                tentacleFight.ProtectedFromMaser = true;
                return new List<ICombatResolution>() { new DisableMaser() };
            }
            return new List<ICombatResolution>() { new ProgramNoEffect() };
        }
    }
}