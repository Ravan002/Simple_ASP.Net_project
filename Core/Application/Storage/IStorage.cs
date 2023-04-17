using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Storage
{
    public interface IStorage
    {
        Task<List<(string fileName, string path)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);
        void Delete(string pathOrContainerName, string fileName);
        List<string> GetFiles(string pathOrContainerName);
        bool HasFile(string pathOrContainerName, string fileName);
    }
}
