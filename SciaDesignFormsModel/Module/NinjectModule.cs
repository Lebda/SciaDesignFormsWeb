using System;
using System.Linq;
using Ninject;
using SciaDesignFormsModel.Abstract.EmdFile;
using SciaDesignFormsModel.Abstract.Repositories;
using SciaDesignFormsModel.Concrete.EmdFile;
using SciaDesignFormsModel.Concrete.Repositories;

namespace SciaDesignFormsModel.Module
{
    static public class NinjectModule
    {
        static public void Bindings(IKernel ninjectKernel)
        {
            ninjectKernel.Bind<IEmdFileSection>().To<EmdFileSection>();
            ninjectKernel.Bind<IEmdFileMember>().To<EmdFileMember>();
            ninjectKernel.Bind<IEmdFileStructure>().To<EmdFileStructure>();
            ninjectKernel.Bind<IEmdFileContext>().To<EmdFileContext>();
            ninjectKernel.Bind<IEmdFileParser>().To<EmdFileParser>();
            // repository
            ninjectKernel.Bind<IDbEmdFileRepository>().To<DbEmdFileRepository>();
            ninjectKernel.Bind<IDbEmdSectionRepository>().To<DbEmdSectionRepository>();
            ninjectKernel.Bind<IDbEmdMemberRepository>().To<DbEmdMemberRepository>();
            ninjectKernel.Bind<IDbEmdStructureRepository>().To<DbEmdStructureRepository>();
            ninjectKernel.Bind<IDbEmdFileRangeRepository>().To<DbEmdFileRangeRepository>();
            ninjectKernel.Bind<IDbSdfChecksRepository>().To<DbSdfChecksRepository>();
            ninjectKernel.Bind<IDbSdfUserChecksRepository>().To<DbSdfUserChecksRepository>();
        }
    }
}
