using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, string description, int customerId, int freelancerId, string customerName, string freelancerName, decimal totalCost, List<ProjectComment> comments)
        {
            Id = id;
            Title = title;
            Description = description;
            CustomerId = customerId;
            FreelancerId = freelancerId;
            CustomerName = customerName;
            FreelancerName = freelancerName;
            TotalCost = totalCost;
            Comments = comments.Select(x => x.Content).ToList();
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int CustomerId { get; private set; }
        public int FreelancerId { get; private set; }
        public string CustomerName { get; private set; }
        public string FreelancerName { get; private set; }
        public decimal TotalCost { get; private set; }
        public List<string> Comments { get; private set; }

        public static ProjectViewModel FromEntity(Project entity)
            => new ProjectViewModel(entity.Id, entity.Title, entity.Description,
                entity.CustomerId, entity.FreelancerId, entity.Customer.FullName,
                entity.Freelancer.FullName, entity.TotalCost, entity.Comments);
    }
}