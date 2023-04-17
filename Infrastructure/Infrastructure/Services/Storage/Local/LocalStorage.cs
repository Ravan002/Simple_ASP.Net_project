using Application.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public void Delete(string path, string fileName)
        {
             File.Delete($"{path}\\{fileName}");
        }

        public List<string> GetFiles(string pathOrContainerName)
        {
            DirectoryInfo directoryInfo = new(pathOrContainerName);
            return directoryInfo.GetFiles().Select(e=>e.Name).ToList();
        }

        public bool HasFile(string path, string fileName)
        {
            return File.Exists($"{path}\\{fileName}");
        }

        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
             
            List<(string fileName, string path)> datas = new();
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            foreach (IFormFile file in files)
            {
                string fullPath = Path.Combine(uploadPath, $"{file.FileName}");

                await CopyToAsync(file, fullPath);

                datas.Add((file.FileName, $"{path}/{file.FileName}"));
            }
            return datas;
        }
        public async Task<bool> CopyToAsync(IFormFile file, string fullPath)
        {
            try
            {
                await using FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fs);
                await fs.FlushAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
