namespace NFCombat2.Contracts
{
    public interface ICombatLogService
    {
        ICollection<string> Messages { get; set; }
        void AddMessage(string message);
    }
}
