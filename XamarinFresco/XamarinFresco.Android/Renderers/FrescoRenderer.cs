using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Net;
using Android.Views;
using Com.Facebook.Drawee.Backends.Pipeline;
using Com.Facebook.Drawee.Generic;
using Com.Facebook.Drawee.View;
using Com.Facebook.Imagepipeline.Core;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinFresco.Controls;
using XamarinFresco.Droid.Renderers;

[assembly: ExportRenderer(typeof(FrescoControls), typeof(FrescoRenderer))]

namespace XamarinFresco.Droid.Renderers
{
    public class FrescoRenderer : ViewRenderer<FrescoControls, SimpleDraweeView>
    {
        Context context;
        SimpleDraweeView draweeView;
        ImagePipelineConfig imagePipelineConfig;
        ViewGroup mainpage;
        public FrescoRenderer(Context context) : base(context)
        {
            this.context = context;
            Fresco.Initialize(context, imagePipelineConfig);
        }
        protected FrescoControls frescoControls => (FrescoControls)Element;

        protected override void OnElementChanged(ElementChangedEventArgs<FrescoControls> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                if (Control == null)
                {
                    draweeView = new SimpleDraweeView(context);
                    SetNativeControl(draweeView);
                    mainpage = ((ViewGroup)draweeView.Parent);

                }
                SetSource();
            }
        }
        private void SetSource()
        {

            if (frescoControls.Source != null)
                draweeView.SetImageURI(frescoControls.Source);
            if (frescoControls.PlaceHolder != null) { }
            draweeView.ScrollBarFadeDuration = 1000;
            //https://frescolib.org/docs/placeholder-failure-retry.html
            //do you can implemet
            //ImagePipeline imagePipeline;
            //https://frescolib.org/docs/caching.html
            //Android.Graphics.Drawables.Drawable drawable;
            //var resp = await GetImageBitmapFromUrlAsync(frescoControls.Source);
            //SetPlaceholderImage(resp);
        }

        private async Task<Bitmap> GetImageBitmapFromUrlAsync(string url)
        {
            Bitmap imageBitmap = null;

            using (var httpClient = new HttpClient())
            {
                var imageBytes = await httpClient.GetByteArrayAsync(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
    
}
