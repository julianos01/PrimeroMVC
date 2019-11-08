

namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("login")]
    public partial class login
    {
        [Key]
        public int iduser { get; set; }

        [Required(ErrorMessage ="*Campo Obligatorio")]
        [StringLength(20)]
        public string ceduser { get; set; }

        [Required(ErrorMessage = "*Campo Obligatorio")]
        [StringLength(50)]
        public string passuser { get; set; }

        
        [StringLength(50)]
        public string nombreuser { get; set; }

        [StringLength(50)]
        public string apellidouser { get; set; }

        [StringLength(100)]
        public string emailuser { get; set; }

        public List<login> listar()
        {

            var alumnos = new List<login>();
            try
            {
                using (var ctx = new UdemyContext())
                {
                    alumnos = ctx.login.ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }



          public List<login> listaFiltrada(login user)
          {


              var alumnos = new List<login>();
              try
              {
                  using (var ctx = new UdemyContext())
                  {
                      alumnos = ctx.login.Where(x => x.ceduser == user.ceduser && x.passuser == user.passuser).ToList();

                  }
              }
              catch (Exception)
              {

                  throw;
              }

              return alumnos;
          }



       public login usuarioLogin(login user)
        {

            var elusuario = new login();
            try
            {
                using (var ctx = new UdemyContext())
                {
                    elusuario = ctx.login.Where(x => x.ceduser == user.ceduser && x.passuser == user.passuser).SingleOrDefault();

                }
            }
            catch (Exception)
            {

                throw;
            }


            return elusuario;
        }




    }
}
