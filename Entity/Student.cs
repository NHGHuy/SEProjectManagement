using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Student
    {
        public Student()
        {
            ProjectStudent1s = new HashSet<Project>();
            ProjectStudent2s = new HashSet<Project>();
            TopicRegisterStudent1s = new HashSet<TopicRegister>();
            TopicRegisterStudent2s = new HashSet<TopicRegister>();
        }

        public int StudentId { get; set; }
        public string? SName { get; set; }
        public string? Gender { get; set; }
        public DateTime? Birth { get; set; }
        public string? HomeTown { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public int? PhoneNumber { get; set; }
        public int? TermId { get; set; }
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Term? Term { get; set; }
        public virtual ICollection<Project> ProjectStudent1s { get; set; }
        public virtual ICollection<Project> ProjectStudent2s { get; set; }
        public virtual ICollection<TopicRegister> TopicRegisterStudent1s { get; set; }
        public virtual ICollection<TopicRegister> TopicRegisterStudent2s { get; set; }
    }
}
