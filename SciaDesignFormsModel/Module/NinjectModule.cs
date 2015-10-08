using System;
using System.Linq;
using Ninject;
using SciaDesignFormsModel.Abstract;
using SciaDesignFormsModel.Abstract.EmdFile;
using SciaDesignFormsModel.Concrete;
using SciaDesignFormsModel.Concrete.EmdFile;

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
            ninjectKernel.Bind<IDbEmdStructureRepository>().To<DbEmdStructureRepository>();
            ninjectKernel.Bind<IDbEmdFileRangeRepository>().To<DbEmdFileRangeRepository>();
        }
    }
}
