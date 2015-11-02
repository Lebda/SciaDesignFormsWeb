using System;
using System.Data.Entity;
using System.Linq;
using SciaDesignFormsModel.DataContexts.SciaDesignForms;

namespace SciaDesignFormsModel.Intializers.SciaDesignForms
{
    public class SciaDesignFormsDbInitializer : DropCreateDatabaseIfModelChanges<SciaDesignFormsDb> //DropCreateDatabaseAlways DropCreateDatabaseIfModelChanges CreateDatabaseIfNotExists
    {
        //protected override void Seed(SciaDesignFormsDb context)
        //{
        //    base.Seed(context);
        //}
    }
}
