

using NFCombat2.Common.Enums;
using static NFCombat2.Common.AppConstants.Messages;
using NFCombat2.Contracts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Specialized;
using NFCombat2.Models.Player;

namespace NFCombat2.Services
{
    public class LogService : ILogService
    {
        private readonly IPlayerService _profileService;
        private Player _player;
        public ObservableCollection<string> Messages { get; } = new ObservableCollection<string>();
        

        public LogService(IPlayerService profileService)
        {
            _profileService = profileService;
            _player = profileService.CurrentPlayer();
        }

        private string GetStructure(MessageType type, Language language)
        {
            switch (language)
            {
                case Language.Bulgarian:
                    return BulgarianMessages[type];
                case Language.English:
                default:
                    return EnglishMessages[type];

            }
        }

        public async Task Log(MessageType messageType, params string[] args)
        { 
            string structure = GetStructure(messageType, _player.Language);
            Messages.Add(String.Format($"  {structure}", args));
        }

        
    }
}
