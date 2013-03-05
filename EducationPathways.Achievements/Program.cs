using System;
using System.IO;
using System.Reflection;
using EducationPathways.Achievements.AchievementHandlers;
using EducationPathways.ServiceBus;
using EducationPathways.ServiceBus.Handling;
using EducationPathways.ServiceBus.Serialization;

namespace EducationPathways.Achievements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started up Achievment server");

            var settings = InfrastructureSettings.Read(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "Settings.xml"));
            var eventProcessor = new EventProcessor(new SubscriptionReceiver(settings.ServiceBus, "AssesmentTopic", "AssesmentSubscription", false), new JsonTextSerializer());

            eventProcessor.Register(new AssesmentCompletedHandler());
            eventProcessor.Start();

            Console.ReadLine();
        }
    }
}
