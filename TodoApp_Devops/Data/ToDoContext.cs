using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ToDoApp_Devops.Models;
using ToDoApp_Devops.Models;

namespace ToDoApp_Devops.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
