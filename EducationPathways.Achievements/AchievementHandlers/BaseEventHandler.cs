using EducationPathways.Contracts;
using EducationPathways.ServiceBus;
using PubNub_Messaging;

namespace EducationPathways.Achievements.AchievementHandlers
{
    public abstract class BaseEventHandler : IEventHandler<AssesmentCompleted>
    {
        protected Pubnub Pubnub;

        protected BaseEventHandler()
        {
            Pubnub = new Pubnub("pub-c-ad0c7dac-d725-45f8-a2e0-089ea016a4b9", "sub-c-d1d9d648-858a-11e2-8a8f-12313f022c90", "sec-c-MDFmY2Q3OWUtOTJhMC00YmI0LWFiYzUtNWNlZDFlOWE4MDQ2");
        }

        public virtual void Handle(AssesmentCompleted @event)
        {
        }
    }
}
