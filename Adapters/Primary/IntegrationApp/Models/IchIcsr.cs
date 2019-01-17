using System.Collections.Generic;

namespace Umc.VigiFlow.Adapters.Primary.IntegrationApp.Models
{
    public class IchIcsr
    {
        public string MessageNumb { get; set; }
        public List<SafetyReport> SafetyReports { get; set; }
    }
}