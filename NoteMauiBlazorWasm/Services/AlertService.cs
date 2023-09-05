using NoteMauiBlazorWasm.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteMauiBlazorWasm.Services
{
    public class AlertService : IAlertService
    {
        private readonly Page _page;
        public AlertService()
        {
            _page = App.Current.MainPage;
        }
        public async Task AlertAsync(string message, string title = "Alert", string buttonName = "Ok")
        {
            await _page.DisplayAlert(title,message, buttonName);
        }

        public Task<string> PromptAsync(string message, string title)
        {
            return _page.DisplayPromptAsync(title, message, "Ok");
        }
    }
}
