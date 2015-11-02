using System;
using System.Linq;
using GenericRepository.Concrete;
using SciaDesignFormsModel.Abstract.Repositories;
using SciaDesignFormsModel.DataContexts.Identity;
using SciaDesignFormsModel.Entities.Identity.EmdFileStructure;

namespace SciaDesignFormsModel.Concrete.Repositories
{
    public class DbEmdStructureRepository : GenericRepository<DbEmdStructure>, IDbEmdStructureRepository
    {
        public DbEmdStructureRepository(IdentityDb db)
            : base(db)
        {
        }
    }
}
