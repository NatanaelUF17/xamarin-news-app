using System;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using News.Models;
using News.Services;
using News.Services.Helpers;
using News.ViewModels.Helpers;
using Xamarin.Forms;

namespace News.ViewModels
{
    public class HeadlinesViewModel : ViewModel
    {
        private readonly NewsService _newsService;

        public NewsResult CurrentNews { get; set; }

        public HeadlinesViewModel(NewsService newsService)
        {
            _newsService = newsService;
        }

        public ICommand NewSelected => new Command(async (selectedNew) =>
        {
            var selectedArticle = selectedNew as Article;
            var url = HttpUtility.UrlEncode(selectedArticle.Url);
        });

        public async Task Initialize(string scope)
        {
            var resolvedScope = scope.ToLower() switch
            {
                "local" => NewsScope.Local,
                "global" => NewsScope.Global,
                "headlines" => NewsScope.Headlines,
                _ => NewsScope.Headlines
            };

            await Initialize(resolvedScope);
        }

        public async Task Initialize(NewsScope scope)
        {
            CurrentNews = await _newsService.GetNews(scope);
        }
    }
}
