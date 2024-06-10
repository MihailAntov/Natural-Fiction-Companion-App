using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Platforms.Android.Resources.handlers
{
    class ColoredPickerHandler : PickerHandler
    {
        protected override MauiPicker CreatePlatformView()
        {
            var spinner = base.CreatePlatformView();

            //spinner.SetBackgroundColor(); // Change to your desired color
            //todo : figure out the bg color
            return spinner;
        }
    }
}
