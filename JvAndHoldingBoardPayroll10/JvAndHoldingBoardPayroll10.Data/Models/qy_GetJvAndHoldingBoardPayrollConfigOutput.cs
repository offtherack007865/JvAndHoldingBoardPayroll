using System;
using System.Collections.Generic;
using System.Text;

namespace JvAndHoldingBoardPayroll10.Data.Models
{
    public class qy_GetJvAndHoldingBoardPayrollConfigOutput
    {
        public qy_GetJvAndHoldingBoardPayrollConfigOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetJvAndHoldingBoardPayrollConfigOutputColumnsList =
                new List<qy_GetJvAndHoldingBoardPayrollConfigOutputColumns>();
        }
        public bool IsOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<qy_GetJvAndHoldingBoardPayrollConfigOutputColumns>
            qy_GetJvAndHoldingBoardPayrollConfigOutputColumnsList
            { get; set; }
    }
}
