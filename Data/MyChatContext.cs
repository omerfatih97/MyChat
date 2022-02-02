using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyChat.Data
{
    public partial class MyChatContext : DbContext
    {
        public MyChatContext()
        {
        }

        public MyChatContext(DbContextOptions<MyChatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<MessageLog> MessageLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=OMER-LENOVO;Database=MyChat;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Channel>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChannelName).HasMaxLength(255);
            });

            modelBuilder.Entity<MessageLog>(entity =>
            {
                entity.HasKey(e => e.MessageUn);

                entity.Property(e => e.MessageUn)
                    .ValueGeneratedNever()
                    .HasColumnName("MessageUN");

                entity.Property(e => e.ChannelId).HasColumnName("ChannelID");

                entity.Property(e => e.MessageText).HasMaxLength(999);

                entity.Property(e => e.Optime).HasColumnType("datetime");

                entity.Property(e => e.UserColor).HasMaxLength(10);

                entity.Property(e => e.Username).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
