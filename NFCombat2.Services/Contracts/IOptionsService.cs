﻿

using NFCombat2.Common.Enums;
using NFCombat2.Models.Fights;

namespace NFCombat2.Services.Contracts
{
    public interface IOptionsService
    {
        ICollection<MoveActionOptions> GetMoveOptions();
        ICollection<StandardActionOptions> GetStandardActionOptions();
    }
}