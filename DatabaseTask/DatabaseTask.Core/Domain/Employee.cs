using System.ComponentModel.DataAnnotations;


namespace DatabaseTask.Core.Domain
{

    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public int SickPapersListId { get; set; }
        public SickPapersList SickPapersList { get; set; }

        public int JobTypeListId { get; set; }
        public JobTypeList JobTypeList { get; set; }

        public int VacationListId { get; set; }
        public VacationList VacationList { get; set; }

        public int HealthControlListId { get; set; }
        public HealthControlList HealthControlList { get; set; }

        public int PermissionsId { get; set; }
        public Permissions Permissions { get; set; }

        public int AnonymousId { get; set; }
        public Anonymous Anonymous { get; set; }

        public int OfficeId { get; set; }
        public Office Office { get; set; }

        public int ParentId { get; set; }
        public Parent Parent { get; set; }

        public int ChildrenId { get; set; }
        public Children Children { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        public int Age { get; set; }

    }

}

