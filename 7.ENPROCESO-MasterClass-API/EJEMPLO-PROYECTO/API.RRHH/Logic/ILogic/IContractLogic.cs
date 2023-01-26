using Entities.Entities;
using Resources.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IContractLogic
    {
        int InsertContract(ContractItem contractItem);
        void UpdateContract(ContractItem contractItem);
        void DeleteContract(int id);
        List<ContractItem> GetAllContracts();
        List<ContractItem> GetContractsByCriteria(ContractFilter contractFilter);
    }
}
