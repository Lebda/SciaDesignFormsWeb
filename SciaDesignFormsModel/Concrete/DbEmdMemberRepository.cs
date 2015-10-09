using System;
using System.Linq;
using GenericRepository.Concrete;
using SciaDesignFormsModel.Abstract;
using SciaDesignFormsModel.DataContexts.Identity;
using SciaDesignFormsModel.Entities.Identity.EmdFileStructure;

namespace SciaDesignFormsModel.Concrete
{
    public class DbEmdMemberRepository : GenericRepository<DbEmdMember>, IDbEmdMemberRepository
    {
        public DbEmdMemberRepository(IdentityDb db)
            : base(db)
        {
        }
    }
}
