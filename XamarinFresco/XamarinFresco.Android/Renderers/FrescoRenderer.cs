using Android.Content;
using Android.Net;
using Android.Views;
using Android.Widget;
using Com.Facebook.Drawee.Backends.Pipeline;
using Com.Facebook.Drawee.View;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinFresco.Controls;
using XamarinFresco.Droid.Renderers;
using ARelativeLayout = Android.Widget.RelativeLayout;

[assembly: ExportRenderer(typeof(FrescoControls), typeof(FrescoRenderer))]

namespace XamarinFresco.Droid.Renderers
{
    public class FrescoRenderer : ViewRenderer<FrescoControls, SimpleDraweeView>
    {
        Context context;
        SimpleDraweeView draweeView;
        ARelativeLayout relativeLayout;
        ViewGroup mainpage;
        public FrescoRenderer(Context context) : base(context)
        {
            this.context = context;
            Fresco.Initialize(context);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<FrescoControls> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                if (Control == null)
                {

                    draweeView = new SimpleDraweeView(context);
                    ARelativeLayout.LayoutParams layoutParams =
                     new ARelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                    
                    layoutParams.AddRule(LayoutRules.CenterInParent);
                   // draweeView.LayoutParameters = layoutParams;
                    Uri uri = Uri.Parse("https://avatars1.githubusercontent.com/u/25535951");

                    draweeView.SetImageURI(uri);
                    //relativeLayout.AddView(draweeView);
                    SetNativeControl(draweeView);
                    mainpage = ((ViewGroup)draweeView.Parent);

                }
               // SetSource();
            }
        }

        private void SetSource()
        {
            Uri uri = Uri.Parse("https://avatars1.githubusercontent.com/u/25535951");

            draweeView.SetImageURI(uri);

        }

    }
}