using API.Models;

namespace API.IServices
{
    public interface IFileService
    {
        Task<int> InsertFile(FileItem fileItem);
        Task<List<FileIdentifierModel>> InsertFiles(List<FileItem> fileItemList);
        void DeleteFile(int id);
        Task<FileItem> GetFileById(int id);
        Task<List<FileItem>> GetFilesByCriteria(FileSearchCriteria fileSearchCriteria);
    }
}
