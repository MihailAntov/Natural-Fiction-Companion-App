using AutoMapper;
using NFCombat2.Common.Enums;
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Models.Player;
using SQLite;
using System;
using System.Reflection.Metadata;

namespace NFCombat2.Data.Entities.Repositories
{
    public class PlayerRepository
    {
        string _dbPath;
        private SQLiteAsyncConnection connection = null!;
        private IMapper _mapper;
        public string StatusMessage { get; set; } = string.Empty;
        private async Task Init()
        {
            if (connection != null)
            {
                return;
            }
            connection = new SQLiteAsyncConnection(_dbPath);
            
            await connection.CreateTableAsync<PlayerEntity>();

            if(connection.Table<PlayerEntity>() != null)
            {
                if(await connection.Table<PlayerEntity>().CountAsync() > 0) 
                {
                    
                }
            }

        }
        public PlayerRepository(string dbPath, IMapper mapper)
        {
            _dbPath = dbPath;
            _mapper = mapper;
        }

        public async Task<Player?> AddNewProfile(Player player)
        {
            int result = 0;
            await Init();
            await Task.Run(async () =>
            {
                try
                {
                    

                    // basic validation to ensure a name was entered
                    if (string.IsNullOrEmpty(player.Name))
                        throw new Exception("Valid name required");
                    
                    
                    result = await connection.InsertAsync(new PlayerEntity { Name = player.Name, Class = player.Class });

                    StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, player.Name);
                }
                catch (Exception ex)
                {
                    StatusMessage = string.Format("Failed to add {0}. Error: {1}", player.Name, ex.Message);
                }
            });

            return result == 1 ? player : null;
        }

        public async Task UpdateProfile(PlayerEntity player)
        {
            await Init();
            await connection.UpdateAsync(player);
        }

        public async Task<List<Player>> GetAllProfiles()
        {
            await Init();
            List<Player> profiles = new List<Player>();

            try
            {
                profiles = (await connection.Table<PlayerEntity>().ToListAsync())
                    .Select(_mapper.Map<Player>)
                    .ToList();
                    
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }


            return profiles;
        }

        public async Task<Player?> GetById(int id)
        {
           await Init();
            try
            {
                Player? player = (await connection.Table<PlayerEntity>().ToListAsync())
                    .Select(_mapper.Map<Player>)
                    .FirstOrDefault(p => p.Id == id);
                return player;
            }
            catch(Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                
            }
            return null;
        }
    }
}
