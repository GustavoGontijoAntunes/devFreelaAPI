using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.InsertUserSkills
{
    public class InsertUserSkillsHandler : IRequestHandler<InsertUserSkillsCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public InsertUserSkillsHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(InsertUserSkillsCommand request, CancellationToken cancellationToken)
        {
            var userSkills = request.SkillsId.Select(s => new UserSkill(request.UserId, s)).ToList();

            await _userRepository.AddUserSkills(userSkills);

            return ResultViewModel.Success();
        }
    }
}