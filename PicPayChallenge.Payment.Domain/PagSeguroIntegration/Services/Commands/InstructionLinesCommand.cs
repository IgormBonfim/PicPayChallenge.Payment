using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Services.Commands
{
    public class InstructionLinesCommand
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
    }
}