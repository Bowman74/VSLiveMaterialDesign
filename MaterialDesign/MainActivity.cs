using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Com.Magenic.Sharedelementhotfix.Sharedelementhotfixandroidlib;
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

            var pollService = new PollService();
            var pollItems = pollService.GetPolls();

            var adapter = new PollAdapter(pollItems);
            recyclerView.SetAdapter(adapter);
        }

        private void fab_click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(NewPollActivity));
            var transitionName = GetString(Resource.String.Transition_Popup);
            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab_add);

            var sharedElement = new SharedElementHotfix();
            var bundle = sharedElement.SharedElementBundle(this, fab, transitionName);
            //var options = ActivityOptionsCompat.MakeSceneTransitionAnimation(this, fab, transitionName);
            //var bundle = options.ToBundle();
            ActivityCompat.StartActivity(this, intent, bundle);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.Main_Menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
    }
}