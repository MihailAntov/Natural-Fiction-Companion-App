using NFCombat2.Common.AppConstants;
using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Fights;
using static NFCombat2.Common.AppConstants.ItemNames;
using static NFCombat2.Common.AppConstants.Labels;
using static NFCombat2.Common.AppConstants.ModeNames;
using static NFCombat2.Common.AppConstants.FightResults;
using static NFCombat2.Common.AppConstants.Options;
using static NFCombat2.Common.AppConstants.EnemyNames;
using static NFCombat2.Common.AppConstants.PartNames;
using static NFCombat2.Common.AppConstants.CraftResults;
using static NFCombat2.Common.AppConstants.ClassNames;
using static NFCombat2.Common.AppConstants.ProgramComponentNames;
using static NFCombat2.Common.AppConstants.ProgramDescriptions;
using static NFCombat2.Common.AppConstants.ProgramNames;
using static NFCombat2.Common.AppConstants.DiceMessages;
using static NFCombat2.Common.AppConstants.TechniqueNamesAndDescriptions;
using static NFCombat2.Common.AppConstants.HandNames;
using static NFCombat2.Common.AppConstants.Messages;
using NFCombat2.Models.Contracts;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.Services
{
    public class NameService : INameService, INotifyPropertyChanged
    {
        private readonly ISettingsService _settingsService;
        private Language _language = Language.None;
        public Language Language { 
            get 
            { if (_language == Language.None) 
                {
                    _language = _settingsService.Language;
                    OnPropertyChanged(nameof(Language));
                }
                return _language;
            } 
            set 
            { 
                if(_language != value)
                {
                    _language = value;
                    OnPropertyChanged(nameof(Language));
                }
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public NameService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
            _settingsService.PropertyChanged += OnLanguagePropertyChanged;
        }

        public void OnLanguagePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_settingsService.Language))
            {
                Language = _settingsService.Language;
            }
        }
        public string ItemName(ItemType type)
        {
            try
            {
                //return EnglishItems[type];
                switch (Language)
                {
                    
                    case Language.English:
                        return EnglishItems[type];
                    case Language.Bulgarian:
                    default:
                        return BulgarianItems[type];
                }
            }
            catch
            {
                return "not found";
            }
        }

        public string ItemDescription(ItemType type)
        {
            try
            {
                switch (Language)
                {
                    case Language.English:
                        return EnglishItems[type];
                    case Language.Bulgarian:
                    default:
                        return BulgarianItems[type];
                }
            }
            catch
            {
                return "not found";
            }
        }

        public string Label(LabelType type)
        {
            try
            {
                switch (Language)
                {
                    
                    case Language.English:
                        return EnglishLabels[type];
                    case Language.Bulgarian:
                    default:
                        return BulgarianLabels[type];
                }
            }
            catch
            {
                return "not found";
            }
        }

        public string ProgramName(ProgramType type)
        {
            try
            {
                switch (Language)
                {
                    case Language.English:
                        return EnglishProgramNames[type];
                    case Language.Bulgarian:
                    default:
                        return BulgarianProgramNames[type];
                }

            }
            catch
            {
                return "Not Found";
            }
        }

        public string ModeName(ItemMode mode)
        {
            try
            {
                switch (Language)
                {
                    case Language.English:
                        return EnglishModes[mode];
                    case Language.Bulgarian:
                    default:
                        return BulgarianModes[mode];
                }

            }
            catch
            {
                return "Not Found";
            }

        }

        public string FightResultMessage(Fight fight)
        {
            
            try
            {
                switch (Language)
                {
                    case Language.English:
                        return EnglishFightResults[(fight.Type, fight.Result)];
                    case Language.Bulgarian:
                    default:
                        return BulgarianFightResults[(fight.Type,fight.Result)];
                }

            }
            catch
            {
                return "Not Found";
            }

        }

        public string Option(OptionType option, CheckType checkType = CheckType.None, int healthCost = 0)
        {
            string text;
            switch (Language)
            {
                case Language.English:
                    text = EnglishOptions[(option, checkType)];
                    break;
                case Language.Bulgarian:
                default:
                    text = BulgarianOptions[(option, checkType)];
                    break;
            }
            
            if (healthCost != 0)
            {
                return String.Format(text, healthCost);
            }
            return text;
        }

        public string InfoMessage(Fight fight)
        {
            

            if (fight is SkillCheckFight skillCheck)
            {
                if (skillCheck.CountWins)
                {
                    switch (Language)
                    {
                        case Language.English:
                            return String.Format(EnglishMessages[MessageType.WonRoundsCount],skillCheck.WonRounds);
                        case Language.Bulgarian:
                        default:
                            return String.Format(BulgarianMessages[MessageType.WonRoundsCount], skillCheck.WonRounds);
                    }
                }
            }
            return string.Empty;
        }

        public string EnemyName(EnemyType enemyType)
        {
            try
            {
                switch (Language)
                {
                    case Language.English:
                        return EnglishEnemies[enemyType];
                    case Language.Bulgarian:
                    default:
                        return BulgarianEnemies[enemyType];
                }
            }
            catch
            {
                return "Not Found";
            }
        }

        public void RetrieveFightNames(Fight fight)
        {
            // TODO
            var enemies = Language == Language.English ? EnglishEnemies : BulgarianEnemies;

            if(fight is TentacleFight tentacleFight)
            {
                tentacleFight.TraumaTentacleName = enemies[EnemyType.TraumaTentacle];
                tentacleFight.PathogensTentacleName = enemies[EnemyType.PathogenTentacle];
                tentacleFight.IonizationTentacleName = enemies[EnemyType.IonizationTentacle];
            }

            var items = Language == Language.English ? EnglishItems : BulgarianItems;
            foreach(var enemy in fight.Enemies)
            {
                enemy.Name = enemies[enemy.EnemyType];
                if(enemy.EnemyType == EnemyType.CommanderKabuto)
                {
                    enemy.Weapons[0].Name = items[ItemType.KabutoMainHand];
                    enemy.Weapons[1].Name = items[ItemType.KabutoOffHand];
                    //TODO FIX THIS SHIT ?
                    
                }
            }
        }

        public string PartCategoryName(PartCategoryType category)
        {
            try
            {
                switch (Language)
                {
                    case Language.English:
                        return EnglishPartCategories[category];
                    case Language.Bulgarian:
                    default:
                        return BulgarianPartCategories[category];
                }
            }
            catch
            {
                return "Not Found";
            }
        }

        public string PartName(PartType partType)
        {
            try
            {
                switch (Language)
                {
                    case Language.English:
                        return EnglishParts[partType];
                    case Language.Bulgarian:
                    default:
                        return BulgarianParts[partType];
                }

            }
            catch
            {
                return "Not Found";
            }
        }

        public string CraftResultMessage(CraftResult result, IAddable item = null)
        {
            try
            {
                //todo
                var craftResults = Language == Language.English ? EnglishCraftResults : BulgarianCraftResults;
                string format = craftResults[result];
                if(item != null)
                {
                    string name = ItemName(item.ItemType);
                    return string.Format(format, name);
                }
                return craftResults[result];

            }
            catch
            {
                return "Not Found";
            }
        }

        public string ClassName(PlayerClass className)
        {
            try
            {
                switch (Language)
                {
                    case Language.English:
                        return EnglishClassNames[className];
                    case Language.Bulgarian:
                    default:
                        return BulgarianClassNames[className];
                }
            }
            catch
            {
                return "Not Found";
            }
        }

        public string ProgramComponentName(ProgramComponentType type)
        {
            try
            {
                switch (Language)
                {
                    case Language.English:
                        return EnglishProgramComponentNames[type];
                    case Language.Bulgarian:
                    default:
                        return BulgarianProgramComponentNames[type];
                }

            }
            catch
            {
                return "Not Found";
            }
        }

        public string ProgramDescription(ProgramType type)
        {
            try
            {
                switch (Language)
                {
                    case Language.English:
                        return EnglishProgramDescriptions[type];
                    case Language.Bulgarian:
                    default:
                        return BulgarianProgramDescriptions[type];
                }
            }
            catch
            {
                return "Not Found";
            }
        }

        public string DiceMessage(DiceMessageType messageType, string[] messageArgs)
        {
            try
            {
                var diceMessages = Language == Language.English ? EnglishDiceMessages : BulgarianDiceMessages;
                var format = diceMessages[messageType];
                return String.Format(format, messageArgs);
            }
            catch
            {
                return "Not Found";
            }
        }

        public string TechniqueName(TechniqueType techniqueType)
        {
            try
            {
                switch (Language)
                {
                    case Language.English:
                        return EnglishTechniqueNames[techniqueType];
                    case Language.Bulgarian:
                    default:
                        return BulgarianTechniqueNames[techniqueType];
                }
            }
            catch
            {
                return "Not Found";
            }
        }

        public string TechniqueDescription(TechniqueType techniqueType)
        {
            try
            {
                switch (Language)
                {
                    case Language.English:
                        return EnglishTechniqueDescriptions[techniqueType];
                    case Language.Bulgarian:
                    default:
                        return BulgarianTechniqueDescriptions[techniqueType];
                }
                
            }
            catch
            {
                return "Not Found";
            }
        }

        public string HandName(Hand hand)
        {
            try
            {
                switch (Language)
                {
                    case Language.English:
                        return EnglishHandNames[hand];
                    case Language.Bulgarian:
                    default:
                        return BulgarianHandNames[hand];
                }
            }
            catch
            {
                return "Not Found";
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
