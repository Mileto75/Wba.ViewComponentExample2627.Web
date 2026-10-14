using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Wba.ViewComponentExample.Web.ViewModels;

namespace Wba.ViewComponentExample.Web.ViewComponents
{
    [ViewComponent(Name = "QuoteComponent")]
    public class QuoteComponent : ViewComponent
    {
        private readonly Uri _quoteUri;
        private QuoteComponentViewModel quoteComponentViewModel;
        public QuoteComponent()
        {
            _quoteUri = new Uri("https://api.chucknorris.io/jokes/random");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //get the quote from the api
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetAsync(_quoteUri.AbsoluteUri);
            if(result.IsSuccessStatusCode)
            {
                //read the content as string
                var content = await result.Content.ReadAsStringAsync();
                //deserialize to viewmodel
                quoteComponentViewModel =
                    JsonSerializer.Deserialize<QuoteComponentViewModel>(content); 
            }
            //pass to the view
            return View(quoteComponentViewModel);
        }
    }
}
