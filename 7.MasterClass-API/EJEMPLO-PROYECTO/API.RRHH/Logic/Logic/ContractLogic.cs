using Entities.Entities;
using Logic.ILogic;
using Resources.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class ContractLogic : IContractLogic
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

        public int InsertContract(ContractItem contractItem)
        {
            throw new NotImplementedException();
        }

        public void UpdateContract(ContractItem contractItem)
        {
            throw new NotImplementedException();
        }
    }
}
