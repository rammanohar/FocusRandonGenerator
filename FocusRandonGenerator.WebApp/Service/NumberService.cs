namespace FocusRandonGenerator.WebApp.Service
{
    using FocusRandonGenerator.WebApp.Models;
    using FocusRandonGenerator.WebApp.Service.Interface;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    public class NumberService : INumberService
    {
        IConfiguration Configuration;
        public NumberService(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        private HttpResponseMessage HttpGet(string url)
        {
            using (var client = new HttpClient())
            {
                string baseURl = Configuration["ApiBaseUrl"];
                

                client.BaseAddress = new Uri(baseURl);

                //HTTP GET
                var responseTask = client.GetAsync(url);
                responseTask.Wait();

                var result = responseTask.Result;

                return result;
            }

        }
        public GeneratedRandonNumber GetNumbersByColor()
        {
            string address = $"RandomGenerator/NumbersByColor";
            var result = new GeneratedRandonNumber();
            
            var response = HttpGet(address);
            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<GeneratedRandonNumber>();
                readTask.Wait();

                result = readTask.Result;
            }
            result.NoofRandomnumbers = result.RandonNumbers.Count();

            return result;
        }

        public GeneratedRandonNumber GetCustomNumbersByColor(int id)
        {
            string address = $"RandomGenerator/CustomNumbersByColor?id={id}";
            var result = new GeneratedRandonNumber();
              var response =  HttpGet(address);
             if (response.IsSuccessStatusCode)
                {
                var readTask = response.Content.ReadAsAsync<GeneratedRandonNumber>();
                readTask.Wait();

                 result = readTask.Result;
                }
            result.NoofRandomnumbers = result.RandonNumbers.Count();
            return result;
        }

        public List<GeneratedRandonNumber> GetAllCustomNumbers()
        {
            string address = $"RandomGenerator/GetAllCustomNumbers";
            var result = new List<GeneratedRandonNumber>();
            var response = HttpGet(address);
            if (response.IsSuccessStatusCode)
            {
                var readTask = response.Content.ReadAsAsync<List<GeneratedRandonNumber>>();
                readTask.Wait();

                result = readTask.Result;
            }

            foreach (var r in result)
            {
                r.NoofRandomnumbers = r.RandonNumbers.Count();
            }

            return result;
        }
       


    }
}
