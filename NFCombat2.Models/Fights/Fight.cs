using NFCombat2.Common.Enums;
using NFCombat2.Models.Actions;


using NFCombat2.Models.Contracts;
using NFCombat2.Models.Player;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.Models.Fights
{
    public class Fight : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public Fight()
        {
            Result = FightResult.None;
            Type = FightType.Regular;
            //PlayerStrength = Player.StrengthWithoutWeapon;
        }
        
        public FightResult Result { get; set; }
        public bool AllowsPrograms { get; set; } = true;
        public Player.Player Player { get; set; }
        public FightType Type { get; set; } 
        public IList<Enemy> Enemies { get; set; }
        public bool UsedAdrenalineThisTurn { get; set; }
        public bool UsedBackflipThisFight { get; set; } = false;
        public bool MovedThisTurn { get; set; } = false;
        public bool MovedLastTurn { get; set; } = false;
        public bool EnemyMovedThisTurn { get; set; } = false;
        public bool EnemyMovedLastTurn { get; set; } = false;
        public int AdrenalineCost { get; set; } = 3;
        public int AdrenalineCostIncrement { get; set; } = 3;
        public bool WeaponsContributeStrength { get; protected set; } = true;
        protected int _playerStrength = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int EnemyCount => Enemies.Count;
        public int PlayerStrength { get { return _playerStrength; } set
            { 
                if(value < 0)
                {
                    value = 0;
                }

                if(_playerStrength!= value)
                {
                    _playerStrength = value;
                    OnPropertyChanged(nameof(PlayerStrength));
                }
            }
        }
        public Queue<IAction> Actions { get; set; } = new Queue<IAction>();
        public Queue<ICombatAction> DelayedEffects { get; set; } = new Queue<ICombatAction>();

        public Queue<ICombatResolution> Effects { get; set; } = new Queue<ICombatResolution>();
        public bool HasBonusAction { get; set; } = false;
        public bool HasFirstStrike { get; set; } = false;
        public int RemainingCrits { get; set; } = 0;

        public int Turn { get; set; } = 1;
        public TurnPhase TurnPhase { get; set; } = TurnPhase.FirstStrike;

        public List<Action> TemporaryEffects { get; set; } = new List<Action>();

        public virtual IList<ICombatAction> EnemyMovement()
        {
            var movement = new List<ICombatAction>();
            foreach(var enemy in Enemies)
            {
                enemy.HasMoved = false;
                if (enemy.RemainingFrozenTurns > 0)
                {
                    movement.Add(new EnemyMovePass(enemy));
                    enemy.RemainingFrozenTurns--;
                }
                else if (enemy.Range < enemy.Distance && enemy.Speed > 0 )
                {
                    movement.Add(new EnemyGetCloser(this, enemy));
                    enemy.HasMoved = true;
                }
                
            }
            return movement;
        }

        public virtual IList<ICombatAction> EnemyActions()
        {
            
            var actions = new List<ICombatAction>();
            foreach (var enemy in Enemies)
            {
                   

                if (enemy.Distance == 0)
                {
                    actions.Add(new EnemyMeleeAttack(this, enemy));
                }
                else if (enemy.Range >= enemy.Distance)
                {
                    foreach(var weapon in enemy.Weapons)
                    {
                        if(weapon.MaxRange > 0 && weapon.MaxRange >= enemy.Distance)
                        {
                            actions.Add(new EnemyRangedAttack(this, enemy, weapon));
                        }
                    }
                }

                
            }

            return actions;
        }

        public virtual void SetUp()
        {
            foreach(var activatable in Player.Activatables)
            {
                activatable.UnavailableForRestOfCombat = false;
            }
            PlayerStrength = Player.StrengthWithoutWeapon;
        }

        public virtual void CheckWinCondition()
        {

            if(!Enemies.Any(e=> e.Health > 0) && this is not TentacleFight)
            {
                Result = FightResult.Won;
                return;
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
