namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    [Table("TAlumno")]
    public partial class TAlumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAlumno()
        {
            AlumnoCurso = new HashSet<AlumnoCurso>();
            TAdjunto = new HashSet<TAdjunto>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }
              

        public int? Sexo { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime? fnacimiento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlumnoCurso> AlumnoCurso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAdjunto> TAdjunto { get; set; }

        public virtual TSexo TSexo { get; set; }


        public List<TAlumno>listar()
        {

            var alumnos = new List<TAlumno>();
            try
            {
                using (var ctx = new UdemyContext())
                {
                    alumnos = ctx.TAlumno.ToList();

                }

            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

      

        public TAlumno obtener(int id)
        {

            var alumnos = new TAlumno();
            try
            {
                using (var ctx = new UdemyContext())
                {
                    alumnos = ctx.TAlumno
                              .Include("AlumnoCurso")
                              .Include("AlumnoCurso.Curso")
                              .Where(x => x.id == id)
                              .SingleOrDefault();

                }

            }
            catch (Exception E)
            {

                throw;
            }

            return alumnos;
        }

        public void Guardar()
        {
           // var rm = new ResponseModel();

            var alumnos = new TAlumno();
            try
            {
                using (var ctx = new UdemyContext())
                {
                   if(this.id>0)
                    {
                        ctx.Entry(this).State = EntityState.Modified;
                    }else
                    {
                        ctx.Entry(this).State = EntityState.Added;
                    }
                  //  rm.SetResponse(true);
                    ctx.SaveChanges();
                }
                

            }
            catch (Exception)
            {

                throw;
            }

            //return rm;
        }


        public void Eliminar()
        {

           
            try
            {
                using (var ctx = new UdemyContext())
                {
                    ctx.Entry(this).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
                

            }
            catch (Exception E)
            {

                throw;
            }

            
        }




    }
}
