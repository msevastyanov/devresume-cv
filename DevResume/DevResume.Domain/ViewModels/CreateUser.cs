using System;

namespace DevResume.Domain.ViewModels
{
    public class CreateUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstNameRus { get; set; }
        public string MiddleNameRus { get; set; }
        public string LastNameRus { get; set; }
        public string FirstNameEn { get; set; }
        public string LastNameEn { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}