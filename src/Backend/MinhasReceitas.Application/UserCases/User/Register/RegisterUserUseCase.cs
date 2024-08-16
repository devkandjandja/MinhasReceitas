using AutoMapper;
using MinhasReceitas.Application.Services.Cryptography;
using MinhasReceitas.Communication.Requests;
using MinhasReceitas.Communication.Responses;
using MinhasReceitas.Domain.Repositories;
using MinhasReceitas.Domain.Repositories.User;
using MinhasReceitas.Exceptions;

namespace MinhasReceitas.Application.UserCases.User.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PasswordEncripter _passwordEncripter;

        public RegisterUserUseCase(IUserWriteOnlyRepository userWriteOnlyRepository, IUserReadOnlyRepository userReadOnlyRepository, IMapper mapper, IUnitOfWork unitOfWork, PasswordEncripter passwordEncripter)
        {
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _userReadOnlyRepository = userReadOnlyRepository;          
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponsesRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {     

           await  Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = _passwordEncripter.Encrypt(request.Password);
            //salvar n o banco de dados

            await _userWriteOnlyRepository.Add(user);

            await _unitOfWork.Commit();

            return new ResponsesRegisteredUserJson
            {
                Nome = request.Nome,
            };
        }
        private async Task Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            var emailExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

            if (emailExist)
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessagesException.EMAIL_ALREADY_REGISTED));

            if(result.IsValid == false) 
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new Exception();
            }
        }
    }
}
