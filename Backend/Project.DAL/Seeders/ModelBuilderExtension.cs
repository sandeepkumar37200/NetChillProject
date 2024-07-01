using Microsoft.EntityFrameworkCore;
using Project.DAL.Domain_Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Project.DAL.Seeders
{
    public static class ModelBuilderExtension
    {
        private static List<byte[]> generatePassword()
        {
            byte[] PasswordHash, PasswordSalt;

            using (var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Admin@123"));
            }
            List<byte[]> passwords = new List<byte[]>();
            passwords.Add(PasswordHash);
            passwords.Add(PasswordSalt);
            return passwords;
        }
        public static void AdminSeeder(this ModelBuilder modelBuilder)
        {
            var passwords = generatePassword();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    EmailId = "admin1@netchill.com",
                    PasswordHash = passwords[0],
                    PasswordSalt = passwords[1],
                    FullName="admin1",
                    IsAdmin = true,
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    EmailId = "admin2@netchill.com",
                    FullName="admin2",
                    PasswordHash = passwords[0],
                    PasswordSalt = passwords[1],
                    IsAdmin = true,
                }
            );

        }
    }
}
