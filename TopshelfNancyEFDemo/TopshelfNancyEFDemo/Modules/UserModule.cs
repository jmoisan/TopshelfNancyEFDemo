using System.Web.Script.Serialization;
using Nancy;
using Serilog;
using DAL;
using Nancy.ModelBinding;

namespace TopshelfNancyEFDemo
{
    public class UserModule : NancyModule
    {
        public UserModule() : base("/user")
        {
            Get["/list", true] = async (parameters, cancellationToken) =>
            {
                Log.Information("Request: " + this.Context.Request.Url);

                var users = await UserService.ListUsers();
                var jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(users);

                var response = (Response)json;
                response.ContentType = "application/json";
                return response;
            };

            Get["/{id}", true] = async (parameters, cancellationToken) =>
            {
                Log.Information("Request: " + this.Context.Request.Url);

                var user = await UserService.GetUser(parameters.id);
                var jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(user);

                var response = (Response)json;
                response.ContentType = "application/json";
                return response;
            };

            Delete["/delete/{id}", true] = async (parameters, cancellationToken) =>
            {
                Log.Information("Request: " + this.Context.Request.Url);
                await UserService.DeleteUser(parameters.id);

                return new Response() { StatusCode = HttpStatusCode.OK };
            };

            Post["/add", true] = async (parameters, cancellationToken) =>
            {
                Log.Information("Request: " + this.Context.Request.Url);

                User user = this.Bind();
                await UserService.AddUser(user);

                return new Response() { StatusCode = HttpStatusCode.OK };
            };
        }
    }
}
