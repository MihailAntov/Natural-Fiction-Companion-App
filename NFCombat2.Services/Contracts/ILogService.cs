

using NFCombat2.Common.Enums;

namespace NFCombat2.Services.Contracts
{
    public interface ILogService
    {
        void Log(MessageType messageType, params string[] args);
    }
}
