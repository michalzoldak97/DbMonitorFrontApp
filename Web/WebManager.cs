using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace D1
{
    public static class WebManager
    {
        public static string baseUrl { get; private set; }
        public static string logInRoute { get; private set; }
        public static void Launch()
        {
            baseUrl = "http://192.168.1.15:80";
            logInRoute = "/api/v1/user/login";
        }
    }
}
