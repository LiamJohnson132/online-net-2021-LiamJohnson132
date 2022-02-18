using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Interfaces
{
    public interface IModelRepository
    {
        List<Model> GetAll();
        List<Model> GetByMake(int makeId);
        void Insert(Model model);
    }
}
