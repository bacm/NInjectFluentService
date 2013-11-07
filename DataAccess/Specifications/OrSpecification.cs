namespace DataAccess.Specifications
{
    public class OrSpecification : CompositeSpecification
    {
        private readonly ISpecification _lhs;
        private readonly ISpecification _rhs;

        public OrSpecification(ISpecification lhs, ISpecification rhs)
        {
            _lhs = lhs;
            _rhs = rhs;
        }

        public override bool IsSatisfiedBy<T>(T candidate)
        {
            return _lhs.IsSatisfiedBy(candidate) | _rhs.IsSatisfiedBy(candidate);
        }
    }
}