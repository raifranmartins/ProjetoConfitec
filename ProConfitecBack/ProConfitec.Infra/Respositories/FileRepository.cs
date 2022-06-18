using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using MimeKit;
using ProConfitec.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Infra.Respositories
{
    public class FileRepository : IFileRepository
    {

        private IWebHostEnvironment _environment;

        public FileRepository(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public bool AddImage(string file, int id, string fileName, string fileType)
        {
            byte[] sPDFDecoded = Convert.FromBase64String(file);         

            var folderName = Path.Combine("Resources/Uploads/", id.ToString());
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            //    //Se o diretório não existir...

            if (!Directory.Exists(folderName))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folderName);

            }
            File.WriteAllBytes(folderName + "/" + fileName, sPDFDecoded);

            return true;
        }


        public string GetFileDownloadAsync(string file, int id)
        {
            string path = Path.Combine(this._environment.ContentRootPath, "Resources/Uploads/"+ id.ToString()); //+ file;
            var filePath = Path.Combine(path, file);

            return filePath;
        }


    }
}
