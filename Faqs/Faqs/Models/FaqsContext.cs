using System;
using Microsoft.EntityFrameworkCore;

namespace Faqs.Models
{
    public class FaqsContext : DbContext
    {
        public FaqsContext(DbContextOptions<FaqsContext> options)
            : base(options) { }
        public DbSet<Faq> FAQs { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = "cod", Name = "Call of Duty" },
                new Topic { TopicId = "fort", Name = "Fortnite" },
                new Topic { TopicId = "nba", Name = "NBA 2K22" }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "gen", Name = "General" },
                new Category { CategoryId = "hist", Name = "History" }
                );
            modelBuilder.Entity<Faq>().HasData(
                new Faq
                {
                    Id = 1,
                    Question = "What is Call of Duty?",
                    Answer = "Call of Duty is a first-person shooter video game franchise published by Activision.",
                    TopicId = "cod",
                    CategoryId = "gen"
                },
                new Faq
                {
                    Id = 2,
                    Question = "When was Call of Duty first released?",
                    Answer = "In 2003.",
                    TopicId = "cod",
                    CategoryId = "hist"
                },
                new Faq
                {
                    Id = 3,
                    Question = "What is Fortnite?",
                    Answer = "Fortnite is a battle royale video game developed by EpicGames and is free to play for all.",
                    TopicId = "fort",
                    CategoryId = "gen"
                },
                new Faq
                {
                    Id = 4,
                    Question = "When was Fortnite first released?",
                    Answer = "In 2017",
                    TopicId = "fort",
                    CategoryId = "hist"
                },
                new Faq
                {
                    Id = 5,
                    Question = "NBA 2K22",
                    Answer = "NBA 2K22 is a video game simulating professional basketball for anyone to play on PC or console devices.",
                    TopicId = "nba",
                    CategoryId = "gen"
                },
                new Faq
                {
                    Id = 6,
                    Question = "When was NBA 2K22 first released?",
                    Answer = "In 2021",
                    TopicId = "nba",
                    CategoryId = "hist"
                }
                );
        }

    }
}