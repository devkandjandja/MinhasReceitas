using Microsoft.EntityFrameworkCore;
using MinhasReceitas.Domain.Entities;
using MinhasReceitas.Domain.Repositories.User;

namespace MinhasReceitas.Infra.DataAccess.Repositories
{
    public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
    {
        private readonly MinhasReceitasDbContext _dbContext;

        public UserRepository(MinhasReceitasDbContext dbContext) => _dbContext = dbContext;
        //Adicionando usuaurio
        public async Task Add(User user) => await _dbContext.AddAsync(user);
        //Verificar a existencia de email no banco de dados
        public async Task<bool> ExistActiveUserWithEmail(string email) => await _dbContext.Users.AnyAsync(user => user.Email.Equals(email) && user.Active);
     }
}
    