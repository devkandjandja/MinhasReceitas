using MinhasReceitas.Communication.Requests;
using MinhasReceitas.Communication.Responses;

namespace MinhasReceitas.Application.UserCases.User.Register
{
    public interface IRegisterUserUseCase
    {
        public Task<ResponsesRegisteredUserJson> Execute(RequestRegisterUserJson request);
    }
}
