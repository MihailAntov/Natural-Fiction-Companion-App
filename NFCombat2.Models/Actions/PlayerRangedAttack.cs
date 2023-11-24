

using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items.Weapons;
using NFCombat2.Models.PopUps;

namespace NFCombat2.Models.Actions
{
    public class PlayerRangedAttack : IStandardAction, ITarget, IHaveRolls, IHaveAttackRoll
    {
        private readonly Fight fight;
        private Accuracy _accuracy;
        public PlayerRangedAttack(Fight fight, Weapon weapon)
        {
            this.fight = fight;
            MinRange = weapon.MinRange;
            MaxRange = weapon.EffectiveMaxRange;
            AreaOfEffect = weapon.AreaOfEffect;
            Weapon = weapon;
            AttackRollResult = DiceCalculator.Calculate(1,AttackDiceMessage).Dice.FirstOrDefault();
            RollsResult = DiceCalculator.Calculate(Weapon.DamageDice,DiceMessage, Weapon.FlatDamage);
            _accuracy = weapon.Accuracy;
        }
        public string Target { get 
            {
                return Targets.Count > 1 ? Targets.Count.ToString() : Targets.FirstOrDefault().Name;
            } 
        }
        public Weapon Weapon { get; }
        public string[] MessageArgs => new string[] { Target, Weapon.Label };
        public string Label { get; set; }
        public string Description { get; set; }
        public ICollection<Enemy> Targets { get; set; } = new HashSet<Enemy>();
        public bool AreaOfEffect { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
        public Accuracy Accuracy { get { return _accuracy;  } set {  _accuracy = value; } }
        public Dice AttackRollResult { get; set; }
        public DiceRollResult RollsResult { get; set; }

        public MessageType MessageType => MessageType.ShootMessage;

        public string AttackDiceMessage => $"Your attack:";
        public string DiceMessage => $"Your damage:";

        public IList<ICombatResolution> AddCritToCombatResolutions(Fight fight)
        {
            var resolutions = new List<ICombatResolution>() { new Crit(RollsResult, Targets) };
            foreach(var resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }
            Weapon.RemainingCooldown += Weapon.CooldownPerShot;
            return resolutions;
        }

        public IList<ICombatResolution> AddMissToCombatResolutions(Fight fight)
        {
            var resolutions = new List<ICombatResolution>() { new Miss() };
            Weapon.RemainingCooldown += Weapon.CooldownPerShot;
            return resolutions;
        }

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            //DiceRollResult roll = DiceCalculator.Calculate(Weapon.DamageDice, Weapon.FlatDamage);

            var resolutions = new List<ICombatResolution>() { new DealDamage(RollsResult, Targets) };
            Weapon.RemainingCooldown += Weapon.CooldownPerShot;
            foreach (var resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }
            return resolutions;
        }

        
    }
}
