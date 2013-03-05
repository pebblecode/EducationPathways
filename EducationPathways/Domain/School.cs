using System;
using System.Collections.Generic;
using System.Diagnostics;

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
        int Id { get; }
        string Name { get; }
        string Description { get; }
        IList<INode> NextNodes { get; set; }

        void SetId(int id);
    }

    [DebuggerDisplay("{Name}")]
    public class Syllabus : INode
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IList<INode> NextNodes { get; set; }

        public void SetId(int id)
        {
            Id = id;
        }

        public Syllabus(string name)
        {
            Name = name;
        }
    }

    [DebuggerDisplay("{Name}")]
    public class Subject : INode
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; private set; }
        public IList<INode> NextNodes { get; set; }

        public void SetId(int id)
        {
            Id = id;
        }

        public Subject(string name)
        {
            Name = name;
        }
    }

    [DebuggerDisplay("{Name}")]
    public class Topic : INode, IScorable
    {
        public int Id { get; private set; }
        public int PassThreshold { get; private set; }
        public int Score { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IList<INode> NextNodes { get; set; }

        public void SetId(int id)
        {
            Id = id;
        }

        public Topic(string name, string description = "")
        {
            Name = name;
            Description = description;
        }
    }

    public interface IScorable
    {
        int PassThreshold { get; }
        int Score { get; }
    }
}
