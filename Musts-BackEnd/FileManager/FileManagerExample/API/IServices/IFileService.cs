using API.Models;

namespace API.IServices
{
    public interface IFileService
    {
        int InsertFile(FileUploadModel fileUploadModel);
        List<FileIdentifierModel> InsertFiles(List<FileUploadModel> filesUploadModel);
        void DeleteFile(int id);
        FileItem GetFileById(int id);
        List<FileItem> GetFilesByCriteria(FileSearchCriteria fileSearchCriteria);
    }
}
