using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface ILaborLogic
    {
        int InsertJob(JobItem jobItem);
        void UpdateJob(JobItem jobItem);
        void DeleteJob(int id);
        List<JobItem> GetAllJobs();

        int InsertArea(AreaItem areaItem);
        void UpdateArea(AreaItem areaItem);
        void DeleteArea(int id);
        List<AreaItem> GetAllAreas();
    }
}
