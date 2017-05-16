using Android.Support.V4.App;

namespace MaterialDesign.Adapters
{
    public class BottomNavigationAdapter : FragmentPagerAdapter
    {
        Fragment[] fragments;

        public BottomNavigationAdapter(FragmentManager fm, Fragment[] fragments)
            : base(fm)
        {
            this.fragments = fragments;
        }

        public override int Count
        {
            get { return fragments.Length; }
        }

        public override Fragment GetItem(int position)
        {
            return fragments[position];
        }
    }
}
