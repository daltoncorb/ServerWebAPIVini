using Microsoft.EntityFrameworkCore;
using SchoolS.Models;

namespace SchoolS.Data
{
    public class DataContext: DbContext{
        
        public DataContext(DbContextOptions<DataContext>options):base(options){}
            public DbSet<Student> Students {get; set;}
            public DbSet<Professor> Professors { get; set; }
        


    }        

}