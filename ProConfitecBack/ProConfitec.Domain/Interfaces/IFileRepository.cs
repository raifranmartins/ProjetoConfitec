using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Domain.Interfaces
{
    public interface IFileRepository
    {
        bool AddImage(string file, int id, string fileName, string fileType);
        string GetFileDownloadAsync(string name, int id);
        
    }
}
