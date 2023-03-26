using API.Models;

namespace API.IServices
{
    public interface IFileService
    {
        int InsertFile(FileItem fileItem);
        List<FileItem> GetAllFiles();
    }
}
