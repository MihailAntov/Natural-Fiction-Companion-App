

using NFCombat2.Models.Player;
using NFCombat2.Contracts;
using NFCombat2.Data;

namespace NFCombat2.Services
{
    public class ProfileService : IProfileService
    {
        private ProfileRepository repo;
        private Player _player;
        public ProfileService(ProfileRepository repository)
        {
            repo = repository;
        }

        public async Task<Player> CurrentPlayer()
        {
            if(_player == null)
            {
                _player = (await GetAll()).FirstOrDefault();
            }
            return _player;
        }

        public async Task<List<Player>> GetAll()
        {
            return repo.GetAllProfiles()
                .Select(p => new Player()
                {
                    Name = p.Name,
                    MaxHealth = p.MaxHealth,
                    Health = p.Health
                }).ToList();
        }

        public async Task Save(string name)
        {
            repo.AddNewProfile(name);
        }
    }
}
