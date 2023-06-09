﻿using Application.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName => _storage.GetType().Name;

        public void Delete(string pathOrContainerName, string fileName)
        => _storage.Delete(pathOrContainerName,fileName);

        public List<string> GetFiles(string pathOrContainerName)
        => _storage.GetFiles(pathOrContainerName);

        public bool HasFile(string pathOrContainerName, string fileName)
        => _storage.HasFile(pathOrContainerName, fileName);

        public async Task<List<(string fileName, string path)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        => await _storage.UploadAsync(pathOrContainerName, files);
    }
}
