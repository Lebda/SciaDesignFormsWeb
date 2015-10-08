﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CommonLibrary.StreamHelp;
using Ioc_Help.Abstract;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using SciaDesignFormsModel.Abstract;
using SciaDesignFormsModel.Abstract.EmdFile;
using SciaDesignFormsModel.Entities.Identity.DbFiles;

namespace SciaDesignFormsWeb.Areas.EmdDataManager.Controllers
{
    public class EmdFilesController : ApiController
    {
        public EmdFilesController(
            IDbEmdFileRepository repo, 
            IResolver<IEmdFileContext> resEmdFileContext,
            IEmdFileParser emdFileParser)
        {
            m_repo = repo;
            m_emdFileParser = emdFileParser;
            m_resEmdFileContext = resEmdFileContext;
        }
        
        #region MEMBERS
        readonly IDbEmdFileRepository m_repo;
        readonly IEmdFileParser m_emdFileParser;
        readonly IResolver<IEmdFileContext> m_resEmdFileContext;
        #endregion

        #region PROPERTIES
        #endregion
      
        [HttpPost] // This is from System.Web.Http, and not from System.Web.Mvc
        public async Task<HttpResponseMessage> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
            
            MultipartMemoryStreamProvider provider = await Request.Content.ReadAsMultipartAsync();
            foreach (HttpContent ctnt in provider.Contents)
            {
                if (ctnt == null || ctnt.Headers == null || ctnt.Headers.ContentType == null || ctnt.Headers.ContentType.MediaType != "application/x-zip-compressed")
                {
                    continue;
                }
                DbEmdFile dbFile = new DbEmdFile();
                dbFile.ApplicationUserID = User.Identity.GetUserId();
                // You would get hold of the inner memory stream here
                Stream stream = ctnt.ReadAsStreamAsync().Result;
                dbFile.Content = stream.StreamToByteArray();
                dbFile.ContentType = ctnt.Headers.ContentType.MediaType;
                dbFile.FileName = ctnt.Headers.ContentDisposition.FileName;
                //dbFile.FileType = SciaDesignFormsModel.Shared.FileType.eEmdDataZip;

                IEmdFileContext context = m_resEmdFileContext.Resolve();
                context.EmdFileStream = stream;
                ContentDispositionHeaderValue disposition = ctnt.Headers.ContentDisposition;
                if (disposition != null)
                {
                    context.ZipFileName = JsonConvert.DeserializeObject(disposition.FileName).ToString();
                }
                dbFile.Structure = m_emdFileParser.Parse(context).CreateDb();
                m_repo.Insert(dbFile);
                m_repo.SaveChanges();

            }
            
            //var streamProvider = new MultipartMemoryStreamProvider();
            //Request.Content.ReadAsMultipartAsync<MultipartMemoryStreamProvider>(streamProvider).ContinueWith((tsk) =>
            //{
            //    foreach (HttpContent ctnt in streamProvider.Contents)
            //    {
            //        // You would get hold of the inner memory stream here
            //        Stream stream = ctnt.ReadAsStreamAsync().Result;
            //        // do something witht his stream now
            //    }
            //});
            
            //MultipartMemoryStreamProvider provider = await Request.Content.ReadAsMultipartAsync();
            //provider.GetStream
            //provider
            //.GetStream();
            
            // On upload, files are given a generic name like "BodyPart_26d6abe1-3ae1-416a-9429-b35f15e6e5d5"
            // so this is how you can get the original file name
            //var originalFileName = GetDeserializedFileName(result.FileData.First());
            
            // uploadedFileInfo object will give you some additional stuff like file length,
            // creation time, directory name, a few filesystem methods etc..
            //var uploadedFileInfo = new FileInfo(result.FileData.First().LocalFileName);
            
            // Remove this line as well as GetFormData method if you're not
            // sending any form data with your upload request
            //var fileUploadObj = GetFormData<UploadDataModel>(result);
            
            // Through the request response you can return an object to the Angular controller
            // You will be able to access this in the .success callback through its data attribute
            // If you want to send something to the .error callback, use the HttpStatusCode.BadRequest instead
            var returnData = "ReturnTest";
            return this.Request.CreateResponse(HttpStatusCode.OK, new { returnData });
        }
        // You could extract these two private methods to a separate utility class since
        // they do not really belong to a controller class but that is up to you
        private MultipartMemoryStreamProvider GetMultipartProvider()
        {
            // IMPORTANT: replace "(tilde)" with the real tilde character
            // (our editor doesn't allow it, so I just wrote "(tilde)" instead)
            var uploadFolder = "~/App_Data/Tmp/FileUploads"; // you could put this to web.config
            var root = HttpContext.Current.Server.MapPath(uploadFolder);
            Directory.CreateDirectory(root);
            return new MultipartMemoryStreamProvider();
        }
        // Extracts Request FormatData as a strongly typed model
        //private object GetFormData<T>(MultipartFormDataStreamProvider result)
        //{
        //    if (result.FormData.HasKeys())
        //    {
        //        var unescapedFormData = Uri.UnescapeDataString(result.FormData
        //                                                             .GetValues(0)
        //                                                             .FirstOrDefault() ?? String.Empty);
        //        if (!String.IsNullOrEmpty(unescapedFormData))
        //            return JsonConvert.DeserializeObject<T>(unescapedFormData);
        //    }
            
        //    return null;
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

        protected override void Dispose(bool disposing)
        {
            m_repo.Dispose();
            base.Dispose(disposing);
        }
    }
    public class UploadDataModel
    {
        public string testString1 { get; set; }
        public string testString2 { get; set; }
    }


}