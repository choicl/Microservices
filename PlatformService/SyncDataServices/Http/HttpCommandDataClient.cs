﻿using PlatformService.DTOs;
using System.Text;
using System.Text.Json;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendPlatformToCommand(PlatformReadDto platform)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(platform),
                Encoding.UTF8,
                "applixation/json");

            var response = await _httpClient.PostAsync($"{_configuration["CommandsService"]}", httpContent);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("- - > Sync POST to CommandsService is OK");
            }
            else 
            {
                Console.WriteLine("- - > Sync POST to CommandsService is NOT OK");
            }
        }
    }
}
