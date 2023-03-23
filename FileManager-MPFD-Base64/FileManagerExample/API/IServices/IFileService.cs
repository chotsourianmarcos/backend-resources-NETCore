using API.Models;

namespace API.IServices
{
    public interface IFileService
    {
        int InsertFile(FileItem fileItem);
        FileItem GetFileById(int id);
        List<FileItem> GetAllFiles();
    }
}
