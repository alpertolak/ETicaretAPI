using ETicaretAPI.Application.Absractions.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.Storage.Local
{
    public class LoacalStorage : Stroage, ILocalStorage 
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LoacalStorage(
            IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task DeleteAsync(string path, string fileName)
            => File.Delete(Path.Combine(path,fileName));

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new(path);
            return directory.GetFiles().Select(f => f.Name).ToList(); 
        }    

        public bool HasFile(string path, string fileName)
            => File.Exists(Path.Combine(path,fileName));


        private async Task<bool> CopyfileAsync(string filePath, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                //todo log!
                throw ex;
            }
        }


        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            String uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            List<(string fileName, string path)> datas = new();

            foreach (IFormFile file in files)
            {
                string FileNewName = await FileRenameAsync(uploadPath, file.FileName, HasFile);

                await CopyfileAsync(Path.Combine(uploadPath, FileNewName), file);
                datas.Add((FileNewName, Path.Combine(path, FileNewName)));
            }

            return datas;
        }
    }
}
