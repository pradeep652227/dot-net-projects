using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvCProj_1.Models;

namespace MvCProj_1.Data
{
    public class MvCProj_1Context : DbContext
    {
        public MvCProj_1Context (DbContextOptions<MvCProj_1Context> options)
            : base(options)
        {
        }

        public DbSet<MvCProj_1.Models.Movie> Movie { get; set; } = default!;
        public DbSet<MvCProj_1.Models.JobPostsModel> JobPosts { get; set; } = default!;
        public DbSet<MvCProj_1.Models.Authentication.UserModel>Users { get; set; } = default!;
    }
}
