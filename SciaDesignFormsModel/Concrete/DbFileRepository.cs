using System;
using System.Linq;
using GenericRepository.Concrete;
using SciaDesignFormsModel.Abstract;
using SciaDesignFormsModel.DataContexts.Identity;
using SciaDesignFormsModel.Entities.Identity;

namespace SciaDesignFormsModel.Concrete
{
    public class DbFileRepository : GenericRepository<DbFile>, IDbFileRepository
    {
        public DbFileRepository(IdentityDb db)
            : base(db)
        {
        }
    }
}
