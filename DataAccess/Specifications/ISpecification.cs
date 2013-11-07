namespace DataAccess.Specifications
{
    public interface ISpecification
    {
        bool IsSatisfiedBy<T>(T candidate) where T : class;

        ISpecification And(ISpecification other);
        ISpecification Or(ISpecification other);
        ISpecification Not();
    }

    public abstract class CompositeSpecification : ISpecification
    {
        public abstract bool IsSatisfiedBy<T>(T candidate) where T : class;

        public ISpecification And(ISpecification other)
        {
            return new AndSpecification(this, other);
        }

        public ISpecification Or(ISpecification other)
        {
            return new OrSpecification(this, other);
        }

        public ISpecification Not()
        {
            return new NotSpecification(this);
        }
    }
}