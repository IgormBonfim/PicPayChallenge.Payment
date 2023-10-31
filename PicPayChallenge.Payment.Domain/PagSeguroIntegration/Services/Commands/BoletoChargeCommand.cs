namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Services.Commands
{
    public class BoletoChargeCommand
    {
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public BoletoHolderCommand Holder { get; set; }
        public InstructionLinesCommand InstructionLines { get; set; }
    }
}
