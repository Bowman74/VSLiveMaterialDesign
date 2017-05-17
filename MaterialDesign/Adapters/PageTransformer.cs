using System;
using Android.Support.V4.View;
using Android.Views;

namespace MaterialDesign.Adapters
{
    public class FadePageTransformer: Java.Lang.Object, ViewPager.IPageTransformer
    {
        public void TransformPage(View page, float position)
        {
            if (position <= -1.0F || position >= 1.0F)
            {        // [-Infinity,-1) OR (1,+Infinity]
                page.Alpha = (0.0F);
                page.Visibility = ViewStates.Gone;
            }
            else if (position == 0.0F)
            {     // [0]
                page.Alpha = (1.0F);
                page.Visibility = ViewStates.Visible;
            }
            else
            {

                // Position is between [-1,1]
                page.Alpha = (1.0F - Math.Abs(position));
                page.TranslationX = (-position * (page.Width / 2));
                page.Visibility = ViewStates.Visible;
            }
        }
    }
}