using System;
using System.Linq;
using GenericRepository.Concrete;
using SciaDesignFormsModel.Abstract.Repositories;
using SciaDesignFormsModel.DataContexts.Identity;
using SciaDesignFormsModel.Entities.Identity.SdfCheck;

namespace SciaDesignFormsModel.Concrete.Repositories
{
    public class DbSdfUserChecksRepository : GenericRepository<DbSdfUserCheck>, IDbSdfUserChecksRepository
    {
        public DbSdfUserChecksRepository(IdentityDb db)
            : base(db)
        {
        }
    }
}
