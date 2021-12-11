using System.Collections;
using System.Collections.Generic;
using System;

namespace D1
{
    //TODO read data to object, custom deserialize class required
    [Serializable]
    public class APIResponse
    {
        public string message;
        public Response response;
    }

    [Serializable]
    public class Response
    {
        public Data data;
    }

    [Serializable]
    public class Data
    {
        public DataObject[] dataObjects;
    }

    [Serializable]
    public class DataObject
    {

    }
}
