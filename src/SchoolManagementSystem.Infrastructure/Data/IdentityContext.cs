
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SchoolManagementSystem.Infrastructure.Data;

public class IdentityContext : IdentityDbContext<IdentityUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        this.SeedUsers(builder);  
        this.SeedRoles(builder);  
        this.SeedUserRoles(builder);  
    }  

    private void SeedUsers(ModelBuilder builder)  
    {   
        IdentityUser admin = new IdentityUser()  
        {  
            Id = "8ae7e3b7-0e7a-46c0-957b-394f5a92d858",  
            UserName = "admin",  
            NormalizedUserName = "ADMIN",
            Email = "admin@dclase.com",  
            NormalizedEmail = "ADMIN@DCLASE.COM",
            PhoneNumber = "53452234",
            PasswordHash = "AQAAAAEAACcQAAAAEKn9lFizCRqsvNtqVeUqX7Nrq3XZYVkDqCuX0iMHzzS/9YWVrG8EJ4SakwPEvHRl3w==",
            SecurityStamp = "QLJLDMNXCTJPGIQYC2Z4UNLIJQHAAUNP",
            ConcurrencyStamp = "a0cc035a-39f4-477b-98d7-28a137aef4f8",
            LockoutEnabled = true,  
        };

        builder.Entity<IdentityUser>().HasData(admin);

        IdentityUser secretary = new IdentityUser()  
        {  
            Id = "33fddbfa-24fd-449c-8b14-47d69e31ba58",  
            UserName = "secretary",  
            NormalizedUserName = "SECRETARY",
            Email = "secretary@dclase.com",  
            NormalizedEmail = "SECRETARY@DCLASE.COM",
            PhoneNumber = "54792093",
            PasswordHash = "AQAAAAEAACcQAAAAEMqMPS4f4FhSorr2p3/P8geVCRFyoLAN1hp8q/V1D9rBR+xEGmLPuT1D/TlZBsrmtw==",
            SecurityStamp = "6NJTRPIPQJQBEJULDBMUHZGTT5BFS4FB",
            ConcurrencyStamp = "c1b45808-ed7b-4bf8-b6ce-cd3a1f3e2549",
            LockoutEnabled = true,  
        };

        builder.Entity<IdentityUser>().HasData(secretary);  
    }  

    private void SeedRoles(ModelBuilder builder)  
    {  
        builder.Entity<IdentityRole>().HasData(  
            new IdentityRole() { 
                Id = "da9533ca-0804-4557-abc8-046e05514ae0", 
                Name = "Admin",   
                NormalizedName = "ADMIN", 
                ConcurrencyStamp = "0e20d00d-817a-4d93-a9f7-6bc60eeee6c9"
            },
            new IdentityRole() { 
                Id = "d39c3aa3-4cce-45e5-9fe6-69c071ee6758", 
                Name = "User",   
                NormalizedName = "USER", 
                ConcurrencyStamp = "4708f4c2-2a06-4c5b-adbc-849nal84h92m"
            },
            new IdentityRole() { 
                Id = "d3ir9344-847h-84yh-v83r-69c071ee6758", 
                Name = "Secretary",   
                NormalizedName = "SECRETARY", 
                ConcurrencyStamp = "84ehsk83-vr87-84hw-sndi-3d38ccc5e60a"
            }     
        );  
    }  

    private void SeedUserRoles(ModelBuilder builder)  
    {  
        builder.Entity<IdentityUserRole<string>>().HasData(  
            new IdentityUserRole<string>() { 
                UserId = "8ae7e3b7-0e7a-46c0-957b-394f5a92d858",
                RoleId = "da9533ca-0804-4557-abc8-046e05514ae0"
            },
            new IdentityUserRole<string>() { 
                UserId = "8ae7e3b7-0e7a-46c0-957b-394f5a92d858",
                RoleId = "d39c3aa3-4cce-45e5-9fe6-69c071ee6758"
            },
            new IdentityUserRole<string>() { 
                UserId = "33fddbfa-24fd-449c-8b14-47d69e31ba58",
                RoleId = "d3ir9344-847h-84yh-v83r-69c071ee6758"
            },
            new IdentityUserRole<string>() { 
                UserId = "33fddbfa-24fd-449c-8b14-47d69e31ba58",
                RoleId = "d39c3aa3-4cce-45e5-9fe6-69c071ee6758"
            }  
        );  
    }  
}
