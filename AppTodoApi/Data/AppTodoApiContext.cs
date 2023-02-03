using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppTodoApi.Models;

namespace AppTodoApi.Data
{
    public class AppTodoApiContext : DbContext
    {
        public AppTodoApiContext (DbContextOptions<AppTodoApiContext> options)
            : base(options)
        {
        }

        public DbSet<AppTodoApi.Models.TodoItems> TodoItems { get; set; } = default!;
    }
}
