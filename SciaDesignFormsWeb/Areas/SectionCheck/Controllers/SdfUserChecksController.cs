using System;
using System.Linq;
using System.Web.Http;
using SciaDesignFormsModel.Abstract.Repositories;

namespace SciaDesignFormsWeb.Areas.SectionCheck.Controllers
{
    [Authorize]
    public class SdfUserChecksController : SciaDesignFormsModel.Controllers.SdfUserChecksController
    {
        public SdfUserChecksController(IDbSdfUserChecksRepository repoSdfChecks)
            : base(repoSdfChecks)
        {
        }
    }
}