using AutoMapper;
using NFCombat2.Common.Enums;
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Data.Entities.Items;
using NFCombat2.Data.Entities.Programs;
using NFCombat2.Data.Extensions;
using NFCombat2.Data.Helpers;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Factories;
using NFCombat2.Models.Items;
using NFCombat2.Models.Items.Equipments;
using NFCombat2.Models.Items.Parts;
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

            //await connection.DropTableAsync<PlayerEntity>();
            //await connection.DropTableAsync<PlayersItemsEntity>();
            //await connection.DropTableAsync<PlayersEquipmentsEntity>();
            //await connection.DropTableAsync<PlayersWeaponsEntity>();
            //await connection.DropTableAsync<ItemEntity>();
            //await connection.DropTableAsync<ProgramEntity>();
            //await connection.DropTableAsync<PlayersProgramsEntity>();
            //Uncomment above lines to reset item db

            await connection.CreateTableAsync<PlayerEntity>();
            await connection.CreateTableAsync<PlayersItemsEntity>();
            await connection.CreateTableAsync<PlayersEquipmentsEntity>();
            await connection.CreateTableAsync<PlayersWeaponsEntity>();
            await connection.CreateTableAsync<ItemEntity>();
            await connection.CreateTableAsync<ProgramEntity>();
            await connection.CreateTableAsync<PlayersProgramsEntity>();
            await connection.CreateTableAsync<PlayersPartsBagEntity>();
            await connection.CreateTableAsync<PartBagEntity>();

            if(connection.Table<PlayerEntity>() != null)
            {
                
                if (await connection.Table<PlayerEntity>().CountAsync() == 0) 
                {
                    ItemRepositorySeeder.SeedRepository(this);
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
            var allItems = new List<Item>();
            allItems.AddRange(player.Items);
            allItems.AddRange(player.ExtraItems);

            var existingItems = await connection.Table<PlayersItemsEntity>()
                .Where(pi => pi.PlayerId == player.Id).ToListAsync();
            var removedItems = existingItems.Where(i=> !allItems.Select(item=> item.Id).Contains(i.ItemId)).ToList();
            foreach (var item in removedItems)
            {
                await connection.DeleteAsync(item);
            }

            
            foreach (var item in allItems)
            {
                PlayersItemsEntity playersItems = null!;
                try
                {
                    playersItems = await connection.GetAsync<PlayersItemsEntity>(ps => ps.PlayerId == player.Id && ps.ItemId == item.Id && ps.InExtraBag == item.InExtraBag);
                }
                catch
                {
                    await connection.InsertAsync(new PlayersItemsEntity() 
                    { 
                        PlayerId = player.Id,
                        ItemId = item.Id,
                        Quantity = item.Quantity,
                        InExtraBag = item.InExtraBag,
                    });
                    continue;
                }
                playersItems.Quantity = item.Quantity;
                playersItems.InExtraBag = item.InExtraBag;
                await connection.UpdateAsync(playersItems);
            }

           

            var existingrecords = await connection.Table<PlayersItemsEntity>().ToListAsync();
        }

        private async Task UpdateEquipments( Player player)
        {
            var oldEquipments = await connection.Table<PlayersEquipmentsEntity>().Where(pi => pi.PlayerId == player.Id).ToListAsync();
            foreach (var equipment in oldEquipments)
            {
                await connection.DeleteAsync(equipment);
            }


            foreach (var equipment in player.Equipment)
            {
                AttachedTo attachedTo = AttachedTo.None;
                if(equipment is WeaponModification modification)
                {
                    attachedTo = modification.AttachedTo;
                }

                var newPlayersEquipmentsEntity = new PlayersEquipmentsEntity() 
                {
                    PlayerId = player.Id, 
                    EquipmentId = equipment.Id, 
                    IsConsumable = equipment.IsConsumable,
                    Quantity = equipment.Quantity
                };
                newPlayersEquipmentsEntity.AttachedTo = attachedTo;
                    

                await connection.InsertAsync(newPlayersEquipmentsEntity);
                continue;
                
            }
        }

        private async Task UpdateParts(Player player)
        {
            // TODO: check if exists, create if not
            PlayersPartsBagEntity playerEntity = await connection.Table<PlayersPartsBagEntity>()
                .Where(e=> e.PlayerId == player.Id)
                .FirstOrDefaultAsync();
            var bagId = playerEntity.PartsBagId;
            PartBagEntity bagEntity = await connection.Table<PartBagEntity>()
                .FirstOrDefaultAsync(b=> b.Id == bagId);

            PartsMapper.SaveParts(player.PartsBag, bagEntity);
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
            await UpdateParts(player);
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
                
                var item = (Item)ItemConverter(entity.Type,entity.Category, itemId);
                item.Quantity = playersItemsEntity.Quantity;
                item.InExtraBag = playersItemsEntity.InExtraBag;
                if (item.InExtraBag)
                {
                    player.ExtraItems.Add(item);
                    continue;
                }
                player.Items.Add(item);
                continue;
                
                
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
                        player.MainHand = (Weapon)ItemConverter(entity.Type, entity.Category, itemId, playersWeaponsEntity.Hand, playersWeaponsEntity.Durability);
                        break;
                    case Hand.OffHand:
                        player.OffHand = (Weapon)ItemConverter(entity.Type, entity.Category, itemId, playersWeaponsEntity.Hand, playersWeaponsEntity.Durability);
                        break;
                }
                
            }

            var playersEquipmentsEntitites = await connection.Table<PlayersEquipmentsEntity>().Where(pi => pi.PlayerId == player.Id).ToListAsync();
            foreach (var playersEquipmentsEntity in playersEquipmentsEntitites)
            {
                var entity = await connection.GetAsync<ItemEntity>(playersEquipmentsEntity.EquipmentId);
                if (!entity.Id.HasValue)
                {
                    throw new NullReferenceException();
                }
                int equipmentId = entity.Id.Value;
                
                var equipment = (Equipment)ItemConverter(entity.Type, entity.Category, equipmentId, playersEquipmentsEntity.AttachedTo);
                equipment.Quantity = playersEquipmentsEntity.Quantity;
                player.Equipment.Add(equipment);
            }

            foreach (Equipment equipment in player.Equipment)
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

                if(equipment is IModifyPlayer playerModification)
                {
                    playerModification.OnAdded(player);
                }
            }

            var playersPartsBagEntity = await connection.Table<PlayersPartsBagEntity>()
                .Where(pb => pb.PlayerId == player.Id).FirstOrDefaultAsync();
            var bagEntity = await connection.GetAsync<PartBagEntity>(playersPartsBagEntity.PartsBagId);
            PartsMapper.LoadParts(bagEntity, player.PartsBag);

            
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
                var allPlayers = await connection.Table<PlayerEntity>().ToListAsync();
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
                //TODO quantity


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
                        item.ItemType = type;
                        
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
