using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title)
        {
            Id = id;
            Title = title;
            CreatedAt = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Title { get;  set; }
        public DateTime CreatedAt { get;  set; }
    }
}
