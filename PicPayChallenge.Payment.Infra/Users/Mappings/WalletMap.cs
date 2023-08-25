using FluentNHibernate.Mapping;
using PicPayChallenge.Payment.Domain.Users.Entities;

namespace PicPayChallenge.Payment.Infra.Users.Mappings
{
    public class WalletMap : ClassMap<Wallet>
    {
        public WalletMap()
        {
            Table("Wallet");
            Id(x => x.Id).Column("WalletId").GeneratedBy.Assigned();
            Map(x => x.Balance).Column("Balance");
        }
    }
}