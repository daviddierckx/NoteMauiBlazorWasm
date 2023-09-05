using Microsoft.AspNetCore.Components;
using NoteMauiBlazorWasm.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteMauiBlazorWasm.Common.Services
{
    public class AuthServices
    {
        private readonly IAlertService _alertService;
        private readonly IStorageService _storageService;
        public AuthServices(IAlertService alertService, IStorageService storageService) {
            _alertService = alertService;
            _storageService = storageService;
        }
        public async Task<string?> GetUsername()
        {
            var name = await _storageService.GetAsync(AppConstants.StorageKeys.Username);
            if (string.IsNullOrWhiteSpace(name))
            {
                //Continue the app


                int maxRetry = 3;
                do
                {
                    name = await _alertService.PromptAsync("Welcome", "Please enter your name");
                }
                while (string.IsNullOrWhiteSpace(name) && (--maxRetry) > 0);


                if (string.IsNullOrWhiteSpace(name))
                {
                    await _alertService.AlertAsync("Error", "Your name is required to continue with the app", "OK");
                    return null;
                }
                //We have username here
                //Save it to the storage
                await _storageService.SaveAsync(AppConstants.StorageKeys.Username, name);
            }
            //Continue with the app
            return name;
        }
    }
}
