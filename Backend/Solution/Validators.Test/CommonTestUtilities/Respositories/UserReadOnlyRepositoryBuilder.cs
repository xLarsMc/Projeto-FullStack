using Moq;
using Solution.Domain.Repositories.User;

namespace CommonTestUtilities.Respositories
{
    //Quando o mock precisa retornar algo, ele devolve o valor padrão daquele tipo, ou seja, se for bool, devolve
    //false, se for int, devolve 0, e assim por diante. Se for uma entidade, devolve null. Nesse caso, ele irá
    //devolver false, uma vez que o método de readOnly devolve bool, e o padrão sem atribuir nada de bool é false.

    //Como precisamos personalizar um método de uma classe que está sendo mockada, precisamos dizer qual método
    //terá seu valor definido, como, com qual condição, e se for task é retorno assíncrono. Nesse caso, o método
    //ExistActiveUserWithEmail retorna true para esse método quando quisermos, e não false, como é default.
    public class UserReadOnlyRepositoryBuilder
    {
        private readonly Mock<IUserReadOnlyRepository> _repository;

        public UserReadOnlyRepositoryBuilder() => _repository = new Mock<IUserReadOnlyRepository>();

        public void ExistActiveUserWithEmail(string email)
        {
            _repository.Setup(respository => respository.UserExist(email)).ReturnsAsync(true);
        }
        public IUserReadOnlyRepository Build() => _repository.Object;
    }
}
