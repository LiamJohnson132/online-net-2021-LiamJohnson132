using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Interfaces
{
    public interface IUserRepository
    {
        List<InventoryReportModel> GetNewInventoryReports();
        List<InventoryReportModel> GetUsedInventoryReports();
        List<SalesReportModel> GetSalesReports(SalesReportParameters parameters);
        List<SalesReportModel> GetSalesReportsByUser(SalesReportParameters parameters);
        List<UserModel> GetUsers();
        List<RoleModel> GetRoles();
    }
}
