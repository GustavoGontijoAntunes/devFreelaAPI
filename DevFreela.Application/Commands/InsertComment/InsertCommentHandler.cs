using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.InsertComment
{
    public class InsertCommentHandler : IRequestHandler<InsertCommentCommand, ResultViewModel>
    {
        private readonly IProjectRepository _projectRepository;

        public InsertCommentHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ResultViewModel> Handle(InsertCommentCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.Exists(request.ProjectId);

            if (!project)
            {
                return ResultViewModel<ProjectViewModel>.Error("Projeto não existe.");
            }

            var comment = new ProjectComment(request.Content, request.ProjectId, request.UserId);

            await _projectRepository.AddComment(comment);

            return ResultViewModel.Success();
        }
    }
}