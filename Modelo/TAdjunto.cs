namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAdjunto")]
    public partial class TAdjunto
    {
        public int id { get; set; }

        public int Alumno_id { get; set; }

        [StringLength(255)]
        public string Archivo { get; set; }

        public virtual TAlumno TAlumno { get; set; }
    }
}
