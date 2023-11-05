

using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Enums;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items;

namespace NFCombat2.Models.Actions
{
    public class PlayerRangedAttack : IStandardAction, ITarget, IHaveRolls, IHaveAttackRoll
    {
        private readonly Fight fight;
        public PlayerRangedAttack(Fight fight, Weapon weapon)
        {
            this.fight = fight;
            MinRange = weapon.MinRange;
            MaxRange = weapon.MaxRange;
            AreaOfEffect = weapon.AreaOfEffect;
            Weapon = weapon;
            AttackRoll = DiceCalculator.RollSingle();
            DamageRoll = DiceCalculator.Calculate(Weapon.DamageDice, Weapon.FlatDamage);
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
        public Dice AttackRoll { get; set; }
        public DiceRollResult DamageRoll { get; set; }

        public MessageType MessageType => MessageType.ShootMessage;

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            //DiceRollResult roll = DiceCalculator.Calculate(Weapon.DamageDice, Weapon.FlatDamage);

            var resolutions = new List<ICombatResolution>() { new DealDamage(DamageRoll, Targets) };
            Weapon.Cooldown += Weapon.CooldownPerShot;
            return resolutions;
        }

        public Popup ShowAttackRoll()
        {
            Popup roll = new Popup()
            {
                Content = new VerticalStackLayout()
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "test test"
                        }
                    }
                }
            };

            return roll;
            
        }

        public Popup ShowRolls()
        {
            throw new NotImplementedException();
        }
    }
}
