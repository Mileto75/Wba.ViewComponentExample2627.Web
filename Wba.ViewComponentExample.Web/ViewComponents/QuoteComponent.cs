using Microsoft.AspNetCore.Mvc;

namespace Wba.ViewComponentExample.Web.ViewComponents
{
    public class QuoteComponent : ViewComponent
    {
        private readonly Uri _quoteUri;

        public QuoteComponent()
        {
            _quoteUri = new Uri("https://api.chucknorris.io/jokes/random");
        }
    }
}
