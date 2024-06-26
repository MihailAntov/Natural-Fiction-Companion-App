﻿using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Player;

namespace NFCombat2.Models.Programs
{
    public class Program : IStandardAction
    {
        public Player.Player Caster { get; set; }
        public Program()
        {
        }
        public string Name { get; set; }
        public bool AreaOfEffect { get; set; }
        public bool BonusAction {  get; set; }
        //public int Cost { get; set; }
        public int Episode { get; set; }    
        public string Formula { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
        public ICollection<IProgramEffect> Effects { get; set; } = new List<IProgramEffect>();
        public ICollection<Enemy> Targets { get; set; } = new List<Enemy>();

        public string Description { get; set; }

        public MessageType MessageType => MessageType.UseProgramMessage;

        public string[] MessageArgs => new string[] { Name, (Effects.Select(e=> e.Cost).Sum() + Caster.Overload).ToString() };

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            var resolutions = new List<ICombatResolution>();
            foreach (var effect in Effects)
            {
                if(effect is ITarget targettingEffect)
                {
                    targettingEffect.Targets = Targets;
                }
                resolutions.AddRange(effect.AddToCombatEffects(fight));
            }

            return resolutions;
        }



    }
}
