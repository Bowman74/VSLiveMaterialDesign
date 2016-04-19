using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using MaterialDesign.Models;
using MaterialDesign.Views;

namespace MaterialDesign.Adapters
{
    public class PollAdapter : RecyclerView.Adapter
    {
        private IList<PollItem> pollItems;

        public PollAdapter(IList<PollItem> pollItems)
        {
            this.pollItems = pollItems;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = (PollItemViewHolder)holder;

            // Load the photo image resource from the photo album:
            vh.PollImage.SetImageResource(pollItems[position].PollImageAssett);

            // Load the photo caption from the photo album:
            vh.PollDescription.Text = pollItems[position].PollDescription;
            vh.PollVoteCount.Text = pollItems[position].PollCount.ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.MainRow, parent, false);

            // Create a ViewHolder to hold view references inside the CardView:
            var vh = new PollItemViewHolder(itemView);
            return vh;
        }

        public override int ItemCount
        {
            get { return pollItems.Count; }
        }
    }
}