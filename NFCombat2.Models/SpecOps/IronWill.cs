using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.SpecOps
{
    internal class IronWill : Technique, IModifyPlayer
    {
        public override string Name { get; set; }
        public override int HealthThreshold => 5;
        public override TechniqueType Type => TechniqueType.IronWill;

        public void OnAdded(Player.Player player)
        {
            player.MinHealth = -4;
        }

        public void OnRemoved(Player.Player player)
        {
            player.MinHealth = 1;
        }
    }
}
