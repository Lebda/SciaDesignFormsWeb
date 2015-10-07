using System;
using System.Linq;
using GenericRepository.Concrete;
using SciaDesignFormsModel.Abstract;
using SciaDesignFormsModel.DataContexts.Identity;
using SciaDesignFormsModel.Entities.Identity.DbEmdUserSelection;

namespace SciaDesignFormsModel.Concrete
{
    public class DbEmdSelectionRepository : GenericRepository<DbEmdSelection>, IDbEmdSelectionRepository
    {
        public DbEmdSelectionRepository(IdentityDb db)
            : base(db)
        {
        }
    }
}
