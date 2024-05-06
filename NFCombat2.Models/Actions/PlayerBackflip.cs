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
    public class PlayerBackflip : IMoveAction
    {

        public string Name => "Backflip";

        public string Description => "Increase distance by 2 meters.";

        public MessageType MessageType => MessageType.BackFlipMessage;

        public string[] MessageArgs => Array.Empty<string>();

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var resolutions = new List<ICombatResolution>();
            foreach (var enemy in fight.Enemies)
            {
                var resolution = new ChangeDistance(2, enemy);
                fight.Effects.Enqueue(resolution);
                resolutions.Add(resolution);
            }
            return resolutions;
        }
    }
}
