using MinhasReceitas.Domain.Repositories;

namespace MinhasReceitas.Infra.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MinhasReceitasDbContext _dbContext;
        public UnitOfWork(MinhasReceitasDbContext dbContext)
        {
            _dbContext = dbContext;
        }
         
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
      
    }
}
