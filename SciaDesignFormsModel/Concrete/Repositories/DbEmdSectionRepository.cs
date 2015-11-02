using System;
using System.Linq;
using GenericRepository.Concrete;
using SciaDesignFormsModel.Abstract.Repositories;
using SciaDesignFormsModel.DataContexts.Identity;
using SciaDesignFormsModel.Entities.Identity.EmdFileStructure;

namespace SciaDesignFormsModel.Concrete.Repositories
{
    public class DbEmdSectionRepository : GenericRepository<DbEmdSection>, IDbEmdSectionRepository
    {
        public DbEmdSectionRepository(IdentityDb db)
            : base(db)
        {
        }
    }
}
