using JvAndHoldingBoardPayroll10.Data.Models;
using log4net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace JvAndHoldingBoardPayroll10.WebApiLand.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OpsController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(OpsController));

        public OpsController(CommitteePayrollContext inputCommitteePayrollContextContext)
        {
            MyContext = inputCommitteePayrollContextContext;

            log.Info($"Start of OpsController Connection String:  {MyContext.MyConnectionString}");

        }
        public CommitteePayrollContext MyContext { get; set; }


        // GET /api/Ops/qy_GetJvAndHoldingBoardPayrollConfig
        [HttpGet]
        public qy_GetJvAndHoldingBoardPayrollConfigOutput
                    qy_GetJvAndHoldingBoardPayrollConfig
                    (
                    )
        {
            qy_GetJvAndHoldingBoardPayrollConfigOutput returnOutput = new qy_GetJvAndHoldingBoardPayrollConfigOutput();
            string sql = $"payroll_jvhold.qy_GetJvAndHoldingBoardPayrollConfig";

            List<SqlParameter> parms = new List<SqlParameter>();

            try
            {
                returnOutput.qy_GetJvAndHoldingBoardPayrollConfigOutputColumnsList =
                    MyContext
                    .qy_GetJvAndHoldingBoardPayrollConfigOutputColumnsList
                    .FromSqlRaw<qy_GetJvAndHoldingBoardPayrollConfigOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }

        // GET /api/Ops/qy_GetBoardMembersForInputtedDateAndBoardType?inputDate=10/1/2025&inputBoardType=jv
        [HttpGet]
        public qy_GetBoardMembersForInputtedDateAndBoardTypeOutput
            qy_GetBoardMembersForInputtedDateAndBoardType
            (
                DateTime inputDate
                ,string inputBoardType
            )
        {
            qy_GetBoardMembersForInputtedDateAndBoardTypeOutput returnOutput = new qy_GetBoardMembersForInputtedDateAndBoardTypeOutput();
            string sql = $"payroll_jvhold.qy_GetBoardMembersForInputtedDateAndBoardType @inputDate, @inputBoardType";

            List<SqlParameter> parms = new List<SqlParameter>();

            // @inputDate
            SqlParameter parm =
                new SqlParameter
                {
                    ParameterName = "@inputDate",
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Value = inputDate
                };
            parms.Add(parm);

            // @inputBoardType
            parm =
                new SqlParameter
                {
                    ParameterName = "@inputBoardType",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 20,
                    Value = inputBoardType
                };
            parms.Add(parm);

            try
            {
                returnOutput.qy_GetBoardMembersForInputtedDateAndBoardTypeOutputColumnsList =
                    MyContext
                    .qy_GetBoardMembersForInputtedDateAndBoardTypeOutputColumnsList
                    .FromSqlRaw<qy_GetBoardMembersForInputtedDateAndBoardTypeOutputColumns>
                    (
                          sql
                        , parms.ToArray()
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                returnOutput.IsOk = false;

                string myErrorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    myErrorMessage = $"{myErrorMessage}.  InnerException:  {ex.InnerException.Message}";
                }
                returnOutput.ErrorMessage = myErrorMessage;
                return returnOutput;
            }
            return returnOutput;
        }
    }
}
