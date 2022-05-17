using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TheTjerrs.Models
{
    public partial class PIPOSTEST_Context : DbContext
    {
        public PIPOSTEST_Context()
        {
        }

        public PIPOSTEST_Context(DbContextOptions<PIPOSTEST_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AnketatEpoll> AnketatEpolls { get; set; } = null!;
        public virtual DbSet<AnketatEpollKandidatet> AnketatEpollKandidatets { get; set; } = null!;
        public virtual DbSet<AnketatEpollPartite> AnketatEpollPartites { get; set; } = null!;
        public virtual DbSet<AnketatSs> AnketatSses { get; set; } = null!;
        public virtual DbSet<ExitPoll> ExitPolls { get; set; } = null!;
        public virtual DbSet<Kandidatet> Kandidatets { get; set; } = null!;
        public virtual DbSet<Partite> Partites { get; set; } = null!;
        public virtual DbSet<Pergjigjium> Pergjigjia { get; set; } = null!;
        public virtual DbSet<Pyetja> Pyetjas { get; set; } = null!;
        public virtual DbSet<PytetjePergjigjieAnketum> PytetjePergjigjieAnketa { get; set; } = null!;
        public virtual DbSet<Qytetet> Qytetets { get; set; } = null!;
        public virtual DbSet<RezultatiEp> RezultatiEps { get; set; } = null!;
        public virtual DbSet<RezultatiSs> RezultatiSses { get; set; } = null!;
        public virtual DbSet<Shtetet> Shtetets { get; set; } = null!;
        public virtual DbSet<ShtetetExitPoll> ShtetetExitPolls { get; set; } = null!;
        public virtual DbSet<ShtetetSimpleSurvey> ShtetetSimpleSurveys { get; set; } = null!;
        public virtual DbSet<SimpleSurvey> SimpleSurveys { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UsersExitPoll> UsersExitPolls { get; set; } = null!;
        public virtual DbSet<UsersSimpleSurvey> UsersSimpleSurveys { get; set; } = null!;
        public virtual DbSet<Vendvotimi> Vendvotimis { get; set; } = null!;
        public virtual DbSet<Zona> Zonas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-FCN6NIP;Database=PIPOSTEST_;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnketatEpoll>(entity =>
            {
                entity.HasKey(e => e.AnketaEpId)
                    .HasName("PK__Anketat___E043E7E3B9AE9E6E");

                entity.ToTable("Anketat_EPoll");

                entity.Property(e => e.AnketaEpId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AnketaEP_ID");

                entity.Property(e => e.Gjinia)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Mosha)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.QytetiId).HasColumnName("QytetiID");

                entity.Property(e => e.ShtetiId).HasColumnName("ShtetiID");

                entity.Property(e => e.VendvotimiId).HasColumnName("VendvotimiID");

                entity.Property(e => e.ZonaId).HasColumnName("ZonaID");

                entity.HasOne(d => d.Qyteti)
                    .WithMany(p => p.AnketatEpolls)
                    .HasForeignKey(d => d.QytetiId)
                    .HasConstraintName("FK__Anketat_E__Qytet__45F365D3");

                entity.HasOne(d => d.Shteti)
                    .WithMany(p => p.AnketatEpolls)
                    .HasForeignKey(d => d.ShtetiId)
                    .HasConstraintName("FK__Anketat_E__Shtet__46E78A0C");

                entity.HasOne(d => d.Vendvotimi)
                    .WithMany(p => p.AnketatEpolls)
                    .HasForeignKey(d => d.VendvotimiId)
                    .HasConstraintName("FK__Anketat_E__Vendv__47DBAE45");

                entity.HasOne(d => d.Zona)
                    .WithMany(p => p.AnketatEpolls)
                    .HasForeignKey(d => d.ZonaId)
                    .HasConstraintName("FK__Anketat_E__ZonaI__48CFD27E");
            });

            modelBuilder.Entity<AnketatEpollKandidatet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Anketat_EPOll_Kandidatet");

                entity.Property(e => e.AnketaEpId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AnketaEP_ID");

                entity.Property(e => e.NumriKandidatit).HasColumnName("Numri_Kandidatit");

                entity.HasOne(d => d.AnketaEp)
                    .WithMany()
                    .HasForeignKey(d => d.AnketaEpId)
                    .HasConstraintName("FK__Anketat_E__Anket__49C3F6B7");

                entity.HasOne(d => d.NumriKandidatitNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.NumriKandidatit)
                    .HasConstraintName("FK__Anketat_E__Numri__4AB81AF0");
            });

            modelBuilder.Entity<AnketatEpollPartite>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Anketat_EPOll_Partite");

                entity.Property(e => e.AnketaEpId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AnketaEP_ID");

                entity.Property(e => e.PartiId).HasColumnName("PartiID");

                entity.HasOne(d => d.AnketaEp)
                    .WithMany()
                    .HasForeignKey(d => d.AnketaEpId)
                    .HasConstraintName("FK__Anketat_E__Anket__4BAC3F29");

                entity.HasOne(d => d.Parti)
                    .WithMany()
                    .HasForeignKey(d => d.PartiId)
                    .HasConstraintName("FK__Anketat_E__Parti__4CA06362");
            });

            modelBuilder.Entity<AnketatSs>(entity =>
            {
                entity.HasKey(e => e.AnketaSsId)
                    .HasName("PK__Anketat___21AD9B619466502E");

                entity.ToTable("Anketat_SS");

                entity.Property(e => e.AnketaSsId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AnketaSS_ID");

                entity.Property(e => e.Gjinia)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Mosha)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.QytetiId).HasColumnName("QytetiID");

                entity.Property(e => e.ShtetiId).HasColumnName("ShtetiID");

                entity.Property(e => e.ZonaId).HasColumnName("ZonaID");

                entity.HasOne(d => d.Qyteti)
                    .WithMany(p => p.AnketatSses)
                    .HasForeignKey(d => d.QytetiId)
                    .HasConstraintName("FK__Anketat_S__Qytet__4D94879B");

                entity.HasOne(d => d.Shteti)
                    .WithMany(p => p.AnketatSses)
                    .HasForeignKey(d => d.ShtetiId)
                    .HasConstraintName("FK__Anketat_S__Shtet__4E88ABD4");

                entity.HasOne(d => d.Zona)
                    .WithMany(p => p.AnketatSses)
                    .HasForeignKey(d => d.ZonaId)
                    .HasConstraintName("FK__Anketat_S__ZonaI__4F7CD00D");
            });

            modelBuilder.Entity<ExitPoll>(entity =>
            {
                entity.HasKey(e => e.EpollId)
                    .HasName("PK__Exit_Pol__B17AF8AF30441031");

                entity.ToTable("Exit_Poll");

                entity.Property(e => e.EpollId)
                    .ValueGeneratedNever()
                    .HasColumnName("EPollID");

                entity.Property(e => e.EmriEp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Emri_EP");
            });

            modelBuilder.Entity<Kandidatet>(entity =>
            {
                entity.HasKey(e => e.NumriKandidatit)
                    .HasName("PK__Kandidat__3A5066404227783D");

                entity.ToTable("Kandidatet");

                entity.Property(e => e.NumriKandidatit)
                    .ValueGeneratedNever()
                    .HasColumnName("Numri_Kandidatit");

                entity.Property(e => e.Emri)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mbirmeri)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PartiId).HasColumnName("PartiID");

                entity.HasOne(d => d.Parti)
                    .WithMany(p => p.Kandidatets)
                    .HasForeignKey(d => d.PartiId)
                    .HasConstraintName("FK__Kandidate__Parti__5070F446");
            });

            modelBuilder.Entity<Partite>(entity =>
            {
                entity.HasKey(e => e.PartiId)
                    .HasName("PK__Partite__1A6F8D0ACD9F9716");

                entity.ToTable("Partite");

                entity.Property(e => e.PartiId)
                    .ValueGeneratedNever()
                    .HasColumnName("PartiID");

                entity.Property(e => e.EmriPartise)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Emri_Partise");

                entity.Property(e => e.EpollId).HasColumnName("EPollID");

                entity.HasOne(d => d.Epoll)
                    .WithMany(p => p.Partites)
                    .HasForeignKey(d => d.EpollId)
                    .HasConstraintName("FK__Partite__EPollID__5165187F");
            });

            modelBuilder.Entity<Pergjigjium>(entity =>
            {
                entity.HasKey(e => e.PergjigjiaId)
                    .HasName("PK__Pergjigj__01221D88AFA9DC3B");

                entity.Property(e => e.PergjigjiaId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PergjigjiaID");

                entity.Property(e => e.Pergjigja)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pyetja>(entity =>
            {
                entity.ToTable("Pyetja");

                entity.Property(e => e.PyetjaId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PyetjaID");

                entity.Property(e => e.Pytja)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PytetjePergjigjieAnketum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Pytetje_Pergjigjie_Anketa");

                entity.Property(e => e.AnketaSsId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AnketaSS_ID");

                entity.Property(e => e.PergjigjiaId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PergjigjiaID");

                entity.Property(e => e.PyetjaId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PyetjaID");

                entity.HasOne(d => d.AnketaSs)
                    .WithMany()
                    .HasForeignKey(d => d.AnketaSsId)
                    .HasConstraintName("FK__Pytetje_P__Anket__52593CB8");

                entity.HasOne(d => d.Pergjigjia)
                    .WithMany()
                    .HasForeignKey(d => d.PergjigjiaId)
                    .HasConstraintName("FK__Pytetje_P__Pergj__534D60F1");

                entity.HasOne(d => d.Pyetja)
                    .WithMany()
                    .HasForeignKey(d => d.PyetjaId)
                    .HasConstraintName("FK__Pytetje_P__Pyetj__5441852A");
            });

            modelBuilder.Entity<Qytetet>(entity =>
            {
                entity.HasKey(e => e.QytetiId)
                    .HasName("PK__Qytetet__829FE6B70310E92D");

                entity.ToTable("Qytetet");

                entity.Property(e => e.QytetiId)
                    .ValueGeneratedNever()
                    .HasColumnName("QytetiID");

                entity.Property(e => e.EmriQytetit)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Emri_Qytetit");

                entity.Property(e => e.NumriBanorve).HasColumnName("Numri_Banorve");

                entity.Property(e => e.ShtetiId).HasColumnName("ShtetiID");

                entity.HasOne(d => d.Shteti)
                    .WithMany(p => p.Qytetets)
                    .HasForeignKey(d => d.ShtetiId)
                    .HasConstraintName("FK__Qytetet__ShtetiI__5535A963");
            });

            modelBuilder.Entity<RezultatiEp>(entity =>
            {
                entity.HasKey(e => e.RezId)
                    .HasName("PK__Rezultat__D0E762F123C74E97");

                entity.ToTable("Rezultati_Ep");

                entity.Property(e => e.RezId)
                    .ValueGeneratedNever()
                    .HasColumnName("RezID");

                entity.Property(e => e.EpollId).HasColumnName("EPollID");

                entity.Property(e => e.RezultatiKandidate).HasColumnName("Rezultati_Kandidate");

                entity.Property(e => e.RezultatiParti).HasColumnName("Rezultati_Parti");

                entity.HasOne(d => d.Epoll)
                    .WithMany(p => p.RezultatiEps)
                    .HasForeignKey(d => d.EpollId)
                    .HasConstraintName("FK__Rezultati__EPoll__5629CD9C");
            });

            modelBuilder.Entity<RezultatiSs>(entity =>
            {
                entity.HasKey(e => e.RezId)
                    .HasName("PK__Rezultat__D0E762F14ED8367B");

                entity.ToTable("Rezultati_SS");

                entity.Property(e => e.RezId)
                    .ValueGeneratedNever()
                    .HasColumnName("RezID");

                entity.Property(e => e.Rezultati)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SsurveyId).HasColumnName("SSurveyID");

                entity.HasOne(d => d.Ssurvey)
                    .WithMany(p => p.RezultatiSses)
                    .HasForeignKey(d => d.SsurveyId)
                    .HasConstraintName("FK__Rezultati__SSurv__571DF1D5");
            });

            modelBuilder.Entity<Shtetet>(entity =>
            {
                entity.HasKey(e => e.ShtetiId)
                    .HasName("PK__Shtetet__935A3FD1CC7A1A98");

                entity.ToTable("Shtetet");

                entity.Property(e => e.ShtetiId)
                    .ValueGeneratedNever()
                    .HasColumnName("ShtetiID");

                entity.Property(e => e.EmriShtetit)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Emri_Shtetit");

                entity.Property(e => e.NumriBanorve).HasColumnName("Numri_Banorve");
            });

            modelBuilder.Entity<ShtetetExitPoll>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Shtetet_ExitPoll");

                entity.Property(e => e.EpollId).HasColumnName("EPollID");

                entity.Property(e => e.ShtetiId).HasColumnName("ShtetiID");

                entity.HasOne(d => d.Epoll)
                    .WithMany()
                    .HasForeignKey(d => d.EpollId)
                    .HasConstraintName("FK__Shtetet_E__EPoll__5812160E");

                entity.HasOne(d => d.Shteti)
                    .WithMany()
                    .HasForeignKey(d => d.ShtetiId)
                    .HasConstraintName("FK__Shtetet_E__Shtet__59063A47");
            });

            modelBuilder.Entity<ShtetetSimpleSurvey>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Shtetet_SimpleSurvey");

                entity.Property(e => e.ShtetiId).HasColumnName("ShtetiID");

                entity.Property(e => e.SsurveyId).HasColumnName("SSurveyID");

                entity.HasOne(d => d.Shteti)
                    .WithMany()
                    .HasForeignKey(d => d.ShtetiId)
                    .HasConstraintName("FK__Shtetet_S__Shtet__59FA5E80");

                entity.HasOne(d => d.Ssurvey)
                    .WithMany()
                    .HasForeignKey(d => d.SsurveyId)
                    .HasConstraintName("FK__Shtetet_S__SSurv__5AEE82B9");
            });

            modelBuilder.Entity<SimpleSurvey>(entity =>
            {
                entity.HasKey(e => e.SsurveyId)
                    .HasName("PK__SIMPLE_S__60FFA198629050C1");

                entity.ToTable("SIMPLE_SURVEY");

                entity.Property(e => e.SsurveyId)
                    .ValueGeneratedNever()
                    .HasColumnName("SSurveyID");

                entity.Property(e => e.EmriSs)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("Emri_SS");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsersId)
                    .HasName("PK__Users__A349B0420D4340B5");

                entity.Property(e => e.UsersId)
                    .ValueGeneratedNever()
                    .HasColumnName("UsersID");

                entity.Property(e => e.Emri)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mbiemri)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NrTel)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Nr_Tel");

                entity.Property(e => e.Passwordi)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Roli)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersExitPoll>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Users_ExitPoll");

                entity.Property(e => e.EpollId).HasColumnName("EPollID");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.HasOne(d => d.Epoll)
                    .WithMany()
                    .HasForeignKey(d => d.EpollId)
                    .HasConstraintName("FK__Users_Exi__EPoll__5BE2A6F2");

                entity.HasOne(d => d.Users)
                    .WithMany()
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__Users_Exi__Users__5CD6CB2B");
            });

            modelBuilder.Entity<UsersSimpleSurvey>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Users_SimpleSurvey");

                entity.Property(e => e.SsurveyId).HasColumnName("SSurveyID");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.HasOne(d => d.Ssurvey)
                    .WithMany()
                    .HasForeignKey(d => d.SsurveyId)
                    .HasConstraintName("FK__Users_Sim__SSurv__5DCAEF64");

                entity.HasOne(d => d.Users)
                    .WithMany()
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__Users_Sim__Users__5EBF139D");
            });

            modelBuilder.Entity<Vendvotimi>(entity =>
            {
                entity.HasKey(e => e.NumriVendvotimit)
                    .HasName("PK__Vendvoti__7C8823195546337B");

                entity.ToTable("Vendvotimi");

                entity.Property(e => e.NumriVendvotimit)
                    .ValueGeneratedNever()
                    .HasColumnName("Numri_Vendvotimit");

                entity.Property(e => e.EmriShkolles)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Emri_Shkolles");

                entity.Property(e => e.QytetiId).HasColumnName("QytetiID");

                entity.HasOne(d => d.Qyteti)
                    .WithMany(p => p.Vendvotimis)
                    .HasForeignKey(d => d.QytetiId)
                    .HasConstraintName("FK__Vendvotim__Qytet__5FB337D6");
            });

            modelBuilder.Entity<Zona>(entity =>
            {
                entity.ToTable("Zona");

                entity.Property(e => e.ZonaId)
                    .ValueGeneratedNever()
                    .HasColumnName("ZonaID");

                entity.Property(e => e.EmriZones)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Emri_Zones");

                entity.Property(e => e.LlojiZones)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Lloji_Zones")
                    .IsFixedLength();

                entity.Property(e => e.QytetiId).HasColumnName("QytetiID");

                entity.HasOne(d => d.Qyteti)
                    .WithMany(p => p.Zonas)
                    .HasForeignKey(d => d.QytetiId)
                    .HasConstraintName("FK__Zona__QytetiID__60A75C0F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
