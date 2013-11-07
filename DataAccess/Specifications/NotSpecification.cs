namespace DataAccess.Specifications
{
    public class NotSpecification : CompositeSpecification
    {
        private readonly ISpecification _specification;

        public NotSpecification(ISpecification specification)
        {
            _specification = specification;
        }

        public override bool IsSatisfiedBy<T>(T candidate)
        {
            return !_specification.IsSatisfiedBy(candidate);
        }
    }
}