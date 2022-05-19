using System;

namespace Proyecto1.Models.ViewModels //Changed namespace - Sábado 14
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
