using System;
using Microsoft.EntityFrameworkCore;

namespace ATM_MVC.Models
{
    public class Connect :DbContext
    {
       public DbSet<AcountInfo> acountInfos { get; set; }
       public DbSet<UserInfo> userInfos { get; set; }
       protected override void OnConfiguring(DbContextOptionsBuilder db)
       {
           db.UseSqlServer("Data source=.;initial catalog=ATM;Integrated security=true");
       }
    }

}