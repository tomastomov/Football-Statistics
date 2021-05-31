using FootballStatistics.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatistics.Data.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasMany(m => m.MatchEvents)
                .WithOne(me => me.Match)
                .HasForeignKey(m => m.MatchId);

            builder.HasMany(m => m.PlayerStatistics)
                .WithOne(ps => ps.Match)
                .HasForeignKey(m => m.MatchId);
        }
    }
}
