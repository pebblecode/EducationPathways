using System;

namespace EducationPathways.Contracts
{
    public class AssesmentCompleted : IEvent
    {
        public Guid SourceId { get; private set; }

        public int SubjectId { get; set; }

        public int TopicId { get; set; }

        public string TopicName { get; set; }

        public int Score { get; set; }

        public int PassThreshold { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CompletedDate { get; set; }

        public int StudentId { get; set; }
    }
}
