using System;
using TutorLinkClient.Services;
namespace TutorLinkClient.Models;
public class TeacherDTO
{



    public int TeacherId { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Pass { get; set; }
    public string UserAddress { get; set; }
    public double MaxDistance { get; set; }
    public bool GoToStudent { get; set; }
    public bool TeachAtHome { get; set; }
    public int Vetek { get; set; }
    public int PricePerHour { get; set; }
    public string ProfileImagePath { get; set; }

    public string ImageURL
    {
        get
        {
            return TutorLinkWebAPIProxy.BaseAddress + this.ProfileImagePath;
        }
    }
    public List<TeacherSubject>? TeacherSubjects { get; set; }

    public string Subjects
    {
        get
        {
            if (TeacherSubjects == null)
            {
                return "None";
            }
            else
            {
                string str = "";
                for (int i = 0; i < TeacherSubjects.Count; i++)
                {
                    str += TeacherSubjects[i].SubjectName;
                    if (i < TeacherSubjects.Count - 1)
                        str += ", ";
                }
                return str;
            }  
        }
    }

    public string DisplayName
    {
        get
        {
            return $"{LastName}, {FirstName}";
        }
    }
    public TeacherDTO() { }
}

