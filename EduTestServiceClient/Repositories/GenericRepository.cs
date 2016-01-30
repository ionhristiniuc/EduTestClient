using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EduTestServiceClient.DTO;
using EduTestServiceClient.Utils;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;

namespace EduTestServiceClient.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : new()
    {
        public string ServiceUrl { get; set; }      // ex: http://192.168.56.22/app_dev.php
        public string BasePath { get; set; }        // ex: users       
        protected IRestClient Client { get; }

        public GenericRepository(string serviceUrl, string basePath, IAuthenticationService authenticator)
        {
            ServiceUrl = serviceUrl;
            BasePath = basePath;            
            Client = new RestClient(ServiceUrl)
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(
                    authenticator.AuthResponse.access_token, "Bearer")
            };
        }

        public T Get(int id)
        {            
            var request = new RestRequest($"{BasePath}/{id}", Method.GET);
            var response = Client.Execute<T>(request);
            if (response.ErrorException != null)
                throw response.ErrorException;
            return response.Data;
        }

        public Items<T> GetList(int page = 0, int perPage = 10)
        {
            var request = new RestRequest($"{BasePath}", Method.GET);
            request.AddQueryParameter("page", page.ToString());
            request.AddQueryParameter("per_page", perPage.ToString());
            var response = Client.Execute<Items<T>>(request);
            if (response.ErrorException != null)
                throw response.ErrorException;
            return response.Data;
        }

        public int? Add(T entity)
        {            
            var request = new RestRequest($"{BasePath}", Method.POST);
            request.AddObject(entity, GetIncludedProperties(entity));
            var response = Client.Execute(request);
            if (response.ErrorException != null)
                throw response.ErrorException;

            JsonDeserializer deserializer = new JsonDeserializer();
            var postResp = deserializer.Deserialize<PostResponse>(response);
            return postResp.resource_id;
        }

        public void Update(T entity, int id)
        {
            var request = new RestRequest($"{BasePath}/{id}", Method.PATCH);
            request.AddObject(entity, GetIncludedProperties(entity));
            var response = Client.Patch(request);
            if (response.ErrorException != null)
                throw response.ErrorException;
        }

        public bool Remove(int id)
        {
            var request = new RestRequest($"{BasePath}/{id}", Method.DELETE);
            var response = Client.Delete(request);
            if (response.ErrorException != null)
                throw response.ErrorException;

            return true;
        }        

        protected string[] GetIncludedProperties(T entity)
        {
            var type = entity.GetType();
            var properties = type.GetProperties();
            return properties
                .Where(p => p.GetCustomAttribute(typeof(IgnoreAttribute)) == null
                    || ((IgnoreAttribute) p.GetCustomAttribute(typeof(IgnoreAttribute))).Ignore == false)                    
                .Select(p => p.Name)
                .ToArray();
        } 
    }
}