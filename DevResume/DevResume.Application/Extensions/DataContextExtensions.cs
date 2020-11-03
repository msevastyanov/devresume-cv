using System;
using System.Linq;
using DevResume.Domain.ViewModels;
using DevResume.Infrastructure.Context;
using DevResume.ServiceLayer.Services;

namespace DevResume.Application.Extensions
{
    public static class DataContextExtensions
    {
        public static void EnsureSeeds(this DataContext context, IUserService userService)
        {
            SeedUsers(context, userService);
        }

        private static void SeedUsers(DataContext context, IUserService userService)
        {
            if (context.Users.Any()) return;

            userService.CreateAccount(
                new CreateUser
                {
                    Username = "sevastyanov",
                    FirstNameEn = "Mark",
                    LastNameEn = "Sevastyanov",
                    FirstNameRus = "Марк",
                    MiddleNameRus = "Станиславович",
                    LastNameRus = "Севастьянов",
                    DateOfBirth = new DateTime(1995, 11, 27),
                    Password = "tZ1277!"
                }).Wait();
        }
    }
}