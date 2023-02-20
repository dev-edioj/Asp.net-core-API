using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email, DateTime birthDate, DateTime createdAt, bool active)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            this.createdAt = createdAt;
            Active = active;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime createdAt { get; set; }
        public bool Active { get; set; }
    }
}
