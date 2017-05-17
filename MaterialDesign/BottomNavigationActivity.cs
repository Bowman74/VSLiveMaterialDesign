
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using MaterialDesign.Adapters;
using MaterialDesign.Fragments;

namespace MaterialDesign
{
    [Activity(Label = "BottomNavigationActivity", Theme = "@style/Theme.MyTheme")]
    public class BottomNavigationActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        BottomNavigationView bottomNavigation;
        ViewPager viewPager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.bottom_navigation);

            var appBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(appBar);

            var fragments = new Android.Support.V4.App.Fragment[]
		    {
		        new AlarmFragment(), new SecurityFragment(), new MessageFragment()
		    };

            viewPager = FindViewById<ViewPager>(Resource.Id.pager);
            viewPager.Adapter = new BottomNavigationAdapter(base.SupportFragmentManager, fragments);
            viewPager.SetPageTransformer(false, new FadePageTransformer());

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            bottomNavigation.SetOnNavigationItemSelectedListener(this);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                Window.SetStatusBarColor(new Android.Graphics.Color(ContextCompat.GetColor(Application, Resource.Color.custom_secondary)));
            }
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case (Resource.Id.fragment_1):
                {
                    viewPager.SetCurrentItem(0, true);
                    break;
                }
                case (Resource.Id.fragment_2):
                {
                    viewPager.SetCurrentItem(1, true);
                    break;
                }
                case (Resource.Id.fragment_3):
                {
                    viewPager.SetCurrentItem(2, true);
                    break;
                }
            }
            return true;
        }
    }
}