using System;
using System.Diagnostics;
using EducationPathways.Contracts;

namespace EducationPathways.Achievements.AchievementHandlers
{
    public class Thicko : BaseEventHandler
    {
        public override void Handle(Contracts.AssesmentCompleted @event)
        {
            if (@event.Score == 0)
            {
                Pubnub.publish<string>("Achievements", new Achievement
                {
                    DateEarnt = DateTime.Now,
                    Name = "Thicko",
                    Description = "Duhh!! You have earnt the Thicko achievement for getting no answers correct!"
                }, result => Trace.WriteLine(result));
            }
        }
    }
}
