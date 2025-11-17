using System;
using System.Collections.Generic;

namespace JvAndHoldingBoardPayroll10.Data.Models;

public partial class BoardMemberAssignment
{
    public int BoardMemberAssignmentId { get; set; }

    public int BoardMemberContactInfoId { get; set; }

    public int PayRateForBoardPositionId { get; set; }

    public DateTime TenureStartDate { get; set; }

    public DateTime? TenureEndDate { get; set; }
}
