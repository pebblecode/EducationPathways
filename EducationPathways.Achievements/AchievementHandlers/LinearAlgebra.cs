using EducationPathways.Contracts;
using EducationPathways.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EducationPathways.Achievements.AchievementHandlers
{
    public class LinearAlgebra : BaseEventHandler
    {
        private readonly Hashtable previousAnsweredTopics = new Hashtable();

        public LinearAlgebra()
        {
            previousAnsweredTopics.Add(1002, null);
        }

        public override void Handle(AssesmentCompleted @event)
        {
            if (@event.SubjectId == 1002)
            {
                if (!previousAnsweredTopics.ContainsKey(@event.TopicId))
                {
                    previousAnsweredTopics.Add(@event.TopicId, @event);
                }

                INode syllabus = new SampleData.SampleDataGenerator().Generate();
                INode linearAlgebraSubject = FindSubject(syllabus);

                var enumerable = Traverse(linearAlgebraSubject, node => node.NextNodes).ToList();
                if (enumerable.Any(childTopics => !previousAnsweredTopics.ContainsKey(childTopics.Id)))
                {
                    return;
                }

                Pubnub.publish<string>("Achievements", new Achievement
                {
                    DateEarnt = DateTime.Now,
                    Name = "Algebra Nerd",
                    Description = "Well Done, you have mastered Algebra!"
                }, result => Trace.WriteLine(result));
            }
        }

        private static INode FindSubject(INode parentNode)
        {
            return parentNode.NextNodes.Select(node => node.Id == 1002 ? node : FindSubject(node))
                                       .FirstOrDefault();
        }

        private static IEnumerable<T> Traverse<T>(T root, Func<T, IEnumerable<T>> children)
        {
            var stack = new Stack<T>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                T item = stack.Pop();
                yield return item;
                foreach (var child in children(item))
                    if (!(child is Subject))
                        stack.Push(child);
            }
        }
    }
}
