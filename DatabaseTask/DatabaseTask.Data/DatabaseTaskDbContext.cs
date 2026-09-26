using DatabaseTask.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTask.Data
{
    public class DatabaseTaskDbContext : DbContext
    {
        public DatabaseTaskDbContext(DbContextOptions<DatabaseTaskDbContext> options)
            : base(options) { }

        public DbSet<Company> Company { get; set; }
        public DbSet<VacationList> VacationList { get; set; }
        public DbSet<Intranet> Intranet { get; set; }
        public DbSet<Lending> Lending { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<HealthControlList> HealthControlList { get; set; }
        public DbSet<JobTypeList> JobTypeList { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<SickPapersList> SickPapersList { get; set; }
        public DbSet<Hint> Hint { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Anonymous> Anonymous { get; set; }
        public DbSet<Children> Children { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Permissions> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ============================================================
            // COMPANY
            // ============================================================

            // Office.CompanyId -> Company.CompanyId
            modelBuilder.Entity<Office>()
                .HasOne(e => e.Company)
                .WithMany(e => e.Offices)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Company.IntranetId -> Intranet.IntranetId
            modelBuilder.Entity<Company>()
                .HasOne(e => e.Intranet)
                .WithMany(e => e.Companies)
                .HasForeignKey(e => e.IntranetId)
                .OnDelete(DeleteBehavior.Restrict);

            // Company.Office is another navigation to Office, while
            // Office.CompanyId already represents the Company -> Office
            // relationship above.
            modelBuilder.Entity<Company>()
                .Ignore(e => e.Office);


            // ============================================================
            // OFFICE
            // ============================================================

            // Office.intranetId -> Intranet.IntranetId
            modelBuilder.Entity<Office>()
                .HasOne(e => e.intranet)
                .WithMany(e => e.Offices)
                .HasForeignKey(e => e.intranetId)
                .OnDelete(DeleteBehavior.Restrict);


            // ============================================================
            // EMPLOYEE -> OFFICE
            // ============================================================

            // Employee.OfficeId -> Office.OfficeId
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Office)
                .WithMany()
                .HasForeignKey(e => e.OfficeId)
                .OnDelete(DeleteBehavior.Restrict);


            // ============================================================
            // EMPLOYEE -> SICK PAPERS
            // ============================================================

            // SickPapersList.EmployeeId -> Employee.EmployeeId
            modelBuilder.Entity<SickPapersList>()
                .HasOne(e => e.Employee)
                .WithMany()
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee.SickPapersList is the duplicate/conflicting
            // navigation for the same pair of entities.
            modelBuilder.Entity<Employee>()
                .Ignore(e => e.SickPapersList);


            // ============================================================
            // EMPLOYEE -> JOB TYPE
            // ============================================================

            // JobTypeList.EmployeeId -> Employee.EmployeeId
            modelBuilder.Entity<JobTypeList>()
                .HasOne(e => e.Employee)
                .WithMany()
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .Ignore(e => e.JobTypeList);


            // ============================================================
            // EMPLOYEE -> VACATION
            // ============================================================

            // VacationList.EmployeeId -> Employee.EmployeeId
            modelBuilder.Entity<VacationList>()
                .HasOne(e => e.Employee)
                .WithMany()
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .Ignore(e => e.VacationList);


            // ============================================================
            // EMPLOYEE -> HEALTH CONTROL
            // ============================================================

            // HealthControlList.EmployeeId -> Employee.EmployeeId
            modelBuilder.Entity<HealthControlList>()
                .HasOne(e => e.Employee)
                .WithMany()
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .Ignore(e => e.HealthControlList);


            // ============================================================
            // EMPLOYEE -> PERMISSIONS
            // ============================================================

            // Permissions.EmployeeId -> Employee.EmployeeId
            modelBuilder.Entity<Permissions>()
                .HasOne(e => e.Employee)
                .WithMany()
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .Ignore(e => e.Permissions);


            // ============================================================
            // EMPLOYEE -> ANONYMOUS
            // ============================================================

            // Employee.AnonymousId -> Anonymous.AnonymousId
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Anonymous)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.AnonymousId)
                .OnDelete(DeleteBehavior.Restrict);


            // ============================================================
            // EMPLOYEE -> PARENT
            // ============================================================

            // Parent.EmployeeId -> Employee.EmployeeId
            modelBuilder.Entity<Parent>()
                .HasOne(e => e.Employee)
                .WithMany()
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .Ignore(e => e.Parent);


            // ============================================================
            // EMPLOYEE -> CHILDREN
            // ============================================================

            // Children.Employees collection -> Employee.ChildrenId
            // is not used as the principal-side navigation here.
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Children)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.ChildrenId)
                .OnDelete(DeleteBehavior.Restrict);


            // ============================================================
            // PARENT -> CHILDREN
            // ============================================================

            // Children.ParentId -> Parent.ParentId
            modelBuilder.Entity<Children>()
                .HasOne(e => e.Parent)
                .WithMany(e => e.ChildrenList)
                .HasForeignKey(e => e.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Parent.Children is the duplicate single navigation.
            modelBuilder.Entity<Parent>()
                .Ignore(e => e.Children);


            // ============================================================
            // CHILDREN -> VACATION
            // ============================================================

            // VacationList.ChildrenId -> Children.ChildrenId
            modelBuilder.Entity<VacationList>()
                .HasOne(e => e.Children)
                .WithMany(e => e.VacationLists)
                .HasForeignKey(e => e.ChildrenId)
                .OnDelete(DeleteBehavior.Restrict);


            // ============================================================
            // INTRANET -> ANONYMOUS
            // ============================================================

            // Anonymous.IntranetId -> Intranet.IntranetId
            modelBuilder.Entity<Anonymous>()
                .HasOne(e => e.Intranet)
                .WithMany(e => e.Anonymous)
                .HasForeignKey(e => e.IntranetId)
                .OnDelete(DeleteBehavior.Restrict);


            // ============================================================
            // ANONYMOUS -> HINT
            // ============================================================

            // Hint.AnonymousId -> Anonymous.AnonymousId
            modelBuilder.Entity<Hint>()
                .HasOne(e => e.Anonymous)
                .WithMany()
                .HasForeignKey(e => e.AnonymousId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Anonymous>()
                .Ignore(e => e.Hint);


            // ============================================================
            // HINT -> PERMISSIONS
            // ============================================================

            // Permissions.HintId -> Hint.HintId
            modelBuilder.Entity<Permissions>()
                .HasOne(e => e.Hint)
                .WithMany(e => e.Permissions)
                .HasForeignKey(e => e.HintId)
                .OnDelete(DeleteBehavior.Restrict);


            // ============================================================
            // LENDING -> EMPLOYEE
            // ============================================================

            // Lending.EmployeeId -> Employee.EmployeeId
            modelBuilder.Entity<Lending>()
                .HasOne(e => e.Employee)
                .WithMany()
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);


            // ============================================================
            // LENDING -> PERMISSIONS
            // ============================================================

            // Permissions.LendingId -> Lending.LendingId
            modelBuilder.Entity<Permissions>()
                .HasOne(e => e.Lending)
                .WithMany(e => e.Permissions)
                .HasForeignKey(e => e.LendingId)
                .OnDelete(DeleteBehavior.Restrict);


            // ============================================================
            // REQUEST -> EMPLOYEE
            // ============================================================

            // Request.EmployeeId -> Employee.EmployeeId
            modelBuilder.Entity<Request>()
                .HasOne(e => e.Employee)
                .WithMany()
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);


            // ============================================================
            // REQUEST -> PERMISSIONS
            // ============================================================

            // Permissions.RequestId -> Request.RequestId
            modelBuilder.Entity<Permissions>()
                .HasOne(e => e.Request)
                .WithMany(e => e.Permissions)
                .HasForeignKey(e => e.RequestId)
                .OnDelete(DeleteBehavior.Restrict);


            // ============================================================
            // ANONYMOUS -> PERMISSIONS
            // ============================================================

            // Permissions.AnonymousId -> Anonymous.AnonymousId
            modelBuilder.Entity<Permissions>()
                .HasOne(e => e.Anonymous)
                .WithMany(e => e.Permissions)
                .HasForeignKey(e => e.AnonymousId)
                .OnDelete(DeleteBehavior.Restrict);


            // ============================================================
            // DUPLICATE / NON-RELATION NAVIGATIONS
            // ============================================================

            // These properties exist in your C# classes and their names
            // are intentionally NOT changed. They are simply prevented
            // from being interpreted as additional relationships by EF.

            modelBuilder.Entity<Intranet>()
                .Ignore(e => e.company);

            modelBuilder.Entity<Intranet>()
                .Ignore(e => e.Employee);

            modelBuilder.Entity<Company>()
                .Ignore(e => e.Office);

            modelBuilder.Entity<Anonymous>()
                .Ignore(e => e.Hint);

            modelBuilder.Entity<Parent>()
                .Ignore(e => e.Children);
        }
    }
}
