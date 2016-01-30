using System;
using EduTestServiceClient.DTO;
using RestSharp;
using RestSharp.Authenticators;

namespace EduTestServiceClient.Repositories
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationResponse AuthResponse { get; set; }
        private IAuthenticator Authenticator =>
            AuthResponse != null             
            ? new OAuth2AuthorizationRequestHeaderAuthenticator(AuthResponse.access_token, "Bearer")
            : null; 

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

        public bool Authenticate(string username, string password)
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

            AuthResponse = restResponse.Data;
            return int.Parse(AuthResponse.expires_in) > 0;
        }

        public bool Reauthenticate()
        {
            if (AuthResponse == null)
                throw new InvalidOperationException("Cannot authenticate as refresh_token is missing");

            var request = new RestRequest(AuthPath, Method.POST);
            request.AddJsonBody(new
            {
                client_id = ClientId,
                client_secret = ClientSecret,
                grant_type = "password",
                access_token = AuthResponse.access_token,
                refresh_token = AuthResponse.refresh_token
            });

            return true;
        }
    }
}