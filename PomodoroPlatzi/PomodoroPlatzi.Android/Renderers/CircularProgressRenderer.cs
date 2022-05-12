using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using com.refractored.monodroidtoolkit;
using PomodoroPlatzi.Controls;
using PomodoroPlatzi.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CircularProgress), typeof(CircularProgressRenderer))]
namespace PomodoroPlatzi.Droid.Renderers
{
    public class CircularProgressRenderer : ViewRenderer<CircularProgress, HoloCircularProgressBar>
    {
        public CircularProgressRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<CircularProgress> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
            {
                return;
            }

            var progress = new HoloCircularProgressBar(Context);

            progress.Max = Element.Max;
            progress.Progress = Element.Progress;
            progress.ProgressColor = Element.ProgressColor.ToAndroid();
            progress.ProgressBackgroundColor = Element.BackgroundColor.ToAndroid();
            progress.Indeterminate = Element.Indeterminate;
            progress.IndeterminateInterval = Element.IndeterminateSpeed;

            SetNativeControl(progress);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || Element == null) { return; }

            if (e.PropertyName == CircularProgress.MaxProperty.PropertyName)
            {
                Control.Max = Element.Max;
            }

            if (e.PropertyName == CircularProgress.ProgressProperty.PropertyName)
            {
                Control.Progress = Element.Progress;
            }

            if (e.PropertyName == CircularProgress.IndeterminateProperty.PropertyName)
            {
                Control.Indeterminate = Element.Indeterminate;
            }

            if (e.PropertyName == CircularProgress.IndeterminateSpeedProperty.PropertyName)
            {
                Control.IndeterminateInterval = Element.IndeterminateSpeed;
            }

            if (e.PropertyName == CircularProgress.ProgressColorProperty.PropertyName)
            {
                Control.ProgressColor = Element.ProgressColor.ToAndroid();
            }

            if (e.PropertyName == CircularProgress.BackgroundColorProperty.PropertyName)
            {
                Control.ProgressBackgroundColor = Element.ProgressBackgoundColor.ToAndroid();
            }
        }
    }
}