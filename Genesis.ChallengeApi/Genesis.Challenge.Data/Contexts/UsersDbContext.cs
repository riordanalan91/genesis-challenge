using Genesis.Challenge.Data.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genesis.Challenge.Data.Contexts
{
    public class UsersDbContext: DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserDto> Users { get; set; }
    }
}
