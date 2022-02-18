using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.InMemoryIntegration
{
    public class TransmissionRepositoryQA : ITransmissionRepository
    {
        private List<Transmission> _transmissions = new List<Transmission>()
        {
            new Transmission()
            {
                TransmissionId = 0,
                Name = "Automatic"
            },
            new Transmission()
            {
                TransmissionId = 1,
                Name = "Manual"
            }
        };
        public List<Transmission> GetAll()
        {
            return _transmissions;
        }
    }
}
