using System;

namespace Proyecto1.Models.ViewModels //Changed namespace - S�bado 14
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
