using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cloud_Service_Core.Web.Models.FileViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using Microsoft.Rest;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Cms;

namespace Cloud_Service_Core.Web.Controllers
{
    public class FileController : Controller
    {
        #region Global vars

        private readonly ILogger _logger;
        private static MockFiles _files;
        
        #endregion

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
            _files = new MockFiles(_logger);
        }
        
        //  GET: File
        public ViewResult DisplayFiles(string folder = "0")
        {
            var isNumeric = int.TryParse(folder, out int id);
            if (!isNumeric)
            {
                id = 0; 
                _logger.LogError($"input isn't numeric - {folder}");
            }
            
            if (HttpContext.User.Identity.IsAuthenticated == false) { return View("~/Views/Account/Login_.cshtml"); }

            return View(_files.GetFiles(id));
        }
        
        //  GET: GetRandomFile
        public JsonResult GetFile() => Json(_files.GetRandomFile(), new JsonSerializerSettings());

        //  POST: Create file or folder
        public IActionResult Create(FileViewModel fileModel)
        {
            if (ModelState.IsValid) { return Ok(fileModel); }
            var errors = ModelState.Values.SelectMany(es => es.Errors).Select(e => e.ErrorMessage).ToArray();
            return BadRequest(errors);
        }
    }
    
    public class FileObjects
    {
        public IEnumerable<string[]> Directories { get; set; }
        public IEnumerable<Dictionary<string, string>> Files { get; set; }
    }

    public class MockFiles
    {
        private readonly List<FileObjects> _files = new List<FileObjects>();
        private readonly ILogger _logger;
        
        public MockFiles(ILogger logger)
        {
            _logger = logger;
            _files.Add(new FileObjects() {
                Files = new List<Dictionary<string, string>> { new Dictionary<string, string>
                {
                    ["file_1"] = "docx",
                    ["file_2"] = "docx",
                    ["file_3"] = "docx",
                    ["file_4"] = "xlsx",
                    ["file_5"] = "pptx",
                    ["file_6"] = "txt",
                    ["file_7"] = "unknown",
                
                    ["file_8"] = "docx",
                    ["file_9"] = "docx",
                    ["file_10"] = "docx",
                    ["file_11"] = "xlsx",
                    ["file_12"] = "pptx",
                    ["file_13"] = "txt",
                    ["file_14"] = "unknown"
                } },
                Directories = new List<string[]> {
                    new string[] { "#1_Folder_1", "#2_Folder_2", "#3_Folder_3", "#4_Folder_4", "#5_Folder_5" } }
            });
            
            _files.Add(new FileObjects() {
                Files = new List<Dictionary<string, string>> { new Dictionary<string, string>
                {
                    ["file_1"] = "docx",
                    ["file_2"] = "docx",
                    ["file_3"] = "docx",
                    ["file_4"] = "xlsx",
                    ["file_5"] = "pptx",
                    ["file_6"] = "txt",
                    ["file_7"] = "unknown",
                } },
                Directories = new List<string[]> {
                    new string[] { "#11_Folder_11", "#12_Folder_12", "#13_Folder_13" } }
            });
            
            _files.Add(new FileObjects() {
                Files = new List<Dictionary<string, string>> { new Dictionary<string, string>
                {
                    ["file_1"] = "docx",
                    ["file_2"] = "docx",
                    ["file_3"] = "docx",
                    ["file_4"] = "xlsx",
                    ["file_5"] = "pptx",
                    ["file_6"] = "txt",
                    ["file_7"] = "unknown",
                } },
                Directories = new List<string[]> {
                    new string[] { "#21_Folder_21", "#22_Folder_22", "#23_Folder_23" } }
            });
            
            _files.Add(new FileObjects() {
                Files = new List<Dictionary<string, string>> { new Dictionary<string, string>
                {
                    ["file_1"] = "docx",
                    ["file_2"] = "docx",
                    ["file_3"] = "docx",
                    ["file_4"] = "xlsx",
                    ["file_5"] = "pptx",
                    ["file_6"] = "txt",
                    ["file_7"] = "unknown",
                } },
                Directories = new List<string[]> {
                    new string[] { "#31_Folder_31", "#32_Folder_32", "#33_Folder_33" } }
            });
            
            _files.Add(new FileObjects() {
                Files = new List<Dictionary<string, string>> { new Dictionary<string, string>
                {
                    ["file_1"] = "docx",
                    ["file_2"] = "docx",
                    ["file_3"] = "docx",
                    ["file_4"] = "xlsx",
                    ["file_5"] = "pptx",
                    ["file_6"] = "txt",
                    ["file_7"] = "unknown",
                } },
                Directories = new List<string[]> {
                    new string[] { "#41_Folder_41", "#42_Folder_42", "#43_Folder_43" } }
            });
            
            _files.Add(new FileObjects() {
                Files = new List<Dictionary<string, string>> { new Dictionary<string, string>
                {
                    ["file_1"] = "docx",
                    ["file_2"] = "docx",
                    ["file_3"] = "docx",
                    ["file_4"] = "xlsx",
                    ["file_5"] = "pptx",
                    ["file_6"] = "txt",
                    ["file_7"] = "unknown",
                } },
                Directories = new List<string[]> {
                    new string[] { "#51_Folder_51", "#52_Folder_52", "#53_Folder_53" } }
            });
        }

        public FileObjects GetFiles(int id = 0)
        {
            try
            {
                return _files[id];
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return _files[0];
            }
        }

        public KeyValuePair<string, string> GetRandomFile() => new KeyValuePair<string, string>($"file_{new Random().Next(1000)}", ".docx");
    }
}