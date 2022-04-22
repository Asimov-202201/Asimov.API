using Asimov.API.Announcements.Domain.Models;
using Asimov.API.Competences.Domain.Models;
using Asimov.API.Courses.Domain.Models;
using Asimov.API.Directors.Domain.Models;
using Asimov.API.Items.Domain.Models;
using Asimov.API.Shared.Extensions;
using Asimov.API.Teachers.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Asimov.API.Shared.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Director> Directors { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<CourseCompetence> CourseCompetences { get; set; }
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Director>().ToTable("Directors");
            builder.Entity<Director>().HasKey(p => p.Id);
            builder.Entity<Director>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Director>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<Director>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<Director>().Property(p => p.Age).IsRequired();
            builder.Entity<Director>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<Director>().Property(p => p.Phone).IsRequired().HasMaxLength(30);

            builder.Entity<Director>()
                .HasMany(p => p.Announcements)
                .WithOne(p => p.Director)
                .HasForeignKey(p => p.DirectorId);
            
            builder.Entity<Director>()
                .HasMany(p => p.Teachers)
                .WithOne(p => p.Director)
                .HasForeignKey(p => p.DirectorId);

            builder.Entity<Director>().HasData(
                new Director {Id = 1, FirstName = "Julio", LastName = "Salazar", Age = 22, Email = "julio@gmail.com", PasswordHash = BCryptNet.HashPassword("yulius15"), Phone = "987654321"},
                new Director {Id = 2, FirstName = "Yordy", LastName = "Mochcco", Age = 20, Email = "yordy@gmail.com", PasswordHash = BCryptNet.HashPassword("yorjeje"), Phone = "987654322"},
                new Director {Id = 3, FirstName = "Pedro", LastName = "Suarez", Age = 35, Email = "pedrito@gmail.com", PasswordHash = BCryptNet.HashPassword("pedris54"), Phone = "958963854"},
                new Director {Id = 4, FirstName = "Juan", LastName = "Perez", Age = 26, Email = "jupe@gmail.com", PasswordHash = BCryptNet.HashPassword("jupec85"), Phone = "985126348"}
            );

            builder.Entity<Announcement>().ToTable("Announcements");
            builder.Entity<Announcement>().HasKey(p => p.Id);
            builder.Entity<Announcement>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Announcement>().Property(p => p.Title).IsRequired().HasMaxLength(30);
            builder.Entity<Announcement>().Property(p => p.Description).IsRequired().HasMaxLength(300);
            
            builder.Entity<Announcement>().HasData(
                new Announcement {Id = 1, Title = "First Example title", Description = "Example description 1", DirectorId = 1},
                new Announcement {Id = 2, Title = "Second Example title", Description = "Example description 2", DirectorId = 1},
                new Announcement {Id = 3, Title = "Third Example title", Description = "Example description 3", DirectorId = 1},
                new Announcement {Id = 4, Title = "Fourth Example title", Description = "Example description 4", DirectorId = 1},
                new Announcement {Id = 5, Title = "Fifth Example title", Description = "Example description 5", DirectorId = 1},
                new Announcement {Id = 6, Title = "Sixth Example title", Description = "Example description 6", DirectorId = 1},
                new Announcement {Id = 7, Title = "Seventh Example title", Description = "Example description 7", DirectorId = 1},
                new Announcement {Id = 8, Title = "Eighth Example title", Description = "Example description 8", DirectorId = 1},
                new Announcement {Id = 9, Title = "First Example title", Description = "Example description 1", DirectorId = 2},
                new Announcement {Id = 10, Title = "Second Example title", Description = "Example description 2", DirectorId = 2},
                new Announcement {Id = 11, Title = "Third Example title", Description = "Example description 3", DirectorId = 2},
                new Announcement {Id = 12, Title = "Fourth Example title", Description = "Example description 4", DirectorId = 2},
                new Announcement {Id = 13, Title = "Fifth Example title", Description = "Example description 5", DirectorId = 3},
                new Announcement {Id = 14, Title = "Sixth Example title", Description = "Example description 6", DirectorId = 3},
                new Announcement {Id = 15, Title = "Seventh Example title", Description = "Example description 7", DirectorId = 3},
                new Announcement {Id = 16, Title = "Eighth Example title", Description = "Example description 8", DirectorId = 3}
                
            );
            
            builder.Entity<Teacher>().ToTable("Teachers");
            builder.Entity<Teacher>().HasKey(p => p.Id);
            builder.Entity<Teacher>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Teacher>().Property(p => p.Point).IsRequired();
            builder.Entity<Teacher>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<Teacher>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<Teacher>().Property(p => p.Age).IsRequired();
            builder.Entity<Teacher>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<Teacher>().Property(p => p.Phone).IsRequired().HasMaxLength(30);

            builder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1, FirstName = "Omar", LastName = "Alvarado", Age = 22, Email = "omar@gmail.com", PasswordHash = BCryptNet.HashPassword("alves"), 
                    Phone = "987654321" , Point = 500 , DirectorId = 1
                },
                new Teacher
                {
                    Id = 2, FirstName = "Maria", LastName = "Vasquez", Age = 20, Email = "marifer@gmail.com", PasswordHash = BCryptNet.HashPassword("fermi52"), 
                    Phone = "987654322" , Point = 400 , DirectorId = 1
                },
                new Teacher
                {
                    Id = 3, FirstName = "Julio", LastName = "Salazar", Age = 22, Email = "jul@gmail.com", PasswordHash = BCryptNet.HashPassword("yuliusmh"), 
                    Phone = "987654321" , Point = 300 , DirectorId = 1
                },new Teacher
                {
                    Id = 4, FirstName = "Yordy", LastName = "Mochcco", Age = 22, Email = "yor@gmail.com", PasswordHash = BCryptNet.HashPassword("yor584"), 
                    Phone = "987654321" , Point = 420 , DirectorId = 1
                },new Teacher
                {
                    Id = 5, FirstName = "Rosa", LastName = "Gonzales", Age = 22, Email = "ros@gmail.com", PasswordHash = BCryptNet.HashPassword("rousli"), 
                    Phone = "987654321" , Point = 280 , DirectorId = 1
                },new Teacher
                {
                    Id = 6, FirstName = "Piero", LastName = "Perez", Age = 22, Email = "per@gmail.com", PasswordHash = BCryptNet.HashPassword("pero54"), 
                    Phone = "987654321" , Point = 340 , DirectorId = 1
                },new Teacher
                {
                    Id = 7, FirstName = "Juan", LastName = "Perez", Age = 22, Email = "jperz@gmail.com", PasswordHash = BCryptNet.HashPassword("juancito65"), 
                    Phone = "987654321" , Point = 400 , DirectorId = 1
                },new Teacher
                {
                    Id = 8, FirstName = "Rodrigo", LastName = "Sabino", Age = 22, Email = "rod@gmail.com", PasswordHash = BCryptNet.HashPassword("rodripa"), 
                    Phone = "987654321" , Point = 450 , DirectorId = 1
                },new Teacher
                {
                    Id = 9, FirstName = "Italo", LastName = "Canales", Age = 22, Email = "itsl@gmail.com", PasswordHash = BCryptNet.HashPassword("laitale"), 
                    Phone = "987654321" , Point = 520 , DirectorId = 1
                }
            );


            builder.Entity<Course>().ToTable("Courses");
            builder.Entity<Course>().HasKey(p => p.Id);
            builder.Entity<Course>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Course>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Course>().Property(p => p.Description).IsRequired().HasMaxLength(500);
            builder.Entity<Course>().Property(p => p.State).IsRequired();
            
            builder.Entity<Course>()
                .HasMany(p => p.Items)
                .WithOne(p => p.Course)
                .HasForeignKey(p => p.CourseId);

            builder.Entity<Course>().HasData(
                new Course {Id = 1, Name = "Algebra", Description = "is a branch of mathematics that uses not only numbers and symbols but also letters to solve operations", State = false}, 
                new Course {Id = 2, Name = "Trigonometry", Description = "is a branch of mathematics, whose etymological meaning is measurement of triangles.", State = false},
                new Course {Id = 3, Name = "Biology", Description = "is the science that studies living beings and their characteristics, including its origin, evolution and Page 2 its properties, nutrition, morphogenesis, reproduction", State = false},
                new Course {Id = 4, Name = "Arithmetic", Description = "is the branch of mathematics which studies are numbers and basic operations done with them: addition, subtraction, multiplication and division.", State = false},
                new Course {Id = 5, Name = "Geography", Description = "is the science that studies and describes the environment around us and gives us information that helps us to know and understand. It is based on the analysis of the physical, social and economic elements that coincide in a specific place and time.", State = false},
                new Course {Id = 6, Name = "Universal history", Description = "The term World History gathering facts and situations that have developed around the context of the human being, from the appearance of man until today. ... The writing was an event that accelerated the evolution of humanity.", State = false},
                new Course {Id = 7, Name = "Physical", Description = "is an exact science that studies how the universe taking into account four fundamental properties that are energy, matter, time and space, how they interact and affect each other works.", State = false},
                new Course {Id = 8, Name = "Anatomy", Description = " is a science that studies the structure of living beings, that is, the shape, topography, location, arrangement and relationship of the organs that compose them", State = false},
                new Course {Id = 9, Name = "chemistry", Description = "is the study of atoms and molecules and their interactions. The chemical studies reactions and physical changes that occur when creating or transformed compounds.", State = false}
            );
            
            
            builder.Entity<Item>().ToTable("Items");
            builder.Entity<Item>().HasKey(p => p.Id);
            builder.Entity<Item>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Item>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Item>().Property(p => p.Value).IsRequired();
            builder.Entity<Item>().Property(p => p.State).IsRequired();
            
            builder.Entity<Item>().HasData(
                new Item {Id = 1, Name = "Video", Value = "https://www.youtube.com/embed/LwCRRUa8yTU", State = false, CourseId = 1},
                new Item {Id = 2, Name = "Documentation", Value = "Today we start with the theorem of...", State = false, CourseId = 1},
                new Item {Id = 3, Name = "Video", Value = "https://www.youtube.com/embed/Wd9dOIlTWCc", State = false, CourseId = 1},
                new Item {Id = 4, Name = "Documentation", Value = "Today we start with the theorem of...", State = false, CourseId = 2},
                new Item {Id = 5, Name = "Video", Value = "https://www.youtube.com/embed/LwCRRUa8yTU", State = false, CourseId = 2},
                new Item {Id = 6, Name = "Documentation", Value = "Today we start with the theorem of...", State = false, CourseId = 3},
                new Item {Id = 7, Name = "Video", Value = "https://www.youtube.com/embed/LwCRRUa8yTU", State = false, CourseId = 3},
                new Item {Id = 8, Name = "Documentation", Value = "Today we start with the theorem of...", State = false, CourseId = 4},
                new Item {Id = 9, Name = "Video", Value = "https://www.youtube.com/embed/LwCRRUa8yTU", State = false, CourseId = 4},
                new Item {Id = 10, Name = "Documentation", Value = "Today we start with the theorem of...", State = false, CourseId = 5},
                new Item {Id = 11, Name = "Video", Value = "https://www.youtube.com/embed/LwCRRUa8yTU", State = false, CourseId = 5},
                new Item {Id = 12, Name = "Documentation", Value = "Today we start with the theorem of...", State = false, CourseId = 6},
                new Item {Id = 13, Name = "Video", Value = "https://www.youtube.com/embed/LwCRRUa8yTU", State = false, CourseId = 6},
                new Item {Id = 14, Name = "Documentation", Value = "Today we start with the theorem of...", State = false, CourseId = 7},
                new Item {Id = 15, Name = "Video", Value = "https://www.youtube.com/embed/LwCRRUa8yTU", State = false, CourseId = 7},
                new Item {Id = 16, Name = "Documentation", Value = "Today we start with the theorem of...", State = false, CourseId = 8},
                new Item {Id = 17, Name = "Video", Value = "https://www.youtube.com/embed/LwCRRUa8yTU", State = false, CourseId = 8}
            );
            
            builder.Entity<Competence>().ToTable("Competences");
            builder.Entity<Competence>().HasKey(p => p.Id);
            builder.Entity<Competence>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Competence>().Property(p => p.Title).IsRequired().HasMaxLength(60);
            builder.Entity<Competence>().Property(p => p.Description).IsRequired().HasMaxLength(2000);

            builder.Entity<Competence>().HasData(
                new Competence {Id = 1, Title = "Linguistic communication", Description = "his competence refers to the use of language as an instrument of oral and written communication, of representation, interpretation and understanding of reality, of construction and communication of knowledge and of organization and self-regulation of thought, emotions and behavior."},
                new Competence {Id = 2, Title = "Mathematical", Description = "It consists of the ability to use and relate numbers, their basic operations, symbols and forms of expression and mathematical reasoning, both to produce and interpret different types of information, as well as to expand knowledge about quantitative and spatial aspects of reality, and to solve problems related to daily life and the world of work."},
                new Competence {Id = 3, Title = "knowledge and interaction with the physical world.", Description = "It is the ability to interact with the physical world, both in its natural aspects and in those generated by human action, in such a way that the understanding of events, the prediction of consequences and the activity aimed at the improvement and preservation of the conditions of own life, of other people and of the rest of the living beings. In short, it incorporates skills to function properly, with autonomy and personal initiative in very diverse areas of life and knowledge (health, productive activity, consumption, science, technological processes, etc.), and to interpret the world, which requires the application of the basic concepts and principles that allow the analysis of phenomena from the different fields of scientific knowledge involved."},
                new Competence {Id = 4, Title = "Information processing and digital", Description = "This competence consists of having the skills to search, obtain, process and communicate information, and to transform it into knowledge. It incorporates different skills, ranging from access to information to its transmission on different media once it has been processed, including the use of information and communication technologies as an essential element to inform, learn and communicate."},
                new Competence {Id = 5, Title = "Social and civic", Description = "This competence makes it possible to understand the social reality in which we live, cooperate, live together and exercise democratic citizenship in a plural society, as well as commit to contributing to its improvement. In it are integrated diverse knowledge and complex skills that allow to participate, make decisions, choose how to behave in certain situations and take responsibility for the choices and decisions made."},
                new Competence {Id = 6, Title = "Cultural and artistic", Description = "This competence implies knowing, understanding, appreciating and critically evaluating different cultural and artistic manifestations, using them as a source of enrichment and enjoyment and considering them as part of the heritage of the peoples."},
                new Competence {Id = 7, Title = "learn to learn", Description = "Learning to learn means having the skills to start learning and being able to continue learning in an increasingly effective and autonomous way according to one's own objectives and needs."},
                new Competence {Id = 8, Title = "Autonomy and personal initiative", Description = "This competence refers, on the one hand, to the acquisition of awareness and application of a set of interrelated personal values attitudes, such as responsibility, perseverance, self-knowledge and self-esteem, creativity, self-criticism, emotional control, the ability to choose, calculate risks, and cope with problems, as well as the ability to delay the need for immediate satisfaction, to learn from mistakes, and to take risks."},
                new Competence {Id = 9, Title = "Mathematical reasoning", Description = "Ability to use and relate numbers and their basic operations, symbols and forms of expression and mathematical reasoning, both to produce and to interpret different types of information."},
                new Competence {Id = 10, Title = "Digital competence and information processing ", Description = "Skills in the treatment of information: search, obtain, process and communicate information and be able to transform it into knowledge."},
                new Competence {Id = 11, Title = "attitudes to continue learning autonomously throughout life ", Description = "Be aware of what you know, how you learn, and how you progress in learning."},
                new Competence {Id = 12, Title = "Basic Competences in didactic programming", Description = "Basic competencies must be incorporated into the didactic programming. Through them, students must acquire skills, knowledge and attitudes that have functional application in daily life. The competencies to be acquired and developed are"}
            );


            builder.Entity<TeacherCourse>().ToTable("TeacherCourses");
            builder.Entity<TeacherCourse>().HasKey(p => new {p.TeacherId, p.CourseId});
            builder.Entity<TeacherCourse>().Property(p => p.TeacherId).IsRequired();
            builder.Entity<TeacherCourse>().Property(p => p.CourseId).IsRequired();

            builder.Entity<TeacherCourse>()
                .HasOne(p => p.Teacher)
                .WithMany(p => p.TeacherCourses)
                .HasForeignKey(p => p.TeacherId);
            builder.Entity<TeacherCourse>()
                .HasOne(p => p.Course)
                .WithMany(p => p.TeacherCourses)
                .HasForeignKey(p => p.CourseId);

            builder.Entity<TeacherCourse>().HasData(
                new TeacherCourse {TeacherId = 1, CourseId = 1},
                new TeacherCourse {TeacherId = 1, CourseId = 2},
                new TeacherCourse {TeacherId = 1, CourseId = 3},
                new TeacherCourse {TeacherId = 1, CourseId = 4},
                new TeacherCourse {TeacherId = 1, CourseId = 5},
                new TeacherCourse {TeacherId = 2, CourseId = 6},
                new TeacherCourse {TeacherId = 2, CourseId = 7},
                new TeacherCourse {TeacherId = 2, CourseId = 8},
                new TeacherCourse {TeacherId = 2, CourseId = 9},
                new TeacherCourse {TeacherId = 3, CourseId = 1},
                new TeacherCourse {TeacherId = 3, CourseId = 2},
                new TeacherCourse {TeacherId = 3, CourseId = 3},
                new TeacherCourse {TeacherId = 3, CourseId = 4},
                new TeacherCourse {TeacherId = 4, CourseId = 5},
                new TeacherCourse {TeacherId = 4, CourseId = 6},
                new TeacherCourse {TeacherId = 4, CourseId = 7}
            );
            
            builder.Entity<CourseCompetence>().ToTable("CourseCompetences");
            builder.Entity<CourseCompetence>().HasKey(p => new {p.CourseId, p.CompetenceId});
            builder.Entity<CourseCompetence>().Property(p => p.CourseId).IsRequired();
            builder.Entity<CourseCompetence>().Property(p => p.CompetenceId).IsRequired();

            builder.Entity<CourseCompetence>()
                .HasOne(p => p.Course)
                .WithMany(p => p.CourseCompetences)
                .HasForeignKey(p => p.CourseId);
            builder.Entity<CourseCompetence>()
                .HasOne(p => p.Competence)
                .WithMany(p => p.CourseCompetences)
                .HasForeignKey(p => p.CompetenceId);

            builder.Entity<CourseCompetence>().HasData(
                new CourseCompetence {CourseId = 1, CompetenceId = 1},
                new CourseCompetence {CourseId = 1, CompetenceId = 2},
                new CourseCompetence {CourseId = 1, CompetenceId = 3},
                new CourseCompetence {CourseId = 1, CompetenceId = 4},
                new CourseCompetence {CourseId = 1, CompetenceId = 5},
                new CourseCompetence {CourseId = 1, CompetenceId = 6},
                new CourseCompetence {CourseId = 1, CompetenceId = 7},
                new CourseCompetence {CourseId = 1, CompetenceId = 8},
                new CourseCompetence {CourseId = 2, CompetenceId = 1},
                new CourseCompetence {CourseId = 2, CompetenceId = 2},
                new CourseCompetence {CourseId = 2, CompetenceId = 3},
                new CourseCompetence {CourseId = 2, CompetenceId = 4},
                new CourseCompetence {CourseId = 2, CompetenceId = 5},
                new CourseCompetence {CourseId = 2, CompetenceId = 6},
                new CourseCompetence {CourseId = 2, CompetenceId = 7},
                new CourseCompetence {CourseId = 3, CompetenceId = 8},
                new CourseCompetence {CourseId = 3, CompetenceId = 9},
                new CourseCompetence {CourseId = 3, CompetenceId = 10},
                new CourseCompetence {CourseId = 3, CompetenceId = 11},
                new CourseCompetence {CourseId = 3, CompetenceId = 12},
                new CourseCompetence {CourseId = 3, CompetenceId = 1},
                new CourseCompetence {CourseId = 4, CompetenceId = 11},
                new CourseCompetence {CourseId = 4, CompetenceId = 9},
                new CourseCompetence {CourseId = 4, CompetenceId = 8},
                new CourseCompetence {CourseId = 4, CompetenceId = 7},
                new CourseCompetence {CourseId = 5, CompetenceId = 2},
                new CourseCompetence {CourseId = 5, CompetenceId = 5},
                new CourseCompetence {CourseId = 5, CompetenceId = 8},
                new CourseCompetence {CourseId = 5, CompetenceId = 11},
                new CourseCompetence {CourseId = 5, CompetenceId = 7},
                new CourseCompetence {CourseId = 5, CompetenceId = 12},
                new CourseCompetence {CourseId = 5, CompetenceId = 4},
                new CourseCompetence {CourseId = 5, CompetenceId = 9},
                new CourseCompetence {CourseId = 6, CompetenceId = 6},
                new CourseCompetence {CourseId = 6, CompetenceId = 7},
                new CourseCompetence {CourseId = 6, CompetenceId = 8},
                new CourseCompetence {CourseId = 6, CompetenceId = 11},
                new CourseCompetence {CourseId = 6, CompetenceId = 1},
                new CourseCompetence {CourseId = 6, CompetenceId = 2},
                new CourseCompetence {CourseId = 6, CompetenceId = 3},
                new CourseCompetence {CourseId = 7, CompetenceId = 1},
                new CourseCompetence {CourseId = 7, CompetenceId = 3},
                new CourseCompetence {CourseId = 7, CompetenceId = 5},
                new CourseCompetence {CourseId = 7, CompetenceId = 7},
                new CourseCompetence {CourseId = 7, CompetenceId = 9},
                new CourseCompetence {CourseId = 8, CompetenceId = 12},
                new CourseCompetence {CourseId = 8, CompetenceId = 11},
                new CourseCompetence {CourseId = 8, CompetenceId = 10},
                new CourseCompetence {CourseId = 8, CompetenceId = 9}
            );
            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}