using System;
using System.Linq;
using Ninject;
using SciaDesignFormsModel.Abstract;
using SciaDesignFormsModel.Concrete;

namespace SciaDesignFormsModel.Module
{
    static public class NinjectModule
    {
        static public void Bindings(IKernel ninjectKernel)
        {
            ninjectKernel.Bind<IDbFileRepository>().To<DbFileRepository>();
        }
    }
}
