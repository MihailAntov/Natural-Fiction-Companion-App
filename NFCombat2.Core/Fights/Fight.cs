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
        public Queue<IAffectCombat> DelayedEffects { get; set; } = new Queue<IAffectCombat>();

        public Queue<IAffectCombat> Effects { get; set; } = new Queue<IAffectCombat>();
        public bool HasBonusAction { get; set; } = false;
        public int RemainingCrits { get; set; } = 0;


    }
}
