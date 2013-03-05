using System;
using System.IO;
using System.Reflection;
using System.Web.Mvc;
using EducationPathways.Contracts;
using EducationPathways.ServiceBus;
using EducationPathways.ServiceBus.Serialization;
using EducationPathways.Web.Models;

namespace EducationPathways.Web.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly EventBus _eventBus;

        public QuestionsController()
        {
            var settings = InfrastructureSettings.Read(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "Settings.xml"));
            var serializer = new JsonTextSerializer();
            var metadata = new StandardMetadataProvider();
            var topicSender = new TopicSender(settings.ServiceBus, "AssesmentTopic");

            _eventBus = new EventBus(topicSender, metadata, serializer);
        }

        [HttpGet]
        public ActionResult Matrices()
        {
            return View(new AnswerViewModel { StartDate = DateTime.Now });
        }

        [HttpPost]
        public void Matrices(AnswerViewModel answerViewModel)
        {
            var assesmentCompleted = new AssesmentCompleted
            {
                SubjectId = 1002,
                TopicId = 10022,
                StartDate = answerViewModel.StartDate,
                CompletedDate = DateTime.Now,
                PassThreshold = 100,
                Score = 100,
                StudentId = 1,
                TopicName = "Matrix Transformations"
            };

            assesmentCompleted.Score = answerViewModel.Answer == "2" ? 100 : 0;
            _eventBus.Publish(assesmentCompleted);
        }

        [HttpGet]
        public ActionResult Vectors()
        {
            return View(new AnswerViewModel { StartDate = DateTime.Now });
        }

        [HttpPost]
        public void Vectors(AnswerViewModel answerViewModel)
        {
            var assesmentCompleted = new AssesmentCompleted
            {
                SubjectId = 1002,
                TopicId = 10021,
                StartDate = answerViewModel.StartDate,
                CompletedDate = DateTime.Now,
                PassThreshold = 100,
                Score = 100,
                StudentId = 1,
                TopicName = "Vectors and spaces"
            };

            assesmentCompleted.Score = answerViewModel.Answer == "144" ? 100 : 0;
            _eventBus.Publish(assesmentCompleted);
        }


        [HttpGet]
        public ActionResult CoOrdinates()
        {
            return View(new AnswerViewModel { StartDate = DateTime.Now });
        }

        [HttpPost]
        public void CoOrdinates(AnswerViewModel answerViewModel)
        {
            var assesmentCompleted = new AssesmentCompleted
            {
                SubjectId = 1002,
                TopicId = 10023,
                StartDate = answerViewModel.StartDate,
                CompletedDate = DateTime.Now,
                PassThreshold = 100,
                Score = 100,
                StudentId = 1,
                TopicName = "Alternate coordinate systems (bases)"
            };

            assesmentCompleted.Score = answerViewModel.Answer == "3" ? 100 : 0;
            _eventBus.Publish(assesmentCompleted);
        }
    }
}
