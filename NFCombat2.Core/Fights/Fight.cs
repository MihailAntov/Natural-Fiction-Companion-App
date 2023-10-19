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
        
        //public virtual void AutoRound() { }
        //public virtual void AutoEncounter() { }

        //public virtual void Round() { }
        //public virtual void SetUp()
        //{
        //    foreach (var equipment in StaticPlayer.Equipment)
        //    {
        //        equipment.AffectFight();
        //    }
        //}

        //public virtual IList<IMoveAction> MoveActionOptions {get; set;}

        //public virtual IList<IStandardAction> StandardActionOptions { get; set; }

        //public virtual void ResolveMeleeCombat()
        //{
        //    foreach (var enemy in Enemies)
        //    {
        //        if (enemy.Strength > StaticPlayer.Strength)
        //        {
        //            StaticPlayer.Health -= enemy.Strength - StaticPlayer.Strength;
        //            if (StaticPlayer.Health < 0)
        //            {
        //                StaticPlayer.Health = 0;
        //            }
        //        }
        //        else if (StaticPlayer.Strength > enemy.Strength)
        //        {
        //            enemy.Health -= StaticPlayer.Strength - enemy.Strength;
        //            if (enemy.Health < 0)
        //            {
        //                enemy.Health = 0;
        //            }
        //        }
        //    }
        //}

    }
}
