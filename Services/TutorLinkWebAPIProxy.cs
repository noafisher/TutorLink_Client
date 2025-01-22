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
        /*
        //Define the serevr IP address! (should be realIP address if you are using a device that is not running on the same machine as the server)
        private static string serverIP = "localhost";
        private HttpClient client;
        private string baseUrl;
        public static string BaseAddress = (DeviceInfo.Platform == DevicePlatform.Android &&
            DeviceInfo.DeviceType == DeviceType.Virtual) ? "http://10.0.2.2:5110/api/" : $"http://{serverIP}:5110/api/";
        private static string ImageBaseAddress = (DeviceInfo.Platform == DevicePlatform.Android &&
            DeviceInfo.DeviceType == DeviceType.Virtual) ? "http://10.0.2.2:5110" : $"http://{serverIP}:5110";
        */
        #endregion

        #region with tunnel
        //Define the serevr IP address! (should be realIP address if you are using a device that is not running on the same machine as the server)
        private static string serverIP = "https://05smzxlj-5049.euw.devtunnels.ms/";
        private HttpClient client;
        private string baseUrl;
        public static string BaseAddress = "https://05smzxlj-5049.euw.devtunnels.ms/api/";
        private static string ImageBaseAddress = "https://05smzxlj-5049.euw.devtunnels.ms/";
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
            string url = $"{this.baseUrl}RegisterStudent";
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

    }


}