

using NFCombat2.Models.Actions;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Models.Items.Equipments
{
    public class TacticalGlasses : Equipment, IModifyAction
    {
        public TacticalGlasses()
        {
            Name = "Tactical glasses";
            Description = "Increases accuracy by one.";
        }

        public Task Modify(ICombatAction action)
        {
            if(action is PlayerRangedAttack attack)
            {
                if(attack.Accuracy > 0)
                {
                    attack.Accuracy--;
                }
            }
            return Task.CompletedTask;
        }
    }
}
