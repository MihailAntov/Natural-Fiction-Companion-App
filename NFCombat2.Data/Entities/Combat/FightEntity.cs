﻿using NFCombat2.Common.Enums;
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFCombat2.Data.Entities.Combat
{
    public class FightEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Episode { get; set; }

        public FightType FightType { get; set; }


    }
}
