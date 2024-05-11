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
using NFCombat2.Models.Contracts;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.Services
{
    public class NameService : INameService, INotifyPropertyChanged
    {
        private readonly ISettingsService _settingsService;
        private Language _language;
        public Language Language { get { return _language; } set 
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
                return EnglishItems[type];
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
                return EnglishProgramNames[type];

            }
            catch
            {
                return "Not Found";
            }
        }

        public string ModeName(ItemMode mode)
        {
            return EnglishModes[mode];
        }

        public string FightResultMessage(Fight fight)
        {
            
            return EnglishFightResults[(fight.Type,fight.Result)];
            
        }

        public string Option(OptionType option, CheckType checkType = CheckType.None, int healthCost = 0)
        {
            string text = EnglishOptions[(option, checkType)];
            if(healthCost != 0)
            {
                return String.Format(text, healthCost);
            }
            return text;
        }

        public string InfoMessage(Fight fight)
        {
            if(fight is SkillCheckFight skillCheck)
            {
                if (skillCheck.CountWins)
                {
                    return $"You won {skillCheck.WonRounds} rounds.";
                }
            }
            return string.Empty;
        }

        public string EnemyName(EnemyType enemyType)
        {
            try
            {
                return EnglishEnemies[enemyType];

            }
            catch
            {
                return "Not Found";
            }
        }

        public void RetrieveFightNames(Fight fight)
        {
            if(fight is TentacleFight tentacleFight)
            {
                tentacleFight.TraumaTentacleName = EnglishEnemies[EnemyType.TraumaTentacle];
                tentacleFight.PathogensTentacleName = EnglishEnemies[EnemyType.PathogenTentacle];
                tentacleFight.IonizationTentacleName = EnglishEnemies[EnemyType.IonizationTentacle];
            }


            foreach(var enemy in fight.Enemies)
            {
                enemy.Name = EnglishEnemies[enemy.EnemyType];
                if(enemy.EnemyType == EnemyType.CommanderKabuto)
                {
                    enemy.Weapons[0].Name = EnglishItems[ItemType.KabutoMainHand];
                    enemy.Weapons[1].Name = EnglishItems[ItemType.KabutoOffHand];
                    
                }
            }
        }

        public string PartCategoryName(PartCategoryType category)
        {
            try
            {
                return EnglishPartCategories[category];

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
                return EnglishParts[partType];

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
                string format = EnglishCraftResults[result];
                if(item != null)
                {
                    string name = ItemName(item.ItemType);
                    return string.Format(format, name);
                }
                return EnglishCraftResults[result];

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
                return EnglishClassNames[className];
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
                return EnglishProgramComponentNames[type];
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
                return BulgarianProgramDescriptions[type];
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
                var format = EnglishDiceMessages[messageType];
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
                return BulgarianTechniqueNames[techniqueType];
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
                return BulgarianTechniqueDescriptions[techniqueType];
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
                return EnglishHandNames[hand];
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
