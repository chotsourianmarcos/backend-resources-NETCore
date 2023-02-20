using API.Models;

namespace API.IServices
{
    public interface IFileService
    {
        Task<int> InsertFileAsync(FileItem fileItem);
        Task<FileItem> GetFileByIdAsync(int id);
        Task<List<FileIdentifierModel>> InsertFilesAsync(List<FileItem> fileItemList);
        Task DeleteFileAsync(int id);
        Task<List<FileItem>> GetFilesByCriteriaAsync(FileSearchCriteria fileSearchCriteria);
    }
}
