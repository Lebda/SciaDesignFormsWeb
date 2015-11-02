using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using CommonLibrary.StreamHelp;
using Ioc_Help.Abstract;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using SciaDesignFormsModel.Abstract.EmdFile;
using SciaDesignFormsModel.Abstract.Repositories;
using SciaDesignFormsModel.Entities.Identity.DbFiles;

namespace SciaDesignFormsWeb.Areas.EmdDataManager.Controllers
{
    [Authorize]
    public class EmdFilesController : ApiController
    {
        public EmdFilesController(
            IDbEmdFileRepository repo,
            IDbEmdFileRangeRepository repoRanges,
            IResolver<IEmdFileContext> resEmdFileContext,
            IEmdFileParser emdFileParser)
        {
            m_repoFiles = repo;
            m_emdFileParser = emdFileParser;
            m_repoRanges = repoRanges;
            m_resEmdFileContext = resEmdFileContext;
        }
        
        #region MEMBERS
        readonly IDbEmdFileRepository m_repoFiles;
        readonly IDbEmdFileRangeRepository m_repoRanges;
        readonly IEmdFileParser m_emdFileParser;
        readonly IResolver<IEmdFileContext> m_resEmdFileContext;
        #endregion
        
        [HttpPost] // This is from System.Web.Http, and not from System.Web.Mvc
        public async Task<HttpResponseMessage> Upload()
        {
            try
            {
                MultipartMemoryStreamProvider provider = await Request.Content.ReadAsMultipartAsync();
                foreach (HttpContent ctnt in provider.Contents)
                {
                    if (ctnt == null || ctnt.Headers == null || ctnt.Headers.ContentType == null || ctnt.Headers.ContentType.MediaType != "application/x-zip-compressed")
                    {
                        continue;
                    }
                    string userID = User.Identity.GetUserId();
                    var userRange = m_repoRanges.SelectByID(userID);
                    long fileSize = (long)ctnt.Headers.ContentLength;
                    var queryFiles4User = m_repoFiles.DataQueryable().Where(item => item.ApplicationUserID == userID).ToList();
                    long filesSizes = queryFiles4User.Sum(item => item.FileSize);
                    if (userRange.EmdFilesLimit < filesSizes + fileSize)
                    {
                        return this.Request.CreateResponse(HttpStatusCode.MethodNotAllowed, "Not enough space in your data repository");
                    }
                    Stream stream = ctnt.ReadAsStreamAsync().Result;
                    DbEmdFile dbFile = CreateDbFile(ctnt, stream);
                    dbFile.Structure = m_emdFileParser.Parse(CreateEmdFileContext(ctnt, stream)).CreateDb();
                    if (queryFiles4User.Count == 0)
                    {
                        dbFile.Structure.IsSelected = true;
                        if (dbFile.Structure.EmdMembers.Count > 0)
                        {
                            dbFile.Structure.EmdMembers.First().IsSelected = true;
                            if (dbFile.Structure.EmdMembers.First().EmdSections.Count > 0)
                            {
                                dbFile.Structure.EmdMembers.First().EmdSections.First().IsSelected = true;
                            }
                        }
                    }
                    m_repoFiles.Insert(dbFile);
                }
                m_repoFiles.SaveChanges();
                var returnData = "Esa model daa file is saved in database.";
                return this.Request.CreateResponse(HttpStatusCode.OK, new { returnData });
            }
            catch (DataException)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                var returnData = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, new { returnData });
            }
        }
        
        #region METHODS
        protected override void Dispose(bool disposing)
        {
            m_repoFiles.Dispose();
            m_repoRanges.Dispose();
            base.Dispose(disposing);
        }
        DbEmdFile CreateDbFile(HttpContent ctnt, Stream stream)
        {
            DbEmdFile dbFile = new DbEmdFile();
            dbFile.ApplicationUserID = User.Identity.GetUserId();
            // You would get hold of the inner memory stream here
            stream = ctnt.ReadAsStreamAsync().Result;
            dbFile.Content = stream.StreamToByteArray();
            dbFile.ContentType = ctnt.Headers.ContentType.MediaType;
            dbFile.FileName = ctnt.Headers.ContentDisposition.FileName;
            dbFile.FileSize = (long)ctnt.Headers.ContentLength;
            return dbFile;
        }
        IEmdFileContext CreateEmdFileContext(HttpContent ctnt, Stream stream)
        {
            IEmdFileContext context = m_resEmdFileContext.Resolve();
            context.EmdFileStream = stream;
            ContentDispositionHeaderValue disposition = ctnt.Headers.ContentDisposition;
            if (disposition != null)
            {
                context.ZipFileName = JsonConvert.DeserializeObject(disposition.FileName).ToString();
            }
            return context;
        }
        #endregion
        
        #region EXAMPLES
        // You could extract these two private methods to a separate utility class since
        // they do not really belong to a controller class but that is up to you
        //private MultipartMemoryStreamProvider GetMultipartProvider()
        //{
        //    // IMPORTANT: replace "(tilde)" with the real tilde character
        //    // (our editor doesn't allow it, so I just wrote "(tilde)" instead)
        //    var uploadFolder = "~/App_Data/Tmp/FileUploads"; // you could put this to web.config
        //    var root = HttpContext.Current.Server.MapPath(uploadFolder);
        //    Directory.CreateDirectory(root);
        //    return new MultipartMemoryStreamProvider();
        //}
        //private string GetDeserializedFileName(MultipartFileData fileData)
        //{
        //    var fileName = GetFileName(fileData);
        //    return JsonConvert.DeserializeObject(fileName).ToString();
        //}
        //private string GetFileName(MultipartFileData fileData)
        //{
        //    return fileData.Headers.ContentDisposition.FileName;
        //}
        #endregion      
    }
}