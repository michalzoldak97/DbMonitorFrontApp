using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace D1
{
    [Serializable]
    public class LoginResponse
    {
        public string status;
        public string token;
        public LoginResponseData data;
        public LoginResponse() { }
        public LoginResponse(string status, string token, LoginResponseData data)
        {
            this.status = status;
            this.token = token;
            this.data = data;
        }
    }

    [Serializable]
    public class LoginResponseData
    {
        public string user;
        public LoginResponseData() { }
        public LoginResponseData(string usr)
        {
            this.user = usr;
        }
    }
}
