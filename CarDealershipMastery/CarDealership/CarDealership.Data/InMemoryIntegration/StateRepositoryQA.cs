using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.InMemoryIntegration
{
    public class StateRepositoryQA : IStateRepository
    {
        private List<State> _states = new List<State>()
        {
            new State()
            {
                StateId = "MN",
                Name = "Minnesota"
            },
            new State()
            {
                StateId = "WI",
                Name = "Wisconsin"
            },
            new State()
            {
                StateId = "IL",
                Name = "Illinois"
            },
            new State()
            {
                StateId = "IN",
                Name = "Indiana"
            },
            new State()
            {
                StateId = "OH",
                Name = "Ohio"
            },
            new State()
            {
                StateId = "KY",
                Name = "Kentucky"
            },
        };
        public List<State> GetAll()
        {
            return _states;
        }
    }
}
