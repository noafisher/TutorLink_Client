using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using TutorLinkClient.Models;

namespace TutorLinkClient.Services
{
    public class ChatProxy
    {

        #region without tunnel
        //Define the serevr IP address! (should be realIP address if you are using a device that is not running on the same machine as the server)
        //private static string serverIP = "localhost";
        //private readonly HubConnection hubConnection;
        //private string baseUrl;
        //public static string BaseAddress = (DeviceInfo.Platform == DevicePlatform.Android &&
        //    DeviceInfo.DeviceType == DeviceType.Virtual) ? "http://10.0.2.2:5049/chatHub/" : $"http://{serverIP}:5049/chatHub/";

        #endregion

        #region with tunnel

        //Define the serevr IP address! (should be realIP address if you are using a device that is not running on the same machine as the server)
        private static string serverIP = "05smzxlj-5049.euw.devtunnels.ms";
        private readonly HubConnection hubConnection;
        private string baseUrl;
        public static string BaseAddress = "https://05smzxlj-5049.euw.devtunnels.ms/chatHub/";

        #endregion

        public ChatProxy()
        {
            string chatUrl = GetChatUrl();
            hubConnection = new HubConnectionBuilder().WithUrl(chatUrl)
                .WithAutomaticReconnect()
                .WithKeepAliveInterval(TimeSpan.FromSeconds(10))
                .WithServerTimeout(TimeSpan.FromSeconds(30)).Build();

        }

        private string GetChatUrl()
        {
            return BaseAddress;
        }

        //Connect 
        public async Task<List<MessagesFromTeacher>> StudentConnect(string studentId)
        {
            try
            {
                await hubConnection.StartAsync();
                List<MessagesFromTeacher> list = await hubConnection.InvokeAsync<List<MessagesFromTeacher>>("OnStudentConnect", studentId);
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<MessagesFromStudent>> TeacherConnect(string teacherId)
        {
            try
            {
                await hubConnection.StartAsync();
                List<MessagesFromStudent> list = await hubConnection.InvokeAsync<List<MessagesFromStudent>>("OnTeacherConnect", teacherId);
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }



        //Use this method when the chat is finished so the connection will not stay open
        public async Task Disconnect(bool isTeacher)
        {
            try
            {
                await hubConnection.InvokeAsync("OnDisconnect", isTeacher);
                await hubConnection.StopAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //This message send a message to the specified userId
        public async Task SendMessageToTeacher(string studentId, string teacherId, string message)
        {
            try
            {
                await hubConnection.InvokeAsync("SendMessageToTeacher", studentId, teacherId, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public async Task SendMessageToStudent(string teacherId, string studentId, string message)
        {
            try
            {
                await hubConnection.InvokeAsync("SendMessageToStudent", teacherId, studentId, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //this method register a method to be called upon receiving a message from other user id
        public void RegisterToReceiveMessageFromStudent(Action<StudentDTO, ChatMessageDTO> GetMessageFromStudent)
        {
            hubConnection.On("ReceiveMessageFromStudent", GetMessageFromStudent);
        }

        public void RegisterToReceiveMessageFromTeacher(Action<TeacherDTO, ChatMessageDTO> GetMessageFromTeacher)
        {
            hubConnection.On("ReceiveMessageFromTeacher", GetMessageFromTeacher);
        }
    }

}
