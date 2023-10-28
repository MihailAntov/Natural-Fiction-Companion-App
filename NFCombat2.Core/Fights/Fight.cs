using NFCombat2.Models.Actions;


using NFCombat2.Models.Contracts;
using NFCombat2.Models.Player;


namespace NFCombat2.Models.Fights
{
    public abstract class Fight
    {
        public Fight(IList<Enemy> enemies, Player.Player player)
        {
            Enemies = enemies;
            Player = player;
        }

        public Player.Player Player { get; set; }

        public IList<Enemy> Enemies { get; set; }
        
        public Queue<IAction> Actions { get; set; } = new Queue<IAction>();
        public Queue<IDelayedAction> DelayedActions { get; set; } = new Queue<IDelayedAction>();

        public Queue<IAffectCombat> Effects { get; set; } = new Queue<IAffectCombat>();

    }
}
