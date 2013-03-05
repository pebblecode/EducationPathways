using System;
using System.Collections.Generic;

namespace EducationPathways.Domain
{
    public class School
    {
        IEnumerable<FormGroup> FormGroups { get; }
    }

    public class FormGroup
    {
        IEnumerable<Student> Students { get; }
    }

    public class Student
    {
        IEnumerable<Syllabus> Syllabuses { get; }
    }

    public class Syllabus
    {
        IEnumerable<Subject> Subjects { get; }
    }

    public class Subject
    {
        IEnumerable<Topic> Topics { get; }
    }

    public class Topic
    {
        IEnumerable<IAssessment> Assessments { get; }
    }

    public interface IAssessment
    {
        decimal PassThreshold { get; }
        decimal Score { get; }
    }

    public class Examination : IAssessment {
        public decimal PassThreshold { get; private set; }
        public decimal Score { get; private set; }
    }

    public class CourseWork : IAssessment {
        public decimal PassThreshold { get; private set; }
        public decimal Score { get; private set; }
    }

    public class Practical : IAssessment {
        public decimal PassThreshold { get; private set; }
        public decimal Score { get; private set; }
    }
}
