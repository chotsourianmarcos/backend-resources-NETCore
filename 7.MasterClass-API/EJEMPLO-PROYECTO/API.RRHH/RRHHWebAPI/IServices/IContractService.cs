using Entities.Entities;
using Resources.FilterModels;
using Resources.RequestModels;

namespace RRHHWebAPI.IServices
{
    public interface IContractService
    {
        int InsertContract(NewContractRequest newProductRequest);
        void UpdateContract(ContractItem userItem);
        void DeleteContract(int id);
        List<ContractItem> GetAllContracts();
        List<ContractItem> GetContractsByCriteria(ContractFilter contractFilter);
    }
}
