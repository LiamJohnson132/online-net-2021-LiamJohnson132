using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.InMemoryIntegration
{
    public class ColorRepositoryQA : IColorRepository
    {
        private List<Color> _colors = new List<Color>()
        {
            new Color()
            {
                ColorId = 0,
                Name = "Silver"
            },
            new Color()
            {
                ColorId = 1,
                Name = "Gold"
            },
            new Color()
            {
                ColorId = 2,
                Name = "Black"
            },
            new Color()
            {
                ColorId = 3,
                Name = "Red"
            },
            new Color()
            {
                ColorId = 4,
                Name = "Orange"
            },
            new Color()
            {
                ColorId = 5,
                Name = "Yellow"
            },
            new Color()
            {
                ColorId = 6,
                Name = "Green"
            },
            new Color()
            {
                ColorId = 7,
                Name = "Blue"
            },
            new Color()
            {
                ColorId = 8,
                Name = "White"
            }
        };
        public List<Color> GetAll()
        {
            return _colors;
        }
    }
}
