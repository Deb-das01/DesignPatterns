using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    // ==========================
    // Product
    // ==========================
    // This is the object that we want to build.
    public class HttpRequest
    {
        private string url;
        private Dictionary<string, string> headers;
        private string token;

        // Constructor is internal to the builder.
        public HttpRequest(RequestBuilder builder)
        {
            url = builder.Url;
            headers = builder.Headers;
            token = builder.Token;
        }

        public void DisplayRequest()
        {
            Console.WriteLine("========== HTTP Request ==========");
            Console.WriteLine($"URL    : {url}");
            Console.WriteLine($"Token  : {token}");

            Console.WriteLine("\nHeaders:");

            if (headers != null)
            {
                foreach (var item in headers)
                {
                    Console.WriteLine($"{item.Key} : {item.Value}");
                }
            }

            Console.WriteLine("==================================");
        }
    }

    // ==========================
    // Builder
    // ==========================
    // Responsible for constructing the HttpRequest object step-by-step.
    public class RequestBuilder
    {
        // Properties accessed by HttpRequest constructor.
        public string Url { get; private set; }
        public Dictionary<string, string> Headers { get; private set; }
        public string Token { get; private set; }

        // Required field
        public RequestBuilder(string url)
        {
            Url = url;
            Headers = new Dictionary<string, string>();
        }

        // Optional field
        public RequestBuilder SetHeaders(Dictionary<string, string> headers)
        {
            Headers = headers;
            return this;        // Enables method chaining
        }

        // Optional field
        public RequestBuilder SetToken(string token)
        {
            Token = token;
            return this;
        }

        // Final step - creates the Product
        public HttpRequest Build()
        {
            return new HttpRequest(this);
        }
    }

    // ==========================
    // Director
    // ==========================
    // Contains predefined ways of building objects.
    public class Director
    {
        // Builds a GET request
        public HttpRequest GetRequest(
            string url,
            Dictionary<string, string> headers,
            string token)
        {
            return new RequestBuilder(url)
                    .SetHeaders(headers)
                    .SetToken(token)
                    .Build();
        }

        // Builds a PUT request
        public HttpRequest PutRequest(
            string url,
            Dictionary<string, string> headers)
        {
            return new RequestBuilder(url)
                    .SetHeaders(headers)
                    .Build();
        }
    }

    // ==========================
    // Client
    // ==========================
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Content-Type", "application/json" },
                { "Accept", "application/json" }
            };

            string token = "ABC123XYZ";

            Director director = new Director();

            HttpRequest request = director.GetRequest(
                "https://www.example.com/api",
                headers,
                token);

            request.DisplayRequest();
        }
    }
}