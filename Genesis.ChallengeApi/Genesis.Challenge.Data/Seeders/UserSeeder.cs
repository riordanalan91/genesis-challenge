using Genesis.Challenge.Data.Contexts;
using Genesis.Challenge.Data.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genesis.Challenge.Data.Seeders
{
    public class UserSeeder
    {
        public static void Run(IServiceProvider serviceProvider)
        {
            using (var context = new UsersDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<UsersDbContext>>()))
            {
                if (context.Users.Any())
                {
                    return;   
                }

                context.Users.AddRange(
                    new UserDto
                    {
                        Id = new Guid("2e0f3527-c781-4866-a366-edd44b84a7b6"),
                        Name = "Alan Riordan",
                        Email = "ariordan@domain.com",
                        Password = "qwerty",
                        TelephoneNumbers = "[\"0851234567\", \"0211234567\"]",
                        CreatedOnUtc = new DateTime(2019, 8, 1),
                        LastLoginOnUtc = new DateTime(2019, 8, 22),
                        LastUpdatedOnUtc = new DateTime(2019, 8, 1)
                    },
                    new UserDto
                    {
                        Id = new Guid("00c96463-2db1-48b7-94d3-3e4e2617d904"),
                        Name = "Jane Doe",
                        Email = "jdoe@domain.com",
                        Password = "pass1",
                        TelephoneNumbers = "[\"08576543212\", \"0217654321\"]",
                        CreatedOnUtc = new DateTime(2019, 7, 1),
                        LastLoginOnUtc = new DateTime(2019, 8, 22),
                        LastUpdatedOnUtc = new DateTime(2019, 7, 1)
                    });

                context.SaveChanges();
            }
        }
    }
}
