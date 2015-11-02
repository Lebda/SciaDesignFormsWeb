using System;
using System.Linq;
using GenericRepository.Concrete;
using SciaDesignFormsModel.Abstract.Repositories;
using SciaDesignFormsModel.DataContexts.Identity;
using SciaDesignFormsModel.Entities.Identity.SdfCheck;

namespace SciaDesignFormsModel.Concrete.Repositories
{
    public class DbSdfChecksRepository : GenericRepository<DbSdfCheck>, IDbSdfChecksRepository
    {
        public DbSdfChecksRepository(IdentityDb db)
            : base(db)
        {
        }
    }
}
