using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace MaterialDesign
{
    [Activity(Label = "Add New Poll",
        Theme = "@style/Theme.MyTheme")]
    public class NewPollActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewPoll);

            var appBar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(appBar);

            appBar.NavigationClick += Navigation_Click;
        }

        private void Navigation_Click(object sender, Toolbar.NavigationClickEventArgs e)
        {
            Finish();
        }
    }
}