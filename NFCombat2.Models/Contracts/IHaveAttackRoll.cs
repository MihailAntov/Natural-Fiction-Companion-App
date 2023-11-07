using CommunityToolkit.Maui.Views;
using NFCombat2.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Contracts
{
    public interface IHaveAttackRoll
    {
        Dice AttackRollResult { get; set; }
    }
}
