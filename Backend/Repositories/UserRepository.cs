using System.IO.Compression;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlbertslundForsyning.Entities;
using AlbertslundForsyning.Context;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace AlbertslundForsyning.Repositories
{
    public class UserRepository
    {
        public async Task<List<User>> GetAll()
        {
            using (var context = new EFCoreContext()) // get connection to the DB
            {
                return await context.Users.ToListAsync();
            }
        }

        public User ValidateLogin(User user)
        {
            using (var context = new EFCoreContext()) // get connection to the DB
            {
                // lambda expression: For every user, x, check username and password.
                var validatedUser = context.Users
                .Include(x => x.DataReadings.OrderByDescending(x => x.Date))
                .Where(x => x.Username == user.Username && x.Password == user.Password)
                .FirstOrDefault();

                return validatedUser;
            }
        }

        public async Task<User> Create(User user)
        {
            // get connection to Database
            using (var context = new EFCoreContext())
            {
               context.Add(user);
               await context.SaveChangesAsync(); 
            }
            return user;
        }


        // public User UpdateUser(User user)
        // {
        //     using (var context = new EFCoreContext()) // get connection to the DB
        //     {
        //         // lambda expression: For every user, x, check username and password.

        //         var test = context.Users.Where(x => x.Username == user.Username && x.Password == user.Password).First();
        //         test.FirstName = "Bill";
        //         context.SaveChanges();

        //         return test;
        //     }
        // }


        // context.Remove(context.Users.Single(a => a.UserId == 1));
        // context.SaveChanges();
    }
}