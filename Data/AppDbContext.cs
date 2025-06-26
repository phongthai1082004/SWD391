using Assignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.RoleID)
                .IsRequired() // BẮT BUỘC phải có Role
                .OnDelete(DeleteBehavior.Restrict); // Không xóa người dùng khi xóa vai trò để tránh mất dữ liệu người dùng
            modelBuilder.Entity<User>()
                .HasOne(u => u.EmployeeProfile)
                .WithOne(ep => ep.User)
                .HasForeignKey<EmployeeProfile>(ep => ep.ProfileID)
                .OnDelete(DeleteBehavior.Cascade); // Xóa người dùng sẽ xóa cả hồ sơ nhân viên liên quan nếu cần thiết

            modelBuilder.Entity<Document>()
                .HasOne(d => d.User)
                .WithMany(u => u.Documents)
                .HasForeignKey(d => d.UserID)
                .IsRequired() // BẮT BUỘC phải có User
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FormTemplate>()
                .HasOne(ft => ft.User)
                .WithMany(u => u.FormTemplates)
                .HasForeignKey(ft => ft.UserID)
                .IsRequired() // BẮT BUỘC phải có User
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<LogEntry>()
                .HasOne(le => le.User)
                .WithMany(u => u.LogEntries)
                .HasForeignKey(le => le.UserID)
                .IsRequired() // BẮT BUỘC phải có User
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<WorkSchedule>()
                .HasOne(ws => ws.User)
                .WithMany(u => u.WorkSchedules)
                .HasForeignKey(ws => ws.UserID)
                .IsRequired() // BẮT BUỘC phải có User
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TestResult>()
                .HasOne(tr => tr.User)
                .WithMany(u => u.TestResults)
                .HasForeignKey(tr => tr.UserID)
                .IsRequired() // BẮT BUỘC phải có User
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TestResult>()
                .HasOne(tr => tr.Test)
                .WithMany(t => t.TestResults)
                .HasForeignKey(tr => tr.TestID)
                .IsRequired() // BẮT BUỘC phải có Test
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TestResult>()
                .HasOne(tr => tr.User)
                .WithMany(tt => tt.TestResults)
                .HasForeignKey(tr => tr.UserID)
                .IsRequired() // BẮT BUỘC phải có User
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FormInstance>()
                .HasOne(fi => fi.FormTemplate)
                .WithMany(ft => ft.FormInstances)
                .HasForeignKey(fi => fi.FormTemplateID)
                .IsRequired() // BẮT BUỘC phải có FormTemplate
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FormInstance>()
                .HasOne(fi => fi.EmployeeProfile)
                .WithMany(ep => ep.FormInstances)
                .HasForeignKey(fi => fi.ProfileID)
                .IsRequired() // BẮT BUỘC phải có EmployeeProfile
                .OnDelete(DeleteBehavior.Restrict);
            // Người gửi yêu cầu nghỉ phép
            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.User)
                .WithMany(u => u.LeaveRequests)
                .HasForeignKey(lr => lr.UserID)
                .OnDelete(DeleteBehavior.Restrict); // hoặc Cascade nếu phù hợp

            // Người phê duyệt yêu cầu nghỉ phép
            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.Approver)
                .WithMany(u => u.ApprovedRequests)
                .HasForeignKey(lr => lr.ApproverID)
                .OnDelete(DeleteBehavior.Restrict); // hoặc SetNull nếu không bắt buộc có người duyệt


            // Config Base Entity

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var builder = modelBuilder.Entity(entityType.ClrType);

                    // ID tự sinh Guid khi không truyền
                    builder.Property(nameof(BaseEntity.Id))
                           .HasDefaultValueSql("NEWID()");

                    // Name là nullable (có thể bỏ qua)
                    builder.Property(nameof(BaseEntity.Name))
                           .IsRequired(false);

                    // CreatedAt mặc định là thời gian hiện tại
                    builder.Property(nameof(BaseEntity.CreatedAt))
                           .HasDefaultValueSql("GETUTCDATE()");

                    // UpdatedAt mặc định là thời gian hiện tại
                    builder.Property(nameof(BaseEntity.UpdatedAt))
                           .HasDefaultValueSql("GETUTCDATE()");
                }
            }
        }
    }
}

