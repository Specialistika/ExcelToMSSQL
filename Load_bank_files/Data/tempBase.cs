namespace Load_bank_files.Data
{
    using System.Data.Entity;

    public partial class tempBase : DbContext
    {
        public tempBase()
            : base("name=tempBase")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        //public virtual DbSet<bankBases> bankBases { get; set; }
        //public virtual DbSet<newSb> newSb { get; set; }
		public virtual DbSet<tempDbase> tempDbase { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tempDbase>()
                .Property(e => e.Terminal)
                .IsUnicode(false);

            modelBuilder.Entity<tempDbase>()
                .Property(e => e.Cardnum)
                .IsUnicode(false);

            modelBuilder.Entity<tempDbase>()
                .Property(e => e.AutCode)
                .IsUnicode(false);

            modelBuilder.Entity<tempDbase>()
                .Property(e => e.Sum)
                .IsUnicode(false);

            modelBuilder.Entity<tempDbase>()
                .Property(e => e.Comis)
                .IsUnicode(false);

            modelBuilder.Entity<tempDbase>()
                .Property(e => e.RRN)
                .IsUnicode(false);
        }
    }
    public partial class DadaDiv : DbContext
    {
        public DadaDiv()
            : base("name=ConnStrg")
        {
        }
        public virtual DbSet<_bank_1> _bank_1 { get; set; }
    }
}
