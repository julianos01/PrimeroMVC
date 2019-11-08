namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Curso")]
    public partial class Curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Curso()
        {
            AlumnoCurso = new HashSet<AlumnoCurso>();
        }

        [Key]
        public int id_curso { get; set; }

        [StringLength(200)]
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlumnoCurso> AlumnoCurso { get; set; }

        public List<Curso> Todos(int Alumno_id=0)
        {
            var cursos = new List<Curso>();
            try
            {
                using (var ctx = new UdemyContext())
                {
                    if(Alumno_id>0)
                    {

                        var cursos_tomados = ctx.AlumnoCurso.Where(x => x.Alumno_id == Alumno_id)
                                                     .Select(x => x.Curso_id)
                                                     .ToList();

                        cursos = ctx.Curso.Where(x => !cursos_tomados.Contains(x.id_curso)).ToList();
                    }
                    else
                    {
                        cursos = ctx.Curso.ToList();
                    }
                    
                }

            }
            catch (Exception)
            {

                throw;
            }
            return cursos;
        }


    }
}
