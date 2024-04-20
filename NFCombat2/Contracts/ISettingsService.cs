using NFCombat2.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Contracts
{
    public interface ISettingsService
    {
        public Language Language { get; }
        public Task SetLanguage(Language language);
        public Task<int> GetCurrentPlayerId();
        public Task SetCurrentPlayerId(int playerId);
    }
}
