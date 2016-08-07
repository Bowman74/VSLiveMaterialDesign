using System;
using Android.Animation;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace MaterialDesign
{
    [Activity(Label = "Add New Poll",
        Theme = "@style/Theme.MyTheme")]
    public class NewPollActivity : AppCompatActivity
    {
        Button ShowButton;
        Button HideButton;
        ImageView Image;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewPoll);

            var appBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(appBar);

            appBar.NavigationClick += Navigation_Click;

            ShowButton = FindViewById<Button>(Resource.Id.showImage);
            ShowButton.Click += ShowHideImage;

            HideButton = FindViewById<Button>(Resource.Id.hideImage);
            HideButton.Click += ShowHideImage;

            Image = FindViewById<ImageView>(Resource.Id.animatedImage);
        }

        private void Navigation_Click(object sender, Android.Support.V7.Widget.Toolbar.NavigationClickEventArgs e)
        {
            Finish();
        }

        private void ShowHideImage(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button.Id == Resource.Id.showImage)
            {
                AnimateShow(HideButton);
                AnimateShow(Image);
                AnimateHide(ShowButton);
            }
            else if (button.Id == Resource.Id.hideImage)
            {
                AnimateShow(ShowButton);
                AnimateHide(HideButton);
                AnimateHide(Image);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void AnimateShow(View view)
        {
            var centerX = view.Width / 2;
            var centerY = view.Height / 2;

            var radius = Hypotenuse(centerY, centerY);

            var animator = ViewAnimationUtils.CreateCircularReveal(view, centerX, centerY, 0, radius);

            view.Visibility = ViewStates.Visible;
            animator.Start();
        }

        private void AnimateHide(View view)
        {
            var centerX = view.Width / 2;
            var centerY = view.Height / 2;

            var radius = Hypotenuse(centerY, centerY);

            var animator = ViewAnimationUtils.CreateCircularReveal(view, centerX, centerY, radius, 0);
            animator.AddListener(new Adapter(view));

            view.Visibility = ViewStates.Visible;
            animator.Start();
        }

        private float Hypotenuse(int x, int y)
        {
            return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }

    public class Adapter : AnimatorListenerAdapter
    {
        private View TargetView;

        public Adapter(View targetView)
        {
            TargetView = targetView;
        }

        public override void OnAnimationEnd(Animator animation)
        {
            base.OnAnimationEnd(animation);
            TargetView.Visibility = ViewStates.Invisible;
        }
    }
}