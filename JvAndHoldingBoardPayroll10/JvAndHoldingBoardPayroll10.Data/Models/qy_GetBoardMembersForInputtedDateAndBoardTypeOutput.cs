using System;
using System.Collections.Generic;
using System.Text;

namespace JvAndHoldingBoardPayroll10.Data.Models
{
    public class qy_GetBoardMembersForInputtedDateAndBoardTypeOutput
    {
        public qy_GetBoardMembersForInputtedDateAndBoardTypeOutput()
        {
            IsOk = true;
            ErrorMessage = string.Empty;
            qy_GetBoardMembersForInputtedDateAndBoardTypeOutputColumnsList =
                new List<qy_GetBoardMembersForInputtedDateAndBoardTypeOutputColumns>();
        }
        public bool IsOk {  get; set; }
        public string ErrorMessage { get; set; }
        public List<qy_GetBoardMembersForInputtedDateAndBoardTypeOutputColumns>
            qy_GetBoardMembersForInputtedDateAndBoardTypeOutputColumnsList
            { get; set; }
    }
}
