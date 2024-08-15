using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.InsertUserSkills
{
    public class InsertUserSkillsCommand : IRequest<ResultViewModel>
    {
        public int[] SkillsId { get; set; }
        public int UserId { get; set; }
    }
}