﻿using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Commands.InsertProject
{
    public class InsertProjectCommand : IRequest<ResultViewModel<int>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public int FreelancerId { get; set; }
        public decimal TotalCost { get; set; }

        public Project ToEntity()
            => new(Title, Description, CustomerId, FreelancerId, TotalCost);
    }
}