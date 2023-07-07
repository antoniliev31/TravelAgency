using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Data.Models;

namespace TravelAgency.Data.Configurations
{
    public class AgentEntityConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasData(this.GenerateAgentUser());
        }

        private Agent[] GenerateAgentUser()
        {
            ICollection<Agent> agents = new HashSet<Agent>();

            var agent = new Agent
            {
                Id = Guid.Parse("0174683e-a3fd-4f3c-a2b7-3c3792dad867"),
                PhoneNumber = "+359888888888",
                UserId = Guid.Parse("dea12856-c198-4129-b3f3-b893d8395082")
            };
            
            agents.Add(agent);

            return agents.ToArray();
        }
    }
}

