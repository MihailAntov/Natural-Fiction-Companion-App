﻿

using NFCombat2.Common.Enums;
using NFCombat2.Models.CombatResolutions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items;
using NFCombat2.Common.Helpers;
using NFCombat2.Models.Items.Weapons;
using NFCombat2.Models.Dice;

namespace NFCombat2.Models.Actions
{
    public class EnemyRangedAttack : ICombatAction, IHaveAttackRoll, IHaveRolls
    {
        private readonly Fight fight;
        private readonly Enemy _enemy;
        private readonly Weapon _weapon;
        public EnemyRangedAttack(Fight fight, Enemy enemy, Weapon weapon)
        {
            this.fight = fight;
            _enemy = enemy;
            _weapon = weapon;
            AttackRollResult = DiceCalculator.Calculate(1, AttackDiceMessage).Dice.FirstOrDefault();
            RollsResult = DiceCalculator.Calculate(_weapon.DamageDice, DiceMessage, _weapon.FlatDamage);
            BaseAccuracy = weapon.Accuracy;
            AlwaysHits = weapon.AlwaysHits;
            DiceMessageArgs[0] = _enemy.Name;
        }

        public bool IsAccuracyReduced { get; set; } = false;
        public string[] MessageArgs => new string[] { _enemy.Name};
        public MessageType MessageType => MessageType.EnemyShootMessage;
        public string[] DiceMessageArgs { get; set; } = new string[1];
        public DiceRollResult RollsResult { get; set; }
        public Dice.Dice AttackRollResult { get; set; }
        public Accuracy BaseAccuracy { get; set; }
        public Accuracy Accuracy => IsAccuracyReduced ? (BaseAccuracy < Accuracy.E ? BaseAccuracy + 1: BaseAccuracy) : BaseAccuracy;
          
        

        public string AttackDiceMessage { get; set; }
        public DiceMessageType AttackDiceMessageType => DiceMessageType.EnemyRangedAttackRoll;
        public string DiceMessage { get; set; }
        public DiceMessageType DiceMessageType => DiceMessageType.EnemyRangedDamageRoll;

        public bool AlwaysHits { get; }

        public IList<ICombatResolution> AddCritToCombatResolutions(Fight fight)
        {
            var resolutions = new List<ICombatResolution>()
            {
                new EnemyCrit(RollsResult ,_enemy)
            };
            foreach (var resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }
            RollsResult = DiceCalculator.Calculate(_weapon.DamageDice, DiceMessage, _weapon.FlatDamage);
            return resolutions;
        }

        public IList<ICombatResolution> AddMissToCombatResolutions(Fight fight)
        {
            var resolutions = new List<ICombatResolution>()
            {
                new EnemyMiss(_enemy)
            };
            foreach (var resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }
            RollsResult = DiceCalculator.Calculate(_weapon.DamageDice, DiceMessage, _weapon.FlatDamage);
            return resolutions;
        }

        public IList<ICombatResolution> AddToCombatEffects(Fight fight)
        {
            
            var resolutions = new List<ICombatResolution>()
            {
                new EnemyDealDamage(RollsResult ,_enemy)
            };
            
            foreach(var resolution in resolutions)
            {
                fight.Effects.Enqueue(resolution);
            }
            RollsResult = DiceCalculator.Calculate(_weapon.DamageDice, DiceMessage, _weapon.FlatDamage);
            return resolutions;
        }
    }
}
