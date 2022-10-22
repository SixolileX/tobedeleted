namespace tobedeleted.Models
{
    public class HODactivityLog
    { public Grade Grade { get; set; }  
        public Subject Subject { get; set; }
        public Department Department { get; set; }
        public HODs HODs { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public UserActivity UserActivity { get; set; }
        public AssignSubjectGrade AssignSubjectGrade { get; set; }
    }
}
