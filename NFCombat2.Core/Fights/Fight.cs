using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Fights
{
    public abstract class Fight
    {
        public Fight(IList<Enemy> enemies, Player player)
        {
            Enemies = enemies;
            Player = player;
        }

        public IList<Enemy> Enemies { get; set; }
        public Player Player { get; set; }
        public virtual void AutoRound() { }
        public virtual void AutoEncounter() { }

        public virtual void Round() { }
        public virtual void SetUp()
        {
            foreach (var equipment in Player.Equipment)
            {
                equipment.AffectFight();
            }
        }

        public virtual IList<IMoveAction> MoveActionOptions 
        { 
            get
            {
                var options = new List<IMoveAction>();
                foreach(var consumable in Player.Consumables)
                {
                    options.Add(consumable);
                }
                if(!Enemies.Any(e=> e.Distance == 0))
                {
                    options.Add(new PlayerGetCloser(this));
                }
                return options;
            } 
        }

        public virtual IList<IStandardAction> StandardActionOptions { get; set; }

        public virtual void ResolveMeleeCombat()
        {
            foreach(var enemy in Enemies)
            {
                if(enemy.Strength > Player.Strength)
                {
                    Player.Health -= enemy.Strength - Player.Strength;
                    if(Player.Health < 0)
                    {
                        Player.Health = 0;
                    }
                }
                else if(Player.Strength > enemy.Strength)
                {
                    enemy.Health -= Player.Strength - enemy.Strength;
                    if(enemy.Health < 0)
                    {
                        enemy.Health = 0;
                    }
                }

                
            }
        }

    }
}
