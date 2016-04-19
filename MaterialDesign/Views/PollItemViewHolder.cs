using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace MaterialDesign.Views
{
    public class PollItemViewHolder : RecyclerView.ViewHolder
    {
        public ImageView PollImage { get; private set; }
        public TextView PollDescription { get; private set; }
        public TextView PollVoteCount { get; private set; }

        public PollItemViewHolder(View itemView) : base(itemView)
        {
            // Locate and cache view references:
            PollImage = itemView.FindViewById<ImageView>(Resource.Id.poll_image);
            PollDescription = itemView.FindViewById<TextView>(Resource.Id.poll_description);
            PollVoteCount = itemView.FindViewById<TextView>(Resource.Id.poll_votes);
        }
    }
}