using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasData(
                new Question
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Title = "How would you rate McDonalds? (1-5)",
                    SurveyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Question
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    Title = "Out of these fast food, which have you visited the most?",
                    SurveyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")

                },
                new Question
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    Title = "How confident are you on binary trees?",
                    SurveyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                }
                );
        }
    }
}
