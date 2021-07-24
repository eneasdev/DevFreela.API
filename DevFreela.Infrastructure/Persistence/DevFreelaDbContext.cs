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
                new Project("Meu projeto ASPNET Core 1", "Minha descrição de projeto 1", 1, 1, 1000),
                new Project("Meu projeto ASPNET Core 1", "Minha descrição de projeto 1", 1, 1, 1000),
                new Project("Meu projeto ASPNET Core 1", "Minha descrição de projeto 1", 1, 1, 1000)
            };

            Users = new List<User>
            {
                new User("Eneas Martins", "eneasdev@gmail.com", new DateTime(1994, 1, 1)),
                new User("Robson Junior", "rbdev@gmail.com", new DateTime(1993, 1, 1)),
                new User("Lucas Nobre", "nobredev@gmail.com", new DateTime(1994, 1, 1))
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }



        public List<Project> Projects { get;  set; }
        public List<User> Users { get;  set; }
        public List<Skill> Skills { get;  set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}
