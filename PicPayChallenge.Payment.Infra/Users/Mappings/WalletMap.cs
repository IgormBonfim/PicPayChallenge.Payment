using FluentNHibernate.Mapping;
using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Infra.Users.Mappings
{
    public class WalletMap : ClassMap<Wallet>
    {
        public WalletMap()
        {
            Table("Wallet");
            Id(x => x.Id).Column("WalletI");
            Map(x => x.Balance).Column("Balance");
        }
    }
}