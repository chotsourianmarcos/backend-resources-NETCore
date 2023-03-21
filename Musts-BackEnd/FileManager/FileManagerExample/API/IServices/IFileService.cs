using API.Models;

namespace API.IServices
{
    public interface IFileService
    {
        int InsertFile(FileItem fileItem);
        List<FileIdentifierModel> InsertFiles(List<FileItem> fileItemList);
        void DeleteFile(int id);
        FileItem GetFileById(int id);
        List<FileItem> GetFilesByCriteria(FileSearchCriteria fileSearchCriteria);
        List<FileItem> GetAllFiles();
    }
}
