using System;
using System.Linq;
using GenericRepository.Concrete;
using SciaDesignFormsModel.Abstract;
using SciaDesignFormsModel.DataContexts.Identity;
using SciaDesignFormsModel.Entities.Identity.EmdFileStructure;

namespace SciaDesignFormsModel.Concrete
{
    public class DbEmdSectionRepository : GenericRepository<DbEmdSection>, IDbEmdSectionRepository
    {
        public DbEmdSectionRepository(IdentityDb db)
            : base(db)
        {
        }
    }
}
