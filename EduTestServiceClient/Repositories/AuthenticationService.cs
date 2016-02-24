﻿using System;
using EduTestServiceClient.DTO;
using RestSharp;
using RestSharp.Authenticators;

namespace EduTestServiceClient.Repositories
{
    public class AuthenticationService : IAuthenticationService
    {               
        public string ServiceUrl { get; set; }
        public string AuthPath { get; set; }
        private string ClientId { get; set; }
        private string ClientSecret { get; set; }
        private IRestClient Client { get; set; }

        public AuthenticationService(string serviceUrl, string authPath, string clientId, string clientSecret)
        {
            ServiceUrl = serviceUrl;
            AuthPath = authPath;
            ClientId = clientId;
            ClientSecret = clientSecret;
            Client = new RestClient(ServiceUrl);
        }        

        public AuthenticationResponse Authenticate(string username, string password)
        {
            var request = new RestRequest($"{AuthPath}", Method.POST);
            request.AddJsonBody(new
            {
                client_id = ClientId,
                client_secret = ClientSecret,
                grant_type = "password",
                username = username,
                password = password
            });

            var restResponse = Client.Execute<AuthenticationResponse>(request);
            if (restResponse.ErrorException != null)
                throw restResponse.ErrorException;

            return restResponse.Data;            
        }

        public AuthenticationResponse Reauthenticate(AuthenticationResponse resp)
        {
            if (resp == null)
                throw new InvalidOperationException("Cannot authenticate as refresh_token is missing");

            var request = new RestRequest(AuthPath, Method.POST);
            request.AddJsonBody(new
            {
                client_id = ClientId,
                client_secret = ClientSecret,
                grant_type = "password",
                access_token = resp.access_token,
                refresh_token = resp.refresh_token
            });

            var restResponse = Client.Execute<AuthenticationResponse>(request);
            return restResponse.Data;
        }
    }
}