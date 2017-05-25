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
            {
                page.TranslationX = (page.Width * position);
                page.Alpha = (0.0F);
            }
            else if (position == 0.0F)
            {
                page.TranslationX = (page.Width * position);
                page.Alpha = (1.0F);
            }
            else
            {
                page.TranslationX = (page.Width * -position);
                page.Alpha = (1.0F - Math.Abs(position));
            }
        }
    }
}