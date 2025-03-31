using Moq;
using Solution.Domain.Repositories.User;

namespace CommonTestUtilities.Respositories
{
    public class UserWriteOnlyRespoitoryBuilder
    {
        public static IUserWriteOnlyRepository Build()
        {
            var mock = new Mock<IUserWriteOnlyRepository>();

            return mock.Object;
        }
    }
}
