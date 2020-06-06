using System;
using System.Collections.Generic;

namespace OIDt.Controllers
{
    [Serializable]
    public class LoadData
    {
        public string udid;
        public string date;
        public int event_id;
        public Dictionary<string, string> parameters;
    }
}