using System;
using TutorLinkClient.Services;

namespace TutorLinkClient.Models
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pass { get; set; }
        public int CurrentClass { get; set; }
        public string UserAddress { get; set; }
        public string ProfileImagePath { get; set; }
        public string ImageURL
        {
            get
            {
                return TutorLinkWebAPIProxy.BaseAddress + this.ProfileImagePath;
            }
        }
        public string DisplayName
        {
            get
            {
                return $"{LastName}, {FirstName}";
            }
        }
        public bool IsBlocked { get; set; }

        public StudentDTO() { }
    }
}
