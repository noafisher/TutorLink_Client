using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TutorLinkClient.Models;

namespace TutorLinkClient.Services
{
    public class TutorLinkWebAPIProxy
    {
        #region without tunnel

        //Define the serevr IP address! (should be realIP address if you are using a device that is not running on the same machine as the server)
        //private static string serverIP = "localhost";
        //private HttpClient client;
        //private string baseUrl;
        //public static string BaseAddress = (DeviceInfo.Platform == DevicePlatform.Android &&
        //    DeviceInfo.DeviceType == DeviceType.Virtual) ? "http://10.0.2.2:5049/api/" : $"http://{serverIP}:5049/api/";
        //private static string ImageBaseAddress = (DeviceInfo.Platform == DevicePlatform.Android &&
        //    DeviceInfo.DeviceType == DeviceType.Virtual) ? "http://10.0.2.2:5049" : $"http://{serverIP}:5049";

        #endregion

        #region with tunnel
        //Define the serevr IP address! (should be realIP address if you are using a device that is not running on the same machine as the server)
        private static string serverIP = "https://05smzxlj-5049.euw.devtunnels.ms/";
        private HttpClient client;
        private string baseUrl;
        public static string BaseAddress = "https://05smzxlj-5049.euw.devtunnels.ms/api/";
        public static string ImageBaseAddress = "https://05smzxlj-5049.euw.devtunnels.ms/";

        #endregion

        public TutorLinkWebAPIProxy()
        {
            //Set client handler to support cookies!!
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new System.Net.CookieContainer();

            this.client = new HttpClient(handler);
            this.baseUrl = BaseAddress;
        }

