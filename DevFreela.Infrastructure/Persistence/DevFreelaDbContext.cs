using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Title 1","Description 1", 1 ,1 ,1000),
                new Project("Title 2","Description 2", 2 ,2 ,2000),
                new Project("Title 3","Description 3", 3 ,3 ,3000)

            };

            Users = new List<User>
            {
                new User("Usuario 1", "email.1@gmail.com", new DateTime(9999, 12, 18)),
                new User("Usuario 2", "email.2@gmail.com", new DateTime(9999, 12, 19)),
                new User("Usuario 3", "email.3@gmail.com", new DateTime(9999, 12, 20)),

            };

            Skills = new List<Skill>
            {
                new Skill("Skill1"),
                new Skill("Skill2"),
                new Skill("Skill3")
            };
        }
        public List<Project> Projects { get; set; }

        public List<User> Users { get; set; }

        public List<Skill> Skills { get; set; }

        public List<ProjectComment> ProjectComments { get; set; }

        public List<UserComment> UserComments { get; set; }

    }
}
