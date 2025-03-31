using Moq;
using Solution.Domain.Repositories;

namespace CommonTestUtilities.Respositories
{
    public class UnitOfWorkBuilder
    {
        public static IUnitOfWork Build()
        {
            var mock = new Mock<IUnitOfWork>();

            return mock.Object;
        }
    }
}
