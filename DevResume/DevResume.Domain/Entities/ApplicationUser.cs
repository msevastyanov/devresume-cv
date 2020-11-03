using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DevResume.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstNameRus { get; set; }
        public string MiddleNameRus { get; set; }
        public string LastNameRus { get; set; }
        public string FirstNameEn { get; set; }
        public string LastNameEn { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Resume> Resumes { get; set; }
    }
}