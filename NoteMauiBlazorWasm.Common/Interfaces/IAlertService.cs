using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteMauiBlazorWasm.Common.Interfaces
{
    public interface IAlertService
    {
        Task<string?> PromptAsync(string message, string title);
        Task AlertAsync(string message, string title = "Alert", string buttonName = "Ok");
    }
}
