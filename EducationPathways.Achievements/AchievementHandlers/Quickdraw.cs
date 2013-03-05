using EducationPathways.Contracts;
using System;
using System.Diagnostics;

namespace EducationPathways.Achievements.AchievementHandlers
{
    public class Quickdraw : BaseEventHandler
    {
        public override void Handle(AssesmentCompleted @event)
        {
            if (@event.CompletedDate.Subtract(@event.CompletedDate).TotalMilliseconds < 5000)
            {
                Pubnub.publish<string>("Achievements", new Achievement
                {
                    DateEarnt = DateTime.Now,
                    Name = "Quickdraw McGraw",
                    Description = "Well Done, you have erant the Quickdraw achievement by answering in under 5 seconds!!"
                }, result => Trace.WriteLine(result));
            }
        }
    }
}
