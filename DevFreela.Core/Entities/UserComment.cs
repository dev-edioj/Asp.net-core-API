using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class UserComment : BaseEntity
    {
        public UserComment(string content, int idProject, int idUser)
        {
            Content = content;
            IdProject = idProject;
            IdUser = idUser;
            CreatedAt = DateTime.Now;
        }

        public string Content { get;  set; }
        public int IdProject { get;  set; }
        public int IdUser { get;  set; }
        public DateTime CreatedAt { get;  set; }
    }
}
