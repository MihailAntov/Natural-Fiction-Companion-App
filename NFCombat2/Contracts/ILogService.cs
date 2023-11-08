

using NFCombat2.Common.Enums;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace NFCombat2.Contracts
{
    public interface ILogService 
    {
        Task Log(MessageType messageType, params string[] args);
        ObservableCollection<string> Messages { get; }
        
    }
}
