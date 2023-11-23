using AutoMapper;
using NFCombat2.Common.Enums;
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Data.Entities.Items;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items;
using NFCombat2.Models.Items.Equipments;
using NFCombat2.Models.Items.Weapons;
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
        public bool Seeded { get; set; } = false;
        private async Task Init()
        {
            if (connection != null)
            {
                return;
            }
            connection = new SQLiteAsyncConnection(_dbPath);
            
            await connection.CreateTableAsync<PlayerEntity>();
            await connection.CreateTableAsync<PlayersItemsEntity>();
            await connection.CreateTableAsync<ItemEntity>();

            if(connection.Table<PlayerEntity>() != null)
            {
                if(await connection.Table<PlayerEntity>().CountAsync() > 0) 
                {
                    Seeded = true;
                    //await connection.DropTableAsync<PlayerEntity>();
                    //await connection.DropTableAsync<PlayersItemsEntity>();
                    //TODO remove this, only used to clear db for testing
                }
            }

        }
        public PlayerRepository(string dbPath, IMapper mapper)
        {
            _dbPath = dbPath;
            _mapper = mapper;
            Init();
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

        private async Task UpdateEntity(PlayerEntity player)
        {
            await Init();
            await connection.UpdateAsync(player);
        }

        public async Task UpdatePlayer(Player player)
        {
            await Init();
            var entity = _mapper.Map<PlayerEntity>(player);
            
            foreach(var item in player.Items)
            {
                PlayersItemsEntity playersItems = null!;
                try
                {
                    playersItems = await connection.GetAsync<PlayersItemsEntity>(ps=>  ps.PlayerId == player.Id && ps.ItemId == item.Id);
                }
                catch
                {
                    await connection.InsertOrReplaceAsync(new PlayersItemsEntity() { PlayerId = player.Id, ItemId = item.Id});
                    continue;
                }
                playersItems.Quantity++;
                await connection.UpdateAsync(playersItems);
            }

            await UpdateEntity(entity);
        }

        public async Task<List<Player>> GetAllProfiles()
        {
            await Init();
            List<Player> players = new List<Player>();

            try
            {

                players = (await connection.Table<PlayerEntity>().ToListAsync())
                    .Select(_mapper.Map<Player>)
                    .ToList();
                foreach(var player in players)
                {
                    var playersItemsEntities = await connection.Table<PlayersItemsEntity>().Where(pi => pi.PlayerId == player.Id).ToListAsync();
                    foreach(var playersItemsEntity in playersItemsEntities)
                    {
                        var allitems = await connection.Table<ItemEntity>().ToListAsync();
                        var allplayers = await connection.Table<PlayerEntity>().ToListAsync();
                        var allPlayersItems = await connection.Table<PlayersItemsEntity>().ToListAsync();
                        var entity = await connection.GetAsync<ItemEntity>(playersItemsEntity.ItemId);
                        switch (entity.Category)
                        {
                            case ItemCategory.Item:
                                player.Items.Add((Item)ItemConverter(entity.Type, entity.Category));
                                break;
                            case ItemCategory.Weapon:
                                player.Weapons.Add((Weapon)ItemConverter(entity.Type, entity.Category));
                                break;
                            case ItemCategory.Equipment:
                                player.Equipment.Add((Equipment)ItemConverter(entity.Type, entity.Category));
                                break;
                        }
                    }
                }
                



            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            

            return players;
        }

        public async Task<Player?> GetPlayerById(int id)
        {
           await Init();
            try
            {
                Player? player = (await connection.Table<PlayerEntity>().ToListAsync())
                    .Select(_mapper.Map<Player>)
                    .FirstOrDefault(p => p.Id == id);
                var playersItemsEntities = await connection.Table<PlayersItemsEntity>().Where(pi => pi.PlayerId == player.Id).ToListAsync();
                if (player != null)
                {
                    foreach (var playersItemsEntity in playersItemsEntities)
                    {
                        var entity = await connection.GetAsync<ItemEntity>(playersItemsEntity.ItemId);
                        switch (entity.Category)
                        {
                            case ItemCategory.Item:
                                player.Items.Add((Item)ItemConverter(entity.Type, entity.Category));
                                break;
                            case ItemCategory.Weapon:
                                player.Weapons.Add((Weapon)ItemConverter(entity.Type, entity.Category));
                                break;
                            case ItemCategory.Equipment:
                                player.Equipment.Add((Equipment)ItemConverter(entity.Type, entity.Category));
                                break;
                        }

                        
                }
                    return player;
                }
                
                
            }
            catch(Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                
            }
            return null;
        }

        public async Task InsertRange<ItemEntity>(IEnumerable<ItemEntity> items)
        {
            await Init();
            await connection.InsertAllAsync(items);
        }

        public async Task<int> DeleteAllItems()
        {
            await Init();
            int result = 0;
            result +=  await connection.DropTableAsync<ItemEntity>();
            await connection.CreateTableAsync<ItemEntity>();
            result += await connection.DropTableAsync<PlayersItemsEntity>();
            await connection.CreateTableAsync<PlayersItemsEntity>();
            return result;

        }
        public async Task<IAddable> GetItemById(int id)
        {
            await Init();
            var entity =  await connection.GetAsync<ItemEntity>(id);
            return ItemConverter(entity.Type, entity.Category);
        }

        public async Task<ICollection<IAddable>> GetItemsByCategory(ItemCategory category)
        {
            await Init();
            var entities = await connection.Table<ItemEntity>().Where(i=> i.Category == category).ToListAsync();
            List<IAddable> items = new List<IAddable>();
            foreach (var entity in entities)
            {
                var item = ItemConverter(entity.Type, entity.Category);
                if (entity.Id.HasValue)
                {
                    item.Id = entity.Id.Value;
                }

                items.Add(item);
                //TODO : figure out a way to transfer id
            }
            return items;

        }

        public async Task<ICollection<IAddable>> GetAllItems()
        {
            await Init();
            var entities = await connection.Table<ItemEntity>().ToListAsync();
            List<IAddable> items = new List<IAddable>();
            foreach(var entity in entities)
            {
                items.Add(ItemConverter(entity.Type, entity.Category));
            }
            return items;
        }

        private IAddable ItemConverter(ItemType type, ItemCategory category)
        {
            
            
            string typeName = type.ToString();
            string[] itemLocations = new string[] { "Equipments", "Items", "ActiveEquipments", "Weapons" };


            foreach (var itemLocation in itemLocations)
            {
                string fullTypeName = $"NFCombat2.Models.Items.{itemLocation}.{typeName}, NFCombat2.Models";
                Type itemType = Type.GetType(fullTypeName);
                if (itemType != null)
                {
                    var item = Activator.CreateInstance(itemType);

                    return (Item)item;
                }
            }

            var item2 = Activator.CreateInstance(typeof(GrenadeLauncher));
            return (Item)item2;
        }




    }
}
