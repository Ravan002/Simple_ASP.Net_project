using Application.Storage.Azure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : IAzureStorage
    {
        public void Delete(string pathOrContainerName, string fileName)
        {
            throw new NotImplementedException();
        }


        public List<string> GetFiles(string containerName)
        {
            throw new NotImplementedException();
        }

        public bool HasFile(string containerName, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<List<(string fileName, string path)>> UploadAsync(string containerName, IFormFileCollection files)
        {
            throw new NotImplementedException();
        }
    }
}
