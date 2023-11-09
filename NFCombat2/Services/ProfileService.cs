

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

        public Player CurrentPlayer()
        {
            if(_player == null)
            {
                _player =  GetAll().FirstOrDefault();
            }
            return _player;
        }

        public IList<Player> GetAll()
        {
            return repo.GetAllProfiles()
                .Select(p => new Player()
                {
                    Name = p.Name,
                    MaxHealth = p.MaxHealth,
                    Health = p.Health
                }).ToList();

            
        }

        public async Task<bool> Save(string name)
        {
            return await repo.AddNewProfile(name);
        }

        public async Task SwitchActiveProfile(Player player)
        {
            await Task.Run(() =>
            {
                _player = player;
            });
        }
    }
}
