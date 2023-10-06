namespace Schwartmanns;

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Schwartmanns.Data;
using Schwartmanns.Models;

public class Seed
{

    private readonly DataContext dataContext;
    public Seed(DataContext context)
    {
        this.dataContext = context;
    }
    public void SeedDataContext()
    {

        dataContext.Database.EnsureCreated();

        if (!dataContext.Users.Any())
        {
            SeedUsers(dataContext);
        };
        if (!dataContext.Clients.Any())
        {
            SeedClients(dataContext);
        };
        if (!dataContext.Jobs.Any())
        {
            SeedJobs(dataContext);
        };

       

    }

    private void SeedUsers(DataContext context)
    {
        if (!context.Users.Any())
        {
            context.Users.AddRange(
               new User { Name = "User1", Email = "user1@example.com", PasswordHash = BCrypt.HashPassword("password1"), Type = "Admin" },
               new User { Name = "User2", Email = "user2@example.com", PasswordHash = BCrypt.HashPassword("password2"), Type = "User" },
               new User { Name = "User3", Email = "user3@example.com", PasswordHash = BCrypt.HashPassword("password3"), Type = "User" },
               new User { Name = "User4", Email = "user4@example.com", PasswordHash = BCrypt.HashPassword("password4"), Type = "Admin" },
               new User { Name = "User5", Email = "user5@example.com", PasswordHash = BCrypt.HashPassword("password5"), Type = "User" },
               new User { Name = "User6", Email = "user6@example.com", PasswordHash = BCrypt.HashPassword("password6"), Type = "Admin" },
               new User { Name = "User7", Email = "user7@example.com", PasswordHash = BCrypt.HashPassword("password7"), Type = "User" },
               new User { Name = "User8", Email = "user8@example.com", PasswordHash = BCrypt.HashPassword("password8"), Type = "User" },
               new User { Name = "User9", Email = "user9@example.com", PasswordHash = BCrypt.HashPassword("password9"), Type = "User" },
               new User { Name = "User10", Email = "user10@example.com", PasswordHash = BCrypt.HashPassword("password10"), Type = "User" },
               new User { Name = "User11", Email = "user11@example.com", PasswordHash = BCrypt.HashPassword("password11"), Type = "Admin" },
               new User { Name = "User12", Email = "user12@example.com", PasswordHash = BCrypt.HashPassword("password12"), Type = "User" }
            );

            context.SaveChanges();
        }
    }

    private static void SeedClients(DataContext context)
    {
        if (!context.Clients.Any())
        {
            context.Clients.AddRange(
                new Client { Name = "Client1", Phone = "123-456-7890", Address = "Address1" },
                new Client { Name = "Client2", Phone = "987-654-3210", Address = "Address2" },
                new Client { Name = "Client3", Phone = "555-555-5555", Address = "Address3" },
                new Client { Name = "Client4", Phone = "444-444-4444", Address = "Address4" },
                new Client { Name = "Client5", Phone = "333-333-3333", Address = "Address5" },
                new Client { Name = "Client6", Phone = "222-222-2222", Address = "Address6" },
                new Client { Name = "Client7", Phone = "111-111-1111", Address = "Address7" }
               

            );

            context.SaveChanges();
        }
    }

    private static void SeedJobs(DataContext context)
    {
        if (!context.Jobs.Any())
        {
            Random random = new Random();

            List<Project> projects = new List<Project>
            {
                new Project { Name = "Project2", FileName = "File2", FilePath = "/path/to/file2", UserId = 2, ClientId = 2 },
                new Project { Name = "Project3", FileName = "File3", FilePath = "/path/to/file3", UserId = 3, ClientId = 3 },
                new Project { Name = "Project4", FileName = "File4", FilePath = "/path/to/file4", UserId = 4, ClientId = 2 },
                new Project { Name = "Project5", FileName = "File5", FilePath = "/path/to/file5", UserId = 5, ClientId = 5 },
                new Project { Name = "Project6", FileName = "File6", FilePath = "/path/to/file6", UserId = 6, ClientId = 6 },
                new Project { Name = "Project7", FileName = "File7", FilePath = "/path/to/file7", UserId = 7, ClientId = 2 },
                new Project { Name = "Project8", FileName = "File8", FilePath = "/path/to/file8", UserId = 8, ClientId = 6 },
                new Project { Name = "Project9", FileName = "File9", FilePath = "/path/to/file9", UserId = 9, ClientId = 3 },
                new Project { Name = "Project10", FileName = "File10", FilePath = "/path/to/file10", UserId = 10, ClientId = 2 },
                new Project { Name = "Project11", FileName = "File11", FilePath = "/path/to/file11", UserId = 11, ClientId = 7 },
                new Project { Name = "Project12", FileName = "File12", FilePath = "/path/to/file12", UserId = 12, ClientId = 4 }
            };

            List<Job> jobs = new List<Job>();

            foreach (var project in projects)
            {
                int numSheets = random.Next(1, 6); 

                for (int i = 0; i < numSheets; i++)
                {
                    var job = new Job
                    {
                        Project = project,
                        Sheets = new List<Sheet>(),
                    };

                    int numCircles = random.Next(1, 6); 
                    int numLines = random.Next(1, 6);  

                    var sheet = new Sheet
                    {
                        Length = random.NextDouble() * 10 + 5, 
                        Width = random.NextDouble() * 10 + 5,  
                        Job = job,
                        Circles = new List<Circle>(),
                        Lines = new List<Line>()
                    };

                    for (int j = 0; j < numCircles; j++)
                    {
                        sheet.Circles.Add(new Circle
                        {
                            XPosition = random.NextDouble() * 10,
                            YPosition = random.NextDouble() * 10,
                            Radius = random.NextDouble() * 5 + 1 
                        });
                    }

                    for (int k = 0; k < numLines; k++)
                    {
                        sheet.Lines.Add(new Line
                        {
                            XPosition = random.NextDouble() * 10,
                            YPosition = random.NextDouble() * 10,
                            Bulge = random.NextDouble() * 1.5 
                        });
                    }

                    job.Sheets.Add(sheet);
                    jobs.Add(job);
                }
            }

            context.Jobs.AddRange(jobs);

            

            context.SaveChanges();
        }
    }


}

