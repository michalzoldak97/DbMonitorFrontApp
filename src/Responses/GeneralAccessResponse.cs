using System.Collections;
using System.Collections.Generic;
using System;

namespace D1
{
    [Serializable]
    public class GeneralAccessResponse : APIResponse
    {

    }

    [Serializable]
    public class GeneralUserSetting : DataObject 
    {
        public string name;
        public string set_type; 
    }
}
