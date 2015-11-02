using System;
using System.Linq;
using GenericRepository.Concrete;
using SciaDesignFormsModel.Abstract.Repositories;
using SciaDesignFormsModel.DataContexts.Identity;
using SciaDesignFormsModel.Entities.Identity.DbFiles;

namespace SciaDesignFormsModel.Concrete.Repositories
{
    public class DbEmdFileRepository : GenericRepository<DbEmdFile>, IDbEmdFileRepository
    {
        public DbEmdFileRepository(IdentityDb db)
            : base(db)
        {
        }
    }
}
