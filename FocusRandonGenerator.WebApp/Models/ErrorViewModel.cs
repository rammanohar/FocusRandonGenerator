
namespace FocusRandonGenerator.WebApp.Models
{
    /// <summary>
    /// ErrorViewModel
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
