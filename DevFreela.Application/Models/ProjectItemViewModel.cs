using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class ProjectItemViewModel
    {
        public ProjectItemViewModel(int id, string title, string customerName, string freelancerName, decimal totalCost)
        {
            Id = id;
            Title = title;
            CustomerName = customerName;
            FreelancerName = freelancerName;
            TotalCost = totalCost;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string CustomerName { get; private set; }
        public string FreelancerName { get; private set; }
        public decimal TotalCost { get; private set; }

        public static ProjectItemViewModel FromEntity(Project project)
            => new(project.Id, project.Title, project.Customer.FullName, 
                   project.Freelancer.FullName, project.TotalCost);
    }
}