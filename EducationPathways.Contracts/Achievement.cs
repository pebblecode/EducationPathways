using System;
using System.Runtime.Serialization;

namespace EducationPathways.Contracts
{
    [DataContract]
    public class Achievement
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime DateEarnt { get; set; }
    }
}
