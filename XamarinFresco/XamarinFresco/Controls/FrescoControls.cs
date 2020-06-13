using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinFresco.Controls
{
    public class FrescoControls:Image
    {
        public static readonly BindableProperty SourceProperty =
   BindableProperty.Create(nameof(Source), typeof(string), typeof(FrescoControls), null);

        public string Source {
            set { SetValue(SourceProperty, value); }
            get { return (string)GetValue(SourceProperty); }
        }
        public static readonly BindableProperty PlaceHolderProperty =
   BindableProperty.Create(nameof(PlaceHolder), typeof(string), typeof(FrescoControls), null);

        public string PlaceHolder {
            set { SetValue(PlaceHolderProperty, value); }
            get { return (string)GetValue(PlaceHolderProperty); }
        }     
    }
}
