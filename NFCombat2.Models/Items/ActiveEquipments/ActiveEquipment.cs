using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;
using NFCombat2.Models.Items.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Items.ActiveEquipments
{
    public abstract class ActiveEquipment : Equipment, ICombatActiveItem
    {
        public ActiveEquipment()
        {
            
        }


        public MessageType MessageType => MessageType.UseItemMessage;

        public string[] MessageArgs => new string[] { Name };

        public bool UnavailableForRestOfCombat { get; set; }

        public abstract IList<ICombatResolution> AddToCombatEffects(Fight fight);
        
    }
}
