

using NFCombat2.Common.Enums;
using System.Collections.ObjectModel;

namespace NFCombat2.Services.Contracts
{
    public interface ILogService
    {
        void Log(MessageType messageType, params string[] args);
        public ObservableCollection<string> Messages { get; }
    }
}
