using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JvAndHoldingBoardPayroll9.Data.Models;

public partial class CommitteePayrollContext : DbContext
{
    public CommitteePayrollContext(DbContextOptions<CommitteePayrollContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BoardMemberAssignment> BoardMemberAssignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BoardMemberAssignment>(entity =>
        {
            entity.HasKey(e => e.BoardMemberAssignmentId).HasName("pk_payroll_jvholdBoardMemberAssignment");

            entity.ToTable("BoardMemberAssignment", "payroll_jvhold");

            entity.Property(e => e.BoardMemberAssignmentId).HasColumnName("BoardMemberAssignmentID");
            entity.Property(e => e.BoardMemberContactInfoId).HasColumnName("BoardMemberContactInfoID");
            entity.Property(e => e.PayRateForBoardPositionId).HasColumnName("PayRateForBoardPositionID");
            entity.Property(e => e.TenureEndDate).HasColumnType("datetime");
            entity.Property(e => e.TenureStartDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
