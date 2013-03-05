using EducationPathways.Contracts;
using EducationPathways.ServiceBus;
using EducationPathways.ServiceBus.Serialization;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting sending random AssesmentCompleted Events");

            var settings = InfrastructureSettings.Read(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "Settings.xml"));
            var serializer = new JsonTextSerializer();
            var metadata = new StandardMetadataProvider();
            var topicSender = new TopicSender(settings.ServiceBus, "AssesmentTopic");

            var eventBus = new EventBus(topicSender, metadata, serializer);

            for (int i = 0;; i++)
            {
                var assesmentCompleted = new AssesmentCompleted
                {
                    CompletedDate = DateTime.Now, 
                    PassThreshold = 80, 
                    Score = 70, 
                    StudentId = i, 
                    TopicName = "Topic " + i
                };  

                eventBus.Publish(assesmentCompleted);

                Console.WriteLine("Published :" + assesmentCompleted.TopicName);

                Thread.Sleep(10000);
            }
        }
    }
}
