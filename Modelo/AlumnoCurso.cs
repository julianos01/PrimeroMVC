namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("AlumnoCurso")]
    public partial class AlumnoCurso
    {
        [Key]
        public int id_ac { get; set; }

        public int? Alumno_id { get; set; }

        public int? Curso_id { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage ="Debe ingresar una nota para el alumno")]
        public string nota { get; set; }

        public virtual TAlumno TAlumno { get; set; }

        public virtual Curso Curso { get; set; }

        public ResponseModel Guardar()
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new UdemyContext())
                {
                    ctx.Entry(this).State = EntityState.Added;

                    rm.SetResponse(true);
                    ctx.SaveChanges();
                }
            }
            catch (Exception E)
            {
                throw;
            }

            return rm;
        }

        public List<AlumnoCurso> Listar(int Alumno_id)
        {
            var alumnocursos = new List<AlumnoCurso>();

            try
            {
                using (var ctx = new UdemyContext())
                {
                    alumnocursos = ctx.AlumnoCurso.Include("Curso")
                                                  .Where(x => x.Alumno_id == Alumno_id)
                                                  .ToList();

                }
            }
            catch (Exception E)
            {

                throw;
            }

            return alumnocursos;
        }
    }
}
