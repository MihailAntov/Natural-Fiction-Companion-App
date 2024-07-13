using NFCombat2.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Contracts
{
    public interface ISettingsService
    {
        public Language Language { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public Task SetLanguage(Language language);
        public Task<int> GetCurrentPlayerId();
        public Task SetCurrentPlayerId(int playerId);
        public string LanguageIcon { get; set; }
    }
}
