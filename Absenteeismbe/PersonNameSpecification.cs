using System.Runtime.Serialization;
using Business;
using DataAccess.Specifications;

namespace Absenteeismbe
{
    [DataContract]
    public class PersonNameSpecification : CompositeSpecification
    {
        [DataMember]
        private readonly string _name;

        public PersonNameSpecification(string name)
        {
            _name = name;
        }

        public override bool IsSatisfiedBy<T>(T candidate)
        {
            var person = candidate as Person;
            return person.FirstName == _name;
        }
    }
}
