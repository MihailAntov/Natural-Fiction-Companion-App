﻿

using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Contracts
{
    public interface IAddable
    {
        string Name { get; set; }
        string Description { get; set; }    
        bool IsInvention { get; set; }
        public string Formula { get; set; }
        public int Episode { get; set; }

        public ItemType ItemType { get; set; }
        public int Id { get; set; }
    }
}
