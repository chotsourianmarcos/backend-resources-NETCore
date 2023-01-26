using Entities.Entities;
using Resources.FilterModels;
using Resources.RequestModels;
using RRHHWebAPI.IServices;

namespace RRHHWebAPI.Services
{
    public class ContractService : IContractService
    {
        public void DeleteContract(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContractItem> GetAllContracts()
        {
            throw new NotImplementedException();
        }

        public List<ContractItem> GetContractsByCriteria(ContractFilter contractFilter)
        {
            throw new NotImplementedException();
        }

        public int InsertContract(NewContractRequest newProductRequest)
        {
            throw new NotImplementedException();
        }

        public void UpdateContract(ContractItem userItem)
        {
            throw new NotImplementedException();
        }
    }
}