using CommunityToolkit.Maui.Alerts;
using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.ViewModels
{
    public class ContactPageViewModel : BaseViewModel
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        private string _before;
        public string Before
        {
            get { return _before; }
            set
            {
                if (_before != value)
                {
                    _before = value;
                    OnPropertyChanged(nameof(Before));
                }
            }
        }

        private string _after;
        public string After
        {
            get { return _after; }
            set
            {
                if (_after != value)
                {
                    _after = value;
                    OnPropertyChanged(nameof(After));
                }
            }
        }
        private IMyPopupService _popupService;
        public ContactPageViewModel(INameService nameService, ISettingsService settingsService, IMyPopupService popupService) : base(nameService, settingsService)
        {
            UpdateLanguageSpecificProperties();
            TapCommand = new Command<string>(async(email) => await OpenEmail(email));
            _popupService = popupService;
        }

        public Command TapCommand { get; set; }
        public async Task OpenEmail(string email)
        {
            await Clipboard.SetTextAsync(email);
            _popupService.ShowToast("Email copied to clipboard.");
            //try
            //{
            //    if (Email.Default.IsComposeSupported)
            //    {

            //        string subject = "";
            //        string body = "";
            //        string[] recipients = new[] { email };

            //        var message = new EmailMessage
            //        {
            //            Subject = subject,
            //            Body = body,
            //            BodyFormat = EmailBodyFormat.PlainText,
            //            To = new List<string>(recipients)
            //        };

            //        await Email.Default.ComposeAsync(message);
            //    }
            //}catch (Exception)
            //{
                
            //}
            
        }

        public override void UpdateLanguageSpecificProperties()
        {
            Before = _nameService.Label(LabelType.ContactBefore);
            After = _nameService.Label(LabelType.ContactAfter);
            Title = _nameService.Label(LabelType.ContactTitle);
        }
    }
}