        public async Task<TeacherDTO?> LoginTeacherAsync(LoginInfoDTO userInfo)
        {
            //Set URI to the specific function API - מחפש את הכתובת של הפעולה בשרת
            string url = $"{this.baseUrl}loginTeacher";
            try
            {
                //Call the server API - מעביר את האובייקט לשרת
                string json = JsonSerializer.Serialize(userInfo);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    TeacherDTO? result = JsonSerializer.Deserialize<TeacherDTO>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<StudentDTO?> LoginStudentAsync(LoginInfoDTO userInfo)
        {
            //Set URI to the specific function API - מחפש את הכתובת של הפעולה בשרת
            string url = $"{this.baseUrl}loginStudent";
            try
            {
                //Call the server API - מעביר את האובייקט לשרת 
                string json = JsonSerializer.Serialize(userInfo);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    StudentDTO? result = JsonSerializer.Deserialize<StudentDTO>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
                }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<TeacherDTO?> RegisterTeacherAsync(TeacherDTO teacher)
        {
            //Set URI to the specific function API - מחפש את הכתובת של הפעולה בשרת
            string url = $"{this.baseUrl}registerTeacher";
            try
            {
                //Call the server API - מעביר את האובייקט לשרת
                string json = JsonSerializer.Serialize(teacher);
                //
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    TeacherDTO? result = JsonSerializer.Deserialize<TeacherDTO>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<StudentDTO?> RegisterStudentAsync(StudentDTO student)
        {
            //Set URI to the specific function API - מחפש את הכתובת של הפעולה בשרת
            string url = $"{this.baseUrl}registerStudent";
            try
            {
                //Call the server API - מעביר את האובייקט לשרת
                string json = JsonSerializer.Serialize(student);
                //
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    StudentDTO? result = JsonSerializer.Deserialize<StudentDTO>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List <TeacherDTO>> GetAllTeachers()
        {
            //Set URI to the specific function API - מחפש את הכתובת של הפעולה בשרת
            string url = $"{this.baseUrl}GetAllTeachers";
            try
            {
               
                HttpResponseMessage response = await client.GetAsync(url);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<TeacherDTO>? result = JsonSerializer.Deserialize< List<TeacherDTO>>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<SubjectDTO>> GetAllSubjects()
        {
            //Set URI to the specific function API - מחפש את הכתובת של הפעולה בשרת
            string url = $"{this.baseUrl}GetAllSubjects";
            try
            {

                HttpResponseMessage response = await client.GetAsync(url);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<SubjectDTO>? result = JsonSerializer.Deserialize<List<SubjectDTO>>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<SubjectDTO>> GetTeacherSubjects()
        {
            //Set URI to the specific function API - מחפש את הכתובת של הפעולה בשרת
            string url = $"{this.baseUrl}GetTeacherSubjects";
            try
            {

                HttpResponseMessage response = await client.GetAsync(url);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<SubjectDTO>? result = JsonSerializer.Deserialize<List<SubjectDTO>>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ReviewDTO> RateTeacherAsync(ReviewDTO reviewDTO)
        {
            string url = $"{this.baseUrl}RateTeacher";
            try
            {
                //Call the server API - מעביר את האובייקט לשרת
                string json = JsonSerializer.Serialize(reviewDTO);
                //
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    ReviewDTO? result = JsonSerializer.Deserialize<ReviewDTO>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //This method call the UploadProfileImage web API on the server and return the AppUser object with the given URL
        //of the profile image or null if the call fails
        //when registering a user it is better first to call the register command and right after that call this function
        public async Task<StudentDTO?> UploadProfileImageStudent(string imagePath)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}uploadprofileimage";
            try
            {
                //Create the form data
                MultipartFormDataContent form = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(File.ReadAllBytes(imagePath));
                form.Add(fileContent, "file", imagePath);
                //Call the server API
                HttpResponseMessage response = await client.PostAsync(url, form);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    StudentDTO? result = JsonSerializer.Deserialize<StudentDTO>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TeacherDTO?> UploadProfileImageTeacher(string imagePath)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}uploadprofileimage";
            try
            {
                //Create the form data
                MultipartFormDataContent form = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(File.ReadAllBytes(imagePath));
                form.Add(fileContent, "file", imagePath);
                //Call the server API
                HttpResponseMessage response = await client.PostAsync(url, form);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    TeacherDTO? result = JsonSerializer.Deserialize<TeacherDTO>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetImagesBaseAddress()
        {
            return TutorLinkWebAPIProxy.ImageBaseAddress;
        }

        public async Task<ReportDTO> ReportUserAsync(ReportDTO reportDTO)
        {
            string url = $"{this.baseUrl}ReportUser";
            try
            {
                //Call the server API - מעביר את האובייקט לשרת
                string json = JsonSerializer.Serialize(reportDTO);
                //
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);

                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    ReportDTO? result = JsonSerializer.Deserialize<ReportDTO>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<List<StudentDTO>> GetAllStudents()
        {
            //Set URI to the specific function API - מחפש את הכתובת של הפעולה בשרת
            string url = $"{this.baseUrl}GetAllStudents";
            try
            {

                HttpResponseMessage response = await client.GetAsync(url);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<StudentDTO>? result = JsonSerializer.Deserialize<List<StudentDTO>>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Lesson>> GetAllLessonsAsync(DateOnly date)
        {
            string url = $"{this.baseUrl}GetAllLessons";
            try
            {
                //Call the server API - מעביר את האובייקט לשרת
                string json = JsonSerializer.Serialize(date);
                //
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);

                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<Lesson>? result = JsonSerializer.Deserialize<List<Lesson>>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<Lesson> AddLessonAsync(Lesson lesson)
        {
            string url = $"{this.baseUrl}AddLesson";
            try
            {
                //Call the server API - מעביר את האובייקט לשרת
                string json = JsonSerializer.Serialize(lesson);
                //
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);

                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    Lesson? result = JsonSerializer.Deserialize<Lesson>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<StudentDTO>>FindStudents(string search)
        {
            string url = $"{this.baseUrl}FindStudents?search={search}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<StudentDTO>? result = JsonSerializer.Deserialize<List<StudentDTO>>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ReportDTO>> GetReportsNotProcessed()
        {
            //Set URI to the specific function API - מחפש את הכתובת של הפעולה בשרת
            string url = $"{this.baseUrl}GetReportsNotProcessed";
            try
            {

                HttpResponseMessage response = await client.GetAsync(url);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    //Extract the content as string
                    string resContent = await response.Content.ReadAsStringAsync();
                    //Desrialize result
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    List<ReportDTO>? result = JsonSerializer.Deserialize<List<ReportDTO>>(resContent, options);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> ProcessReport(int id)
        {
            //Set URI to the specific function API - מחפש את הכתובת של הפעולה בשרת
            string url = $"{this.baseUrl}ProcessReport?id={id}";
            try
            {

                HttpResponseMessage response = await client.GetAsync(url);
                //Check status
                if (response.IsSuccessStatusCode)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> BlockStudent(int id)
        {
            //Set URI to the specific function API - מחפש את הכתובת של הפעולה בשרת
            string url = $"{this.baseUrl}BlockStudent?id={id}";
            try
            {

                HttpResponseMessage response = await client.GetAsync(url);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> BlockTeacher(int id)
        {
            //Set URI to the specific function API - מחפש את הכתובת של הפעולה בשרת
            string url = $"{this.baseUrl}BlockTeacher?id={id}";
            try
            {

                HttpResponseMessage response = await client.GetAsync(url);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        //This method call the UpdateUser web API on the server and return true if the call was successful
        //or false if the call fails
        public async Task<bool> UpdateStudent(StudentDTO student)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}UpdateStudent";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(student);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //This method call the UpdateUser web API on the server and return true if the call was successful
        //or false if the call fails
        public async Task<bool> UpdateTeacher(TeacherDTO teacher)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUrl}UpdateTeacher";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(teacher);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }




}