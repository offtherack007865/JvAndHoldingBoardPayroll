using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace JvAndHoldingBoardPayroll10.Data.Models;

public partial class CommitteePayrollContext : DbContext
{
    public CommitteePayrollContext(DbContextOptions<CommitteePayrollContext> options)
        : base(options)
    {
        string projectPath = AppDomain.CurrentDomain.BaseDirectory;
        IConfigurationRoot configuration =
            new ConfigurationBuilder()
                .SetBasePath(projectPath)
        .AddJsonFile(MyConstants.AppSettingsFile)
        .Build();
        Database.SetCommandTimeout(9000);
        MyConnectionString =
            configuration.GetConnectionString(MyConstants.ConnectionString);
    }

    public string MyConnectionString { get; set; }

    public virtual DbSet<BoardMemberAssignment> BoardMemberAssignments { get; set; }
    public virtual DbSet<qy_GetJvAndHoldingBoardPayrollConfigOutputColumns> qy_GetJvAndHoldingBoardPayrollConfigOutputColumnsList { get; set;  }
    public virtual DbSet<qy_GetBoardMembersForInputtedDateAndBoardTypeOutputColumns> qy_GetBoardMembersForInputtedDateAndBoardTypeOutputColumnsList { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<qy_GetBoardMembersForInputtedDateAndBoardTypeOutputColumns>(entity =>
        {
            entity.HasNoKey();

        });

        modelBuilder.Entity<qy_GetJvAndHoldingBoardPayrollConfigOutputColumns>(entity =>
        {
            entity.HasNoKey();

        });

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
