namespace Kumanofes2017.Services
{
    public interface IToast
    {
        void Show(string message, bool isLong = false);
    }
}
