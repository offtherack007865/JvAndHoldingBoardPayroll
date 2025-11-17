using System;
using System.Collections.Generic;
using System.Text;

namespace JvAndHoldingBoardPayroll10.Data.Models
{
    public class qy_GetBoardMembersForInputtedDateAndBoardTypeOutputColumns
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string BoardPosition { get; set; }
        public decimal PayRate { get; set; }
        public string BoardTypeName { get; set; }
    }
}
