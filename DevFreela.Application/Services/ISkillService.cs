using DevFreela.Application.Models;

namespace DevFreela.Application.Services
{
    public interface ISkillService
    {
        ResultViewModel<List<SkillViewModel>> GetAll();
        ResultViewModel<SkillViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateSkillInputModel model);
    }
}