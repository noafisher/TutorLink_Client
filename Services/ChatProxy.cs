using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.SignalR.Client;

namespace TutorLinkClient.Services
{
    public class ChatProxy
    {

        #region without tunnel
        /*
        //Define the serevr IP address! (should be realIP address if you are using a device that is not running on the same machine as the server)
        private static string serverIP = "localhost";
        private readonly HubConnection hubConnection;
        private string baseUrl;
        public static string BaseAddress = (DeviceInfo.Platform == DevicePlatform.Android &&
            DeviceInfo.DeviceType == DeviceType.Virtual) ? "http://10.0.2.2:5110/chatHub/" : $"http://{serverIP}:5110/chatHub/";
        */
        #endregion

        #region with tunnel
        //Define the serevr IP address! (should be realIP address if you are using a device that is not running on the same machine as the server)
        private static string serverIP = "8tg6qckg-5110.euw.devtunnels.ms";
        //private readonly HubConnection hubConnection;
        private string baseUrl;
        public static string BaseAddress = "https://8tg6qckg-5110.euw.devtunnels.ms/chatHub/";

        #endregion

    }
}
