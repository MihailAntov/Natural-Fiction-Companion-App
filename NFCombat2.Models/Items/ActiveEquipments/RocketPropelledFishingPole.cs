

using NFCombat2.Common.Enums;
using NFCombat2.Models.Actions;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.Items.ActiveEquipments
{
    public class RocketPropelledFishingPole : ActiveEquipment, IHaveModes, ITarget
    {
        public RocketPropelledFishingPole()
        {
            IsInvention = true;
            IsCraftOnly = true;
            MinRange = 0;
            MaxRange = 1000;
            AreaOfEffect = false;
            Targets = new List<Enemy>();
            Modes = new List<IMode>()
            {
                new Mode() { ItemMode = ItemMode.PoleMoveCloser },
                new Mode() { ItemMode = ItemMode.PoleMoveFuther }
            };

        }

        public IList<IMode> Modes { get; set; }
        public IMode Mode { get; set; }
        public ICollection<Enemy> Targets { get; set; }
        public bool AreaOfEffect { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public override IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            
            var resolutions = new List<ICombatResolution>()
            {
                new FishingPoleGrab(Targets.FirstOrDefault(), Mode.ItemMode)
            };
            
            foreach(var resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }
            Mode = null;
            Targets.Clear();
            UnavailableForRestOfCombat = true;
            //todo : at end of combat, reset those
            return resolutions;
        }
    }
}
