using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullname, string email, DateTime birthDate)
        {
            FullName = fullname;
            Email = email;
            BirthDate = birthDate;
            createdAt = DateTime.Now;
            Active = true;
            
            Skills = new List<UserSkill>();
            OwnedProjects = new List<Project>();
            FreelanceProjects = new List<Project>();
        }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime createdAt { get; private set; }
        public bool Active {get; set;}
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }

        public void Update(string fullname, string email, DateTime birthDate)
        {
            FullName = fullname;
            Email = email;
            BirthDate = birthDate;
        }


    }

    
}
