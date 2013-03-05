using System.Diagnostics;
using EducationPathways.Contracts;
using System;
using PubNub_Messaging;

namespace EducationPathways.Achievements.AchievementHandlers
{
    class AssesmentCompletedHandler : BaseEventHandler
    {
        private readonly Pubnub _pubnub;

        public AssesmentCompletedHandler()
        {
            _pubnub = new Pubnub("pub-c-ad0c7dac-d725-45f8-a2e0-089ea016a4b9", "sub-c-d1d9d648-858a-11e2-8a8f-12313f022c90", "sec-c-MDFmY2Q3OWUtOTJhMC00YmI0LWFiYzUtNWNlZDFlOWE4MDQ2");
        }

        public override void Handle(AssesmentCompleted @event)
        {
            _pubnub.publish<string>("Achievements", new Achievement
                                {
                                    DateEarnt = DateTime.Now,
                                    Name = " 1 + 1",
                                    Description = "Well Done, you can Add 1 + 1!!!!"
                                }, result => Trace.WriteLine(result));
        }
    }
}
