using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using Com.Magenic.Sharedelementhotfix.Sharedelementhotfixandroidlib;
using MaterialDesign.Adapters;
using MaterialDesign.Services;


namespace MaterialDesign
{
    [Activity(Label = "MyVote Polls",
        MainLauncher = true,
        Theme = "@style/Theme.MyTheme",
        Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity, RecyclerView.IOnItemTouchListener, View.IOnClickListener
    {
        private static int NightMode = AppCompatDelegate.ModeNightNo;
        GestureDetector gestureDetector;

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
            fab.Click += fab_click;
            var recyclerView = FindViewById<RecyclerView>(Resource.Id.poll_list);

            var layoutManager = new LinearLayoutManager(this);
            layoutManager.Orientation = LinearLayoutManager.Vertical;
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.AddOnItemTouchListener(this);

            var pollService = new PollService();
            var pollItems = pollService.GetPolls();

            var adapter = new PollAdapter(pollItems);
            recyclerView.SetAdapter(adapter);

            var listener = new GestureListener();
            gestureDetector = new GestureDetector(this, listener);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                Window.SetStatusBarColor(new Android.Graphics.Color(ContextCompat.GetColor(Application, Resource.Color.custom_secondary)));
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab_add);
            AnimateShow(fab);
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
            Android.Support.V4.Content.ContextCompat.StartActivity(this, intent, bundle);
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
            if (item.ItemId == Resource.Id.bottom_navigation)
            {
                Android.Support.V4.Content.ContextCompat.StartActivity(this, new Intent(this, typeof(BottomNavigationActivity)), null);
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

        public bool OnInterceptTouchEvent(RecyclerView recyclerView, MotionEvent @event)
        {
            var child = recyclerView.FindChildViewUnder(@event.GetX(), @event.GetY());

            if (child != null && gestureDetector.OnTouchEvent(@event))
            {
                var fab = FindViewById<FloatingActionButton>(Resource.Id.fab_add);
                var snackbar = Snackbar.Make(fab, Resource.String.Item_Clicked, Snackbar.LengthLong);
                snackbar.SetAction("Do Something", this);
                snackbar.Show();

                return true;
            }
            return false;
        }

        public void OnRequestDisallowInterceptTouchEvent(bool disallow)
        {
        }

        public void OnTouchEvent(RecyclerView recyclerView, MotionEvent @event)
        {
        }

        public void OnClick(View v)
        {
        }
    }

    public class GestureListener : GestureDetector.SimpleOnGestureListener
    {
        public override bool OnSingleTapUp(MotionEvent e)
        {
            return true;
        }
    }
}