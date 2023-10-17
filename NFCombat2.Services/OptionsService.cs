

using NFCombat2.Common.Enums;
using NFCombat2.Models;
using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Player;
using NFCombat2.Services.Contracts;

namespace NFCombat2.Services
{
    public class OptionsService : IOptionsService
    {
        
        public OptionsService()
        {
           
        }
        public ICollection<MoveActionOptions> GetMoveOptions(Fight fight)
        {
            var options = new List<MoveActionOptions>();
            if(!fight.Enemies.Any(e=> e.Distance == 0))
            {
                options.Add(MoveActionOptions.GetCloser);
            }
            if (StaticPlayer.Consumables.Any())
            {
                options.Add(MoveActionOptions.UseItem);
            }
            
            return options;
        }

        public ICollection<IStandardAction> GetStandardActionOptions(Fight fight)
        {
            var options = new List<IStandardAction>();
            if(!fight.Enemies.Any(e=> e.Distance == 0))
            {
                options.Add(new PlayerRangedAttack(fight));
            }
            else
            {
                options.Add(new MeleeAttack(fight));
            }

            options.Add(new PlayerRangedAttack(fight));
            return options;
        }
    }
}
