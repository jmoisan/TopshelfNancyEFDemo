using System;
using System.Web.Script.Serialization;
using Nancy;
using Serilog;

namespace TopshelfNancyEFDemo
{
    public class UtilModule : NancyModule
    {
        public UtilModule() : base()
        {
            Get["/time"] = parameters =>
            {
                Log.Information("Request: " + this.Context.Request.Url);

                var theTime = new time()
                {
                    UtcMilliseconds = DateTime.UtcNow.Millisecond.ToString(),
                    Iso8601FullDate = DateTime.Now.ToString("yyyyMMddTHHmmssZ")
                };

                var jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(theTime);

                var response = (Response)json;
                response.ContentType = "application/json";
                return response;
            };

            Get["/system"] = parameters =>
            {
                Log.Information("Request: " + this.Context.Request.Url);

                var theSystem = new system()
                {
                    MachineName = Environment.MachineName,
                    ProcessorCount = Environment.ProcessorCount,
                    OSVersion = Environment.OSVersion.ToString()
                };

                var jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(theSystem);

                var response = (Response)json;
                response.ContentType = "application/json";
                return response;
            };

        }
    }

    public class time
    {
        public string UtcMilliseconds;
        public string Iso8601FullDate;
    }

    public class system
    {
        public string MachineName;
        public int ProcessorCount;
        public string OSVersion;
    }
}
