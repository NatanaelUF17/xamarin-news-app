using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace News.ViewModels.Helpers
{
    public interface INavigate
    {
        Task NavigateTo(string route);
        Task PushModal(Page page);
        Task PopModal();
    }
}
