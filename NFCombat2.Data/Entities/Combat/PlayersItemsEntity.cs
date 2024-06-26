﻿using NFCombat2.Common.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Data.Entities.Combat
{
    public class PlayersItemsEntity
    {
        public int PlayerId { get; set; }
        public int ItemId { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public bool IsConsumable { get; set; } = false;

        public int Quantity { get; set; } = 1;
        public bool InExtraBag { get; set; } = false;
    }
}
