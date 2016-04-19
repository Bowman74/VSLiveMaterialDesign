using System.Collections.Generic;
using MaterialDesign.Models;

namespace MaterialDesign.Services
{
    public class PollService
    {
        public IList<PollItem> GetPolls()
        {
            var returnValue = new List<PollItem>();
            var pollItem = new PollItem
            {
                PollCount = 193,
                PollDescription = "Will Ben Affleck be a good Batman in the new Superman film?",
                PollImageAssett = Resource.Drawable.Ben_Affleck_Batman
            };
            returnValue.Add(pollItem);

            pollItem = new PollItem
            {
                PollCount = 9,
                PollDescription = "Do popstars make good creative directors for technology companies?",
                PollImageAssett = Resource.Drawable.will_i_am_Intel
            };
            returnValue.Add(pollItem);

            pollItem = new PollItem
            {
                PollCount = 27,
                PollDescription = "Should Microsoft produce a smartwatch to compete with the Apple Watch?",
                PollImageAssett = Resource.Drawable.Microsoft_Windows_Watch_concept
            };
            returnValue.Add(pollItem); return returnValue;
        } 
    }
}