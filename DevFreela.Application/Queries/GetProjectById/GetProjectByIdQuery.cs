using DevFreela.Application.ViewModels;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<Project>
    {
        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
