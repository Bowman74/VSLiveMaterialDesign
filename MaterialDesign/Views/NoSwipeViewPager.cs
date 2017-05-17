using System;
using Android.Content;
using Android.Support.V4.View;
using Android.Util;

namespace MaterialDesign.Views
{
    public class NoSwipeViewPager : ViewPager
    {
        public NoSwipeViewPager(Context context) : base(context)
        {
        }

        public NoSwipeViewPager(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public override bool OnTouchEvent(Android.Views.MotionEvent e)
        {
            return false;
        }

        public override bool OnInterceptTouchEvent(Android.Views.MotionEvent ev)
        {
            return false;
        }
    }
}