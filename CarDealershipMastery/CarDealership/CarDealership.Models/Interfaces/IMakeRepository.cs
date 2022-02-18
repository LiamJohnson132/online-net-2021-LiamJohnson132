using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Interfaces
{
    public interface IMakeRepository
    {
        List<Make> GetAll();
        void Insert(Make make);
    }
}
