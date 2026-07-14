using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QueryData.Data.Configuration;
using QueryData.Entities;
using System.Reflection;


namespace QueryData.Data
{
    class AppDbContext : DbContext
    {

        public DbSet<Course> Courses { set; get; }
        public DbSet<Instructor> Instructors { set; get; }
        public DbSet<Office> Offices { set; get; }
        public DbSet<Section> Sections { set; get; }
        public DbSet<Schedule> Schedules { set; get; }
        public DbSet<SectionSchedule> SectionSchedules { set; get; }
        public DbSet<Participant> Participants { set; get; }
        public DbSet<Individual> Individuals { set; get; }
        public DbSet<Coporate> Coporates { set; get; }
        public DbSet<Enrollment> Enrollments { set; get; }
        public DbSet<Quiz> Quizzes { set; get; }
        public DbSet<MultipleChoiceQuiz> MultipleChoiceQuizzes { set; get; }
        public DbSet<TrueAndFalseQuiz> TrueAndFalseQuizzes { set; get; }
        public DbSet<Review> Reviews { set; get; }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
                );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("Data/appsettings.json", optional: true, reloadOnChange: true).Build();


            var connectionStr = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder
                //.UseLazyLoadingProxies()
                .UseSqlServer(connectionStr,sp=>sp.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }
    }
}
