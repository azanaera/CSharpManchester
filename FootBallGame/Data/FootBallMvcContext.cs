using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FootBallGame.Models;

namespace FootBallGame.Data
{
    public class FootBallMvcContext : DbContext
    {
        public FootBallMvcContext (DbContextOptions<FootBallMvcContext> options)
            : base(options)
        {
        }

        public DbSet<FootBallGame.Models.Team> Team { get; set; }
    }
}
