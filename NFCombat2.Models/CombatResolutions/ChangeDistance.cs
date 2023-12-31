﻿using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Fights;

namespace NFCombat2.Models.CombatResolutions
{
    public class ChangeDistance : ICombatResolution
    {
        private int _amount;
        private Enemy _enemy;
   
        public ChangeDistance(int amount, Enemy enemy)
        {
            _amount = amount;
            _enemy = enemy;
           
        }

        public MessageType MessageType => MessageType.ChangeDistanceMessage;
        public string[] MessageArgs => new string[] { _enemy.Name, _enemy.Distance.ToString() };
        public async Task Resolve(Fight fight)
        {
            _enemy.Distance += _amount;
        }
    }
}
