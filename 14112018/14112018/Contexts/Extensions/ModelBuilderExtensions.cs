using _14112018.Domains;
using Microsoft.EntityFrameworkCore;

namespace _14112018.Contexts.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>().HasData(new Topic
            {
                Id=1,
                Title="Topic 1",
                Content="Content 1",
                IsPublished=true,

            },
            new Topic
            {
                Id=2,
                Title = "Topic 2",
                Content = "Content 2",
                IsPublished = true,

            },
            new Topic
            {
                Id=3,
                Title = "Topic 3",
                Content = "Content 3",
                IsPublished = false,

            });

        }
    }
}
