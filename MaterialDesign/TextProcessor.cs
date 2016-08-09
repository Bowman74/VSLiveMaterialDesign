using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MaterialDesign
{
    [Activity(Label = "TextProcessor"), 
        IntentFilter(new[] { "android.intent.action.PROCESS_TEXT" }, 
        Categories = new[] {"android.intent.category.DEFAULT" }, 
        DataMimeTypes = new [] { "text/plain" }) ]
    public class TextProcessor : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            var sentText = Intent.GetCharSequenceExtra((Intent.ExtraProcessText));

            var returnValue = $"My cool text: {sentText}";
            var intent = new Intent();
            intent.PutExtra(Intent.ExtraProcessText, returnValue);
            SetResult(Result.Ok, intent);
            Finish();
        }
    }
}