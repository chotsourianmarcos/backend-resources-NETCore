using Entities.Entities;

namespace RRHHWebAPI.IServices
{
    public interface ILaborService
    {
        int InsertJob(JobItem jobItem);
        void UpdateJob(UserItem userItem);
        void DeleteJob(int id);
        List<JobItem> GetAllJobs();

        int InsertArea(AreaItem areaItem);
        void UpdateArea(AreaItem areaItem);
        void DeleteArea(int id);
        List<AreaItem> GetAllAreas();
    }
}
