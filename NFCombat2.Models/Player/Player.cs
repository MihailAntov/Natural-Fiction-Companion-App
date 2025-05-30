﻿

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items;
using NFCombat2.Models.Items.Equipments;
using NFCombat2.Models.Items.Parts;
using NFCombat2.Models.Items.Weapons;
using NFCombat2.Models.Programs;
using NFCombat2.Models.SpecOps;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.Models.Player
{
    public class Player : INotifyPropertyChanged
    {
        
        public int Id { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if(name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        private int health = 30;

        public event PropertyChangedEventHandler PropertyChanged;


        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value > MaxHealth)
                {
                    value = MaxHealth;
                }

                if(health != value)
                {
                    health = value;
                    HealthHasChanged = true;
                    OnPropertyChanged(nameof(Health));
                    OnPropertyChanged(nameof(Strength));
                }
            }
        }

        public bool HealthHasChanged { get; set; } = false;
        private int _baseMaxHealth = 30;
        public int BaseMaxHealth { get { return _baseMaxHealth; } set 
            {
                if(_baseMaxHealth != value)
                {
                    _baseMaxHealth = value;
                    OnPropertyChanged(nameof(MaxHealth));
                }
            }
        }
        private int _bonusMaxHealth = 0;
        public int BonusMaxHealth { get { return _bonusMaxHealth; } set 
            {
                if(_bonusMaxHealth != value)
                {
                    _bonusMaxHealth = value;
                    OnPropertyChanged(nameof(MaxHealth));
                }
            }
        }
        //todo : notifypropchanged
        public int MaxHealth
        {
            //get
            //{
            //    return BaseMaxHealth + Equipment.Where(e=> e is IModifyPlayer).Select(e=> (e as IModifyPlayer).BonusHealth).Sum();
            //}
            get
            {
                return BaseMaxHealth + BonusMaxHealth;
            }
            
        }

        public int MinHealth { get; set; } = 1;

        private bool _hasExtraBag;
        public bool HasExtraBag { get { return _hasExtraBag; } 
            set 
            {
                if(_hasExtraBag != value)
                {
                    _hasExtraBag = value;
                    OnPropertyChanged(nameof(HasExtraBag)); 
                }
            }
        }

        private int _credits;
        public int Credits { get { return _credits; } set
            {
                if(_credits != value)
                {
                    _credits = value;
                    OnPropertyChanged(nameof(Credits));
                }
            } 
        }

        private bool _hasShuttle;
        public bool HasShuttle { get { return _hasShuttle; } set
            {
                if (_hasShuttle != value)
                {
                    _hasShuttle = value;
                    OnPropertyChanged(nameof(HasShuttle));
                }
            } 
        }
        public bool IsEngineer => Class == PlayerClass.Engineer;
        public int InventorySlots => HasExtraBag ? 13 : 10;


        public int StrengthWithoutWeapon =>
            BaseStrength +
            BonusStrength;
        public int Strength =>
            BaseStrength +
            BonusStrength +
            WeaponStrength;
            //Weapons.OfType<MeleeWeapon>().Sum(w => w.ExtraStrength);
        public int BaseStrength 
        { 
            get 
            {
                if(Techniques.Values.Any(t=> t is FightingSpirit))
                {
                    return (Class == PlayerClass.Engineer ? 1 : 0) + (int)Math.Round(MaxHealth / 10.0, MidpointRounding.AwayFromZero);
                }
                return (Class == PlayerClass.Engineer ? 1 : 0) + (int)Math.Round(Health / 10.0, MidpointRounding.AwayFromZero); 
            } 
        }
        private int _weaponStrength;
        public int WeaponStrength
        {
            get { return _weaponStrength; }
            set
            {
                if(_weaponStrength != value)
                {
                    _weaponStrength = value;
                    OnPropertyChanged(nameof(Strength));
                }
            }
        }
        private int _bonusMaxStrength = 0;
        public int BonusStrength { get { return _bonusMaxStrength; }
            set
            {
                if(_bonusMaxStrength != value)
                {
                    _bonusMaxStrength = value;
                    OnPropertyChanged(nameof(Strength));
                }
            }
        } 
        public int MaxWeaponWeight { get; set; } = 1;
        public List<Weapon> Weapons
        {
            get
            {
                var weapons = new List<Weapon>();
                if(MainHand != null)
                {
                    weapons.Add(MainHand);
                }
                if (OffHand != null)
                {
                    weapons.Add(OffHand);
                }
                return weapons;
            }
        }
        private Weapon _mainHand;
        public Weapon MainHand { get { return _mainHand; } 
            set 
            {
                if(_mainHand != value)
                {
                    _mainHand = value;
                    OnPropertyChanged(nameof(MainHand));
                }
            }
        }
        private Weapon _offHand;
        public Weapon OffHand { get { return _offHand; } 
            set
            {
                if(_offHand != value)
                {
                    _offHand = value;
                    OnPropertyChanged(nameof(OffHand));
                }
            }
        }
        public IList<Equipment> Equipment { get; set; } = new List<Equipment>();
        //public IList<ICombatActiveItem> Consumables { get; set; } = new List<ICombatActiveItem>();
        public IList<ICombatActiveItem> Activatables
        {
            get
            {
                var result = new List<ICombatActiveItem>(); 
                foreach(var equipment in Equipment.OfType<ICombatActiveItem>())
                {
                    result.Add(equipment);
                }

                foreach (var item in Items.OfType<ICombatActiveItem>())
                {
                    result.Add(item);
                }

                foreach (var item in ExtraItems.OfType<ICombatActiveItem>())
                {
                    result.Add(item);
                }
                return result;
            }
        }

        public IList<Item> Items { get; set; } = new List<Item>();
        public IList<Item> ExtraItems { get; set; } = new List<Item>();

        public Dictionary<int, Technique> Techniques { get; set; } = new Dictionary<int, Technique>()
        {
            {30,null },
            {25,null },
            {20,null },
            {15,null },
            {10,null },
            {5,null },
            {1,null },
        };
        public IList<Program> Programs { get; set; } = new List<Program>();
        public string ProgramList { get; set; } = String.Empty;
        public virtual IList<IModifyAction> ActionModifiers 
        {
            get
            {
                var result = new List<IModifyAction>();
                if (MainHand is IModifyAction mainHand)
                {
                    result.Add(mainHand);
                }
                if (OffHand is IModifyAction offHand)
                {
                    result.Add(offHand);
                }
                result.AddRange(Equipment.OfType<IModifyAction>());
                result.AddRange(Items.OfType<IModifyAction>());
                result.AddRange(Techniques.Values.OfType<IModifyAction>());
                return result;
            }
        }

        public virtual IList<IModifyAccuracy> AccuracyModifiers
        {
            get
            {
                var result = new List<IModifyAccuracy>();
                if (MainHand is IModifyAccuracy mainHand)
                {
                    result.Add(mainHand);
                }
                if (OffHand is IModifyAccuracy offHand)
                {
                    result.Add(offHand);
                }
                result.AddRange(Equipment.OfType<IModifyAccuracy>());
                result.AddRange(Items.OfType<IModifyAccuracy>());
                result.AddRange(Techniques.Values.OfType<IModifyAccuracy>());
                return result;
            }
        }
        public virtual IList<IModifyResolution> ResolutionModifiers
        {
            get
            {
                var result = new List<IModifyResolution>();
                if(MainHand is IModifyResolution mainHand)
                {
                    result.Add(mainHand);
                }
                if (OffHand is IModifyResolution offHand)
                {
                    result.Add(offHand);
                }
                result.AddRange(Equipment.OfType<IModifyResolution>());
                result.AddRange(Items.OfType<IModifyResolution>());
                result.AddRange(Techniques.Values.OfType<IModifyResolution>());
                return result;
            }
        }
        private PlayerClass _class = PlayerClass.None;
        public PlayerClass Class
        {
            get { return _class; }
            set
            {
                if(_class != value)
                {
                    if(_class == PlayerClass.Soldier)
                    {
                        BonusMaxHealth -= 20;
                        MaxIonization -= 1;
                        MaxTrauma -= 1;
                        MaxPathogens -= 1;
                        MaxWeaponWeight -= 1;
                    }else if (value == PlayerClass.Soldier)
                    {
                        BonusMaxHealth += 20;
                        MaxIonization += 1;
                        MaxTrauma += 1;
                        MaxPathogens += 1;
                        MaxWeaponWeight += 1;
                    }

                    if (_class == PlayerClass.Hacker)
                    {
                        BonusMaxHealth += 5;
                    }
                    else if (value == PlayerClass.Hacker)
                    {
                        BonusMaxHealth -= 5;
                    }



                    _class = value;
                    OnPropertyChanged(nameof(Class));
                    OnPropertyChanged(nameof(Strength));
                }
            }
        }
        //public IList<Part> Parts { get; set; } = new List<Part>();
        public PartBag PartsBag { get; set; } = new PartBag();
        private int trauma = 0;
        public int Trauma
        {
            get { return trauma; }
            set
            {
                if (trauma != value)
                {
                    trauma = value;
                    OnPropertyChanged(nameof(Trauma));
                }
            }
        }

        private int maxTrauma = 3;
        public int MaxTrauma
        {
            get { return maxTrauma; }
            set
            {
                if (maxTrauma != value)
                {
                    maxTrauma = value;
                    OnPropertyChanged(nameof(MaxTrauma));
                }
            }
        }

        private int ionization = 0;
        public int Ionization
        {
            get { return ionization; }
            set
            {
                if (ionization != value)
                {
                    ionization = value;
                    OnPropertyChanged(nameof(Ionization));
                }
            }
        }

        private int maxIonization = 3;
        public int MaxIonization
        {
            get { return maxIonization; }
            set
            {
                if (maxIonization != value)
                {
                    maxIonization = value;
                    OnPropertyChanged(nameof(MaxIonization));
                }
            }
        }

        private int pathogens = 0;
        public int Pathogens
        {
            get { return pathogens; }
            set
            {
                if (pathogens != value)
                {
                    pathogens = value;
                    OnPropertyChanged(nameof(Pathogens));
                }
            }
        }

        private int maxPathogens = 3;
        public int MaxPathogens
        {
            get { return maxPathogens; }
            set
            {
                if (maxPathogens != value)
                {
                    maxPathogens = value;
                    OnPropertyChanged(nameof(MaxPathogens));
                }
            }
        }
        private int speed = 3;
        public int Speed
        {
            get { return speed; }
            set
            {
                if(speed != value)
                {
                    speed = value;
                    OnPropertyChanged(nameof(Speed));
                }
            }
        }
        private int _overload;
        public int Overload
        {
            get { return _overload; }
            set
            {
                if(_overload != value)
                {
                    _overload = value;
                    OnPropertyChanged(nameof(Overload));
                }
            }
        }
        private int _maxOverload = 12;
        public int MaxOverload
        {
            get { return _maxOverload; }
            set
            {
                if(_maxOverload != value) 
                {
                    _maxOverload = value;
                    OnPropertyChanged(nameof(MaxOverload));
                }
            }
        }

        public Language Language { get; set; } = Language.English;

        private int _fuel;
        public int Fuel { get { return _fuel; } 
            set 
            {
                if(_fuel != value)
                {
                    _fuel = value;
                    OnPropertyChanged(nameof(Fuel));
                }
            }
        }

        

        //private int _maxFuel;
        //public int MaxFuel
        //{
        //    get { return _maxFuel; }
        //    set
        //    {
        //        if (_maxFuel != value)
        //        {
        //            _maxFuel = value;
        //            OnPropertyChanged(nameof(MaxFuel));
        //        }
        //    }
        //}

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
