using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.SpecOps
{
    internal class Brace : Technique , IModifyPlayer
    {
        public override string Name { get; set; }
        public override int HealthThreshold => 20;
        public override TechniqueType Type => TechniqueType.Brace;

        public void OnAdded(Player.Player player)
        {
            if(player.MainHand != null && player.MainHand.MaxRange > 0 && player.MainHand.Weight < 2)
            {
                if(player.OffHand == null || player.OffHand.MaxRange == 0)
                {
                    player.MainHand.ShotsPerTurn++;
                    return;
                }
            }

            if(player.OffHand != null && player.OffHand.MaxRange > 0 && player.OffHand.Weight < 2) 
            {
                if(player.MainHand == null || player.MainHand.MaxRange == 0)
                {
                    player.OffHand.ShotsPerTurn++;
                    return;
                }
            }
        }

        public void OnRemoved(Player.Player player)
        {
            if (player.MainHand != null && player.MainHand.MaxRange > 0 && player.MainHand.Weight < 2)
            {
                if (player.OffHand == null || player.OffHand.MaxRange == 0)
                {
                    player.MainHand.ShotsPerTurn--;
                    return;
                }
            }

            if (player.OffHand != null && player.OffHand.MaxRange > 0 && player.OffHand.Weight < 2)
            {
                if (player.MainHand == null || player.MainHand.MaxRange == 0)
                {
                    player.OffHand.ShotsPerTurn--;
                    return;
                }
            }
        }
    }
}
