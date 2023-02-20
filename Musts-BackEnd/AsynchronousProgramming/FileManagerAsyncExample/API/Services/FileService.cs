using API.IServices;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Services
{
    public class FileService : IFileService
    {
        private readonly ServiceContext _serviceContext;
        public FileService(ServiceContext serviceContext) 
        {
            _serviceContext = serviceContext;
        }
        public async Task<int> InsertFileAsync(FileItem fileItem)
        {
            try
            {
                _serviceContext.Files.Add(fileItem);
                await _serviceContext.SaveChangesAsync();

                return fileItem.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FileItem> GetFileByIdAsync(int id)
        {
            var file = await _serviceContext.Set<FileItem>().Where(f => f.Id == id).FirstOrDefaultAsync();

            if(file != null)
            {
                return file;
            }
            else
            {
                throw new Exception("No se encontró el archivo.");
            }
        }

        public Task<List<FileIdentifierModel>> InsertFilesAsync(List<FileItem> fileItemList)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFileAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FileItem>> GetFilesByCriteriaAsync(FileSearchCriteria fileSearchCriteria)
        {
            throw new NotImplementedException();
        }
    }
}
