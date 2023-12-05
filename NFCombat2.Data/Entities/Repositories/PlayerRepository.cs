using AutoMapper;
using NFCombat2.Common.Enums;
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Data.Entities.Items;
using NFCombat2.Data.Entities.Programs;
using NFCombat2.Data.Extensions;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Factories;
using NFCombat2.Models.Items;
using NFCombat2.Models.Items.Equipments;
using NFCombat2.Models.Items.Weapons;
using NFCombat2.Models.Player;
using SQLite;
using System;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;

namespace NFCombat2.Data.Entities.Repositories
{
    public class PlayerRepository
    {
        string _dbPath;
        private SQLiteAsyncConnection connection = null!;
        private IMapper _mapper;
        public string StatusMessage { get; set; } = string.Empty;
        public bool ShouldSeed { get; set; } = false;
        private async Task Init()
        {
            if (connection != null)
            {
                return;
            }
            connection = new SQLiteAsyncConnection(_dbPath);
            
            await connection.CreateTableAsync<PlayerEntity>();
            await connection.CreateTableAsync<PlayersItemsEntity>();
            await connection.CreateTableAsync<PlayersWeaponsEntity>();
            await connection.CreateTableAsync<ItemEntity>();
            await connection.CreateTableAsync<ProgramEntity>();
            await connection.CreateTableAsync<PlayersProgramsEntity>();

            if(connection.Table<PlayerEntity>() != null)
            {
                if(await connection.Table<PlayerEntity>().CountAsync() == 0) 
                {
                    ItemRepositorySeeder.SeedRepository(this);
                    //await connection.DropTableAsync<PlayerEntity>();
                    //await connection.DropTableAsync<PlayersItemsEntity>();
                    //TODO remove this, only used to clear db for testing
                }
            }

        }
        public PlayerRepository(string dbPath, IMapper mapper, bool seed)
        {
            _dbPath = dbPath;
            _mapper = mapper;
            ShouldSeed = seed;
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

        private async Task UpdateItems(Player player)
        {
            var oldEquipments = await connection.Table<PlayersItemsEntity>().Where(pi => pi.PlayerId == player.Id).ToListAsync();
            foreach (var equipment in oldEquipments)
            {
                await connection.DeleteAsync(equipment);
            }

            foreach (var item in player.Items)
            {
                PlayersItemsEntity playersItems = null!;
                try
                {
                    playersItems = await connection.GetAsync<PlayersItemsEntity>(ps => ps.PlayerId == player.Id && ps.ItemId == item.Id);
                }
                catch
                {
                    await connection.InsertAsync(new PlayersItemsEntity() { PlayerId = player.Id, ItemId = item.Id, Quantity = item.Quantity });
                    continue;
                }
                playersItems.Quantity = item.Quantity;
                await connection.UpdateAsync(playersItems);
            }
        }

        private async Task UpdateEquipments( Player player)
        {
            var oldEquipments = await connection.Table<PlayersItemsEntity>().Where(pi => pi.PlayerId == player.Id).ToListAsync();
            foreach (var equipment in oldEquipments)
            {
                await connection.DeleteAsync(equipment);
            }


            foreach (var equipment in player.Equipment)
            {
                PlayersItemsEntity playersItems = null!;
                AttachedTo attachedTo = AttachedTo.None;
                if(equipment is WeaponModification modification)
                {
                    attachedTo = modification.AttachedTo;
                }

                var allPlayersItems = await  connection.Table<PlayersItemsEntity>().ToListAsync();
                try
                {
                    playersItems = await connection.GetAsync<PlayersItemsEntity>(ps => ps.PlayerId == player.Id && ps.ItemId == equipment.Id);
                }
                catch
                {
                    var newPlayersItemsEntity = new PlayersItemsEntity() { PlayerId = player.Id, ItemId = equipment.Id, Quantity = equipment.Quantity };
                    newPlayersItemsEntity.AttachedTo = attachedTo;
                    

                    await connection.InsertAsync(newPlayersItemsEntity);
                    continue;
                }
                playersItems.Quantity = equipment.Quantity;
                playersItems.AttachedTo = attachedTo;
                
                await connection.UpdateAsync(playersItems);
            }
        }

        private async Task UpdatePrograms(Player player)
        {
            foreach(var program in player.Programs)
            {
                PlayersProgramsEntity entity = await connection.Table<PlayersProgramsEntity>()
                    .Where(pp => pp.PlayerId == player.Id && pp.ProgramId == program.Id)
                    .FirstOrDefaultAsync();

                if(entity == null)
                {
                    PlayersProgramsEntity newEntity = new PlayersProgramsEntity()
                    {
                        PlayerId = player.Id,
                        ProgramId = program.Id
                    };
                    await connection.InsertAsync(newEntity);
                }

            }
        }

        private async Task UpdateWeapons(Player player)
        {

            var oldWeapons = await connection.Table<PlayersWeaponsEntity>().Where(pw => pw.PlayerId == player.Id).ToListAsync();
            foreach (var weapon in oldWeapons)
            {
                await connection.DeleteAsync(weapon);
            }


            foreach (var weapon in player.Weapons)
            {
                if(weapon == null)
                {
                    continue;
                }
                PlayersWeaponsEntity playersItems = null!;
                
                playersItems = await connection.Table<PlayersWeaponsEntity>().FirstOrDefaultAsync(pi=> pi.ItemId == weapon.Id && pi.PlayerId == player.Id && pi.Hand == weapon.Hand);
                
                if(playersItems == null)
                {
                    
                    var newPlayersItems = new PlayersWeaponsEntity() { PlayerId = player.Id, ItemId = weapon.Id };
                    newPlayersItems.Quantity = weapon.Quantity;
                    newPlayersItems.Hand = weapon.Hand;
                    newPlayersItems.Durability = weapon.Durability;
                    await connection.InsertAsync(newPlayersItems);
                    var allPlayersItems = await connection.Table<PlayersWeaponsEntity>().ToListAsync();
                    continue;
                }
                playersItems.Hand = weapon.Hand;
                playersItems.Durability = weapon.Durability;
                await connection.UpdateAsync(playersItems);
                    var allPlayersItems2 = await connection.Table<PlayersWeaponsEntity>().ToListAsync();
            }
        }

        public async Task UpdatePlayer(Player player)
        {
            await Init();
            var entity = _mapper.Map<PlayerEntity>(player);
            await UpdateItems(player);
            await UpdateEquipments(player);
            await UpdateWeapons(player);
            await UpdatePrograms(player);
            await UpdateEntity(entity);
        }

        private async Task RetrievePlayerData(Player player)
        {
            var playersItemsEntities = await connection.Table<PlayersItemsEntity>().Where(pi => pi.PlayerId == player.Id).ToListAsync();
            foreach (var playersItemsEntity in playersItemsEntities)
            {
                var entity = await connection.GetAsync<ItemEntity>(playersItemsEntity.ItemId);
                if (!entity.Id.HasValue)
                {
                    throw new NullReferenceException();
                }
                int itemId = entity.Id.Value;
                AttachedTo attachedTo = playersItemsEntity.AttachedTo;
                switch (entity.Category)
                {
                    case ItemCategory.Item:
                        var item = (Item)ItemConverter(entity.Type, entity.Category, itemId);
                        item.Quantity = playersItemsEntity.Quantity;
                        player.Items.Add(item);
                        break;
                    case ItemCategory.Equipment:
                        var equipment = (Equipment)ItemConverter(entity.Type, entity.Category, itemId, attachedTo);
                        equipment.Quantity = playersItemsEntity.Quantity;
                        player.Equipment.Add(equipment);
                        break;
                }
            }

            var playersWeaponsEntities = await connection.Table<PlayersWeaponsEntity>().Where(pi => pi.PlayerId == player.Id).ToListAsync();
            foreach (var playersWeaponsEntity in playersWeaponsEntities)
            {

                var entity = await connection.GetAsync<ItemEntity>(playersWeaponsEntity.ItemId);
                if (!entity.Id.HasValue)
                {
                    throw new NullReferenceException();
                }
                int itemId = entity.Id.Value;
                switch (playersWeaponsEntity.Hand)
                {
                    case Hand.MainHand:
                        player.MainHand = (Weapon)ItemConverter(entity.Type, entity.Category, itemId, playersWeaponsEntity.Hand);
                        break;
                    case Hand.OffHand:
                        player.OffHand = (Weapon)ItemConverter(entity.Type, entity.Category, itemId, playersWeaponsEntity.Hand);
                        break;
                }
                
            }

            foreach(Equipment equipment in player.Equipment)
            {
                if(equipment is WeaponModification modification)
                {
                    if(modification.AttachedTo == AttachedTo.MainHand)
                    {
                        modification.AttachToWeapon(player.MainHand);
                    }else if(modification.AttachedTo == AttachedTo.OffHand)
                    {
                        modification.AttachToWeapon(player.OffHand);
                    }
                }
            }
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
                foreach (var player in players)
                {
                    //RetrievePlayerData(player);
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
                if (player != null)
                {
                    await RetrievePlayerData(player);
                }

                return player;
                
                
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
            return ItemConverter(entity.Type, entity.Category, id);
        }

        public async Task<ICollection<IAddable>> GetItemsByCategory(ItemCategory category)
        {
            await Init();
            var entities = await connection.Table<ItemEntity>().Where(i=> i.Category == category).ToListAsync();
            List<IAddable> items = new List<IAddable>();
            foreach (var entity in entities)
            {
                if (!entity.Id.HasValue)
                {
                    throw new NullReferenceException();
                }
                var itemId = entity.Id.Value;
                var item = ItemConverter(entity.Type, entity.Category, itemId);
                
                items.Add(item);
            }
            return items;

        }

        

        private IAddable ItemConverter(ItemType type, ItemCategory category, int itemId, params object[] args)
        {
            if(category == ItemCategory.Weapon)
            {
                return WeaponFactory.GetWeapon(type, itemId, args);
            }
            else
            {
                string typeName = type.ToString();
                string[] itemLocations = new string[] { "Equipments", "Items", "ActiveEquipments", "Weapons" };


                foreach (var itemLocation in itemLocations)
                {
                    string fullTypeName = $"NFCombat2.Models.Items.{itemLocation}.{typeName}, NFCombat2.Models";
                    Type? itemType = Type.GetType(fullTypeName);
                    if (itemType != null)
                    {
                        var item = (Item?)Activator.CreateInstance(itemType);
                        if (item == null)
                        {
                            throw new NullReferenceException();

                        }
                        item.Id = itemId;
                        item.Type = type;
                        if(item is WeaponModification modification && args.Length > 0)
                        {
                            if (args[0] is AttachedTo attachedTo)
                            {
                                modification.AttachedTo = attachedTo;
                            }
                        }
                        
                        return item;
                    }
                }

                throw new InvalidCastException(typeName);
            }
            
            
        }




    }
}
