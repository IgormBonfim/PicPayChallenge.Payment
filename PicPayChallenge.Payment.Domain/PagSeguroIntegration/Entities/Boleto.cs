using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities
{
    public class Boleto
    {
        [JsonPropertyName("due_date")]
        public string DueDate { get; protected set; }

        [JsonPropertyName("instruction_lines")]
        public InstructionLines InstructionLines { get; protected set; }

        [JsonPropertyName("holder")]
        public BoletoHolder Holder { get; protected set; }

        public Boleto(DateTime dueDate, InstructionLines instructionLines, BoletoHolder holder)
        {
            DueDate = dueDate.ToString("yyyy-MM-dd");
            InstructionLines = instructionLines;
            Holder = holder;
        }

    }
}