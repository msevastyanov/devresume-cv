using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevResume.Domain.Entities
{
    public class Resume : BaseEntity
    {
        [Required]
        public string Key { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string About { get; set; }
        public string Languages { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string VK { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Github { get; set; }
        public string Gitlab { get; set; }
        public CommunicationMethod CommunicationMethod { get; set; }
        public Theme Theme { get; set; }
        public ApplicationUser User { get; set; }
        public List<Section> Sections { get; set; }
    }

    public enum CommunicationMethod
    {
        Phone, Email, Messengers
    }
}