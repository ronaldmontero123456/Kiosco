using DPWCMSApp.Services;
using Kiosco.App.Data;
using Kiosco.App.Data.DTO;
using Kiosco.Services;

namespace Kiosco.App.Services
{
    public interface ITblResumenHorasService
    {
        Task<List<TblResumenHoras>> Get(PayrollSummary payrollSummary);
    }


    public class TblResumenHorasService : ITblResumenHorasService
    {
        private IHttpService _httpService;

        public TblResumenHorasService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<TblResumenHoras>> Get(PayrollSummary payrollSummary)
        {
            return await _httpService.SendPost<List<TblResumenHoras>>
                (@$"/POEMSHrmsIntegration/GetEmployeePayrollSummary?month={payrollSummary.Month}&year={payrollSummary.Year}&payperiod={payrollSummary.PayPeriod}&BUCode={payrollSummary.BUCode}&CostCenter={payrollSummary.CostCenter}", "");
        }
        public async Task<List<TblResumenHoras>> Post(GlobalSearchDTO globalSearchDTO)
        {
            return await _httpService.SendPost<List<TblResumenHoras>>("api/TblResumenHoras", globalSearchDTO);
        }
    }
}
