using System;
using System.Collections.Generic;

namespace EducationPathways.Domain
{
    public class School
    {
        IEnumerable<FormGroup> FormGroups { get; set; }
    }

    public class FormGroup
    {
        IEnumerable<Student> Students { get; set; }
    }

    public class Student
    {
        IEnumerable<Syllabus> Syllabuses { get; set; }
    }

    public interface INode
    {
        string Name { get; }
        string Description { get; }
        IEnumerable<INode> NextNodes { get; }
    }

    public class Syllabus : INode
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<INode> NextNodes { get; set; }

        public Syllabus(string name)
        {
            Name = name;
        }
    }

    public class Subject : INode
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<INode> NextNodes { get; set; }

        public Subject(string name)
        {
            Name = name;
        }
    }

    public class Topic : INode, IScorable
    {
        public decimal PassThreshold { get; private set; }
        public decimal Score { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<INode> NextNodes { get; set; }

        public Topic(string name, string description = "")
        {
            Name = name;
            Description = description;
        }
    }

    public interface IScorable
    {
        decimal PassThreshold { get; }
        decimal Score { get; }
    }
}
