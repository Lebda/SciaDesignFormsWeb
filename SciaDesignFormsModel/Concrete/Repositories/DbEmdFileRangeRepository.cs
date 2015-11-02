using System;
using System.Linq;
using GenericRepository.Concrete;
using SciaDesignFormsModel.Abstract.Repositories;
using SciaDesignFormsModel.DataContexts.Identity;
using SciaDesignFormsModel.Entities.Identity.EmdFileRanges;

namespace SciaDesignFormsModel.Concrete.Repositories
{
    public class DbEmdFileRangeRepository : GenericRepository<DbEmdFileRange>, IDbEmdFileRangeRepository
    {
        public DbEmdFileRangeRepository(IdentityDb db)
            : base(db)
        {
        }
    }
}
