using System;
using System.Runtime.Serialization;

namespace Absenteeismbe.Model
{
    [DataContract]
    public class AddFoldRequest
    {
        [DataMember]
        public int PersonId { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime Start { get; set; }

        [DataMember]
        public DateTime End { get; set; }
    }
}