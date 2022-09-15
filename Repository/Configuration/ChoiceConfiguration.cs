using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repository.Configuration
{
    public class ChoiceConfiguration : IEntityTypeConfiguration<Choice>
    {
        public void Configure(EntityTypeBuilder<Choice> builder)
        {
            builder.HasData(
                new Choice
                {
                    Id = 1,
                    Title = "0",
                    QuestionId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
                },
                new Choice
                {
                    Id = 2,
                    Title = "1",
                    QuestionId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
                },
                new Choice
                {
                    Id = 3,
                    Title = "2",
                    QuestionId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
                },
                new Choice
                {
                    Id = 4,

                    Title = "3",
                    QuestionId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
                },
                new Choice
                {
                    Id = 5,
                    Title = "4",
                    QuestionId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
                },
                new Choice
                {
                    Id = 6,
                    Title = "5",
                    QuestionId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
                },
                new Choice
                {
                    Id = 7,
                    Title = "Taco Bell",
                    QuestionId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a")

                },
                new Choice
                {
                    Id = 8,
                    Title = "McDonald's",
                    QuestionId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a")

                },
                new Choice
                {
                    Id = 9,
                    Title = "Burger King",
                    QuestionId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a")

                },
                new Choice
                {
                    Id = 10,
                    Title = "Sonic",
                    QuestionId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a")

                },
                new Choice
                {
                    Id = 11,
                    Title = "Not very confident",
                    QuestionId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811")
                },
                new Choice
                {
                    Id = 12,
                    Title = "Somewhat confident",
                    QuestionId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811")
                },
                new Choice
                {
                    Id = 13,
                    Title = "Very confident",
                    QuestionId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811")
                }
                );
        }
    }
}
