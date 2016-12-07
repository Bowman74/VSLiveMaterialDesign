using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
//using Com.Magenic.Sharedelementhotfix.Sharedelementhotfixandroidlib;
using MaterialDesign.Adapters;
using MaterialDesign.Services;


namespace MaterialDesign
{
    [Activity(Label = "MyVote Polls", 
        MainLauncher = true, 
        Theme = "@style/Theme.MyTheme", 
        Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        private static int NightMode = AppCompatDelegate.ModeNightNo;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var appBar = FindViewById<Toolbar>(Resource.Id.toolbar);
            appBar.InflateMenu(Resource.Menu.Main_Menu);
            SetSupportActionBar(appBar);


            // Get our button from the layout resource,
            // and attach an event to it
            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab_add);
            fab.Visibility = ViewStates.Invisible;
            fab.Click += fab_click;
            var recyclerView = FindViewById<RecyclerView>(Resource.Id.poll_list);

            var layoutManager = new LinearLayoutManager(this);
            layoutManager.Orientation = LinearLayoutManager.Vertical; 
            recyclerView.SetLayoutManager(layoutManager);

            var pollService = new PollService();
            var pollItems = pollService.GetPolls();

            var adapter = new PollAdapter(pollItems);
            recyclerView.SetAdapter(adapter);
        }

        protected override void OnResume()
        {
            base.OnResume();
            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab_add);
            if (fab.Visibility == ViewStates.Invisible)
            {
                AnimateShow(fab);
            }

        }

        private void fab_click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(NewPollActivity));
            var transitionName = GetString(Resource.String.Transition_Popup);
            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab_add);

            //var sharedElement = new SharedElementHotfix();
            //var bundle = sharedElement.SharedElementBundle(this, fab, transitionName);
            var options = ActivityOptionsCompat.MakeSceneTransitionAnimation(this, fab, transitionName);
            var bundle = options.ToBundle();
            ActivityCompat.StartActivity(this, intent, bundle);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.Main_Menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.action_settings)
            {
                if (NightMode == AppCompatDelegate.ModeNightNo)
                {
                    Delegate.SetLocalNightMode(AppCompatDelegate.ModeNightYes);
                    NightMode = AppCompatDelegate.ModeNightYes;
                }
                else
                {
                    Delegate.SetLocalNightMode(AppCompatDelegate.ModeNightNo);
                    NightMode = AppCompatDelegate.ModeNightNo;
                }
                this.Recreate();
            }
            return base.OnOptionsItemSelected(item);
        }

        private void AnimateShow(View view)
        {
            var anim = new ScaleAnimation(0, 1, 0, 1, .5f, .5f);
            anim.FillBefore = true;
            anim.FillAfter = true;
            anim.FillEnabled = true;
            anim.Duration = 300;
            anim.StartOffset = 500;

            anim.Interpolator = new OvershootInterpolator();
            view.StartAnimation(anim);
        }

        private float Hypotenuse(int x, int y)
        {
            return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }
}