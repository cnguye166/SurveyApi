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
    public class SurveyConfiguration : IEntityTypeConfiguration<SurveyModel>
    {
        public void Configure(EntityTypeBuilder<SurveyModel> builder)
        {
            builder.HasData(
                new SurveyModel
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Title = "Top Fast Food in the United States",
                    Topic = "Health Science"
                },
                new SurveyModel
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Title = "COSC 3212: Survey for Exam 1",
                    Topic = "Education"
                }
                );
        }
    }
}
