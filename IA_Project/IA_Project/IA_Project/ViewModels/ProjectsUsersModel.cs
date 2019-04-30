using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IA_Project.ViewModels
{
    public class ProjectsUsersModel
    {
        public List<PROJECT> Projects { get; set; }
        public List<S_ACTORS> Users { get; set; }
        public PROJECT Project { get; set; }
        public S_ACTORS Actor { get; set; }
    }
}