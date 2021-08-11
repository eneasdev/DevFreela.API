using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Descripction { get; set; }
        public int IdClient { get; set; }
        public int IdFreeLancer { get; set; }
        public decimal TotalCost { get; set; }
    }
}
