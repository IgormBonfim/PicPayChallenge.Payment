using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories.Responses
{
    public class BoletoResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }    
        
        [JsonPropertyName("barcode")]
        public string Barcode { get; set; }      
        
        [JsonPropertyName("formatted_barcode")]
        public string FormattedBarcode { get; set; }        

        [JsonPropertyName("due_date")]
        public DateTime DueDate { get; set; }

        [JsonPropertyName("instruction_lines")]
        public InstructionLinesResponse InstructionLines { get; set; }

        [JsonPropertyName("holder")]
        public BoletoHolderResponse Holder { get; set; }
    }
}