using System;
using System.Linq;
using System.Web.Http;
using SciaDesignFormsModel.Abstract.Repositories;

namespace SciaDesignFormsWeb.Areas.SectionCheck.Controllers
{
    [Authorize]
    public class SdfChecksController : SciaDesignFormsModel.Controllers.SdfChecksController
    {
        public SdfChecksController(IDbSdfUserChecksRepository repoSdfChecks)
            : base(repoSdfChecks)
        {

        }
    }
}
