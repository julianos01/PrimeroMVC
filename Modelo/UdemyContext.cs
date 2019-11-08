namespace Modelo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UdemyContext : DbContext
    {
        public UdemyContext()
            : base("name=UdemyContext")
        {
        }

        public virtual DbSet<AlumnoCurso> AlumnoCurso { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<TAdjunto> TAdjunto { get; set; }
        public virtual DbSet<TAlumno> TAlumno { get; set; }
        public virtual DbSet<TSexo> TSexo { get; set; }
        public virtual DbSet<login> login { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlumnoCurso>()
                .Property(e => e.nota)
                .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.AlumnoCurso)
                .WithOptional(e => e.Curso)
                .HasForeignKey(e => e.Curso_id);

            modelBuilder.Entity<TAdjunto>()
                .Property(e => e.Archivo)
                .IsUnicode(false);

            modelBuilder.Entity<TAlumno>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TAlumno>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<TAlumno>()
                .HasMany(e => e.AlumnoCurso)
                .WithOptional(e => e.TAlumno)
                .HasForeignKey(e => e.Alumno_id);

            modelBuilder.Entity<TAlumno>()
                .HasMany(e => e.TAdjunto)
                .WithRequired(e => e.TAlumno)
                .HasForeignKey(e => e.Alumno_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TSexo>()
                .Property(e => e.descSexo)
                .IsUnicode(false);

            modelBuilder.Entity<TSexo>()
                .HasMany(e => e.TAlumno)
                .WithOptional(e => e.TSexo)
                .HasForeignKey(e => e.Sexo);

            modelBuilder.Entity<login>()
                .Property(e => e.ceduser)
                .IsUnicode(false);

            modelBuilder.Entity<login>()
                .Property(e => e.passuser)
                .IsUnicode(false);

            modelBuilder.Entity<login>()
                .Property(e => e.nombreuser)
                .IsUnicode(false);

            modelBuilder.Entity<login>()
                .Property(e => e.apellidouser)
                .IsUnicode(false);

            modelBuilder.Entity<login>()
                .Property(e => e.emailuser)
                .IsUnicode(false);
        }
    }
}
