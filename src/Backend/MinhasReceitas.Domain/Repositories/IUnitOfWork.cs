﻿namespace MinhasReceitas.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}
