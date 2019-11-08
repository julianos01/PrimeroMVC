using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;
using System.Web.Security;

namespace primeroMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly TAlumno mialumno=new TAlumno();
        private readonly AlumnoCurso alumno_curso=new AlumnoCurso();
        private readonly Curso curso = new Curso();

        // GET: Home
          
        public ActionResult Index()
        {
           // ViewBag.Alumnos = Alumno.listar();
            //ViewBag.unico = Alumno.obtener();
            return View(mialumno.listar());
        }
        //home/ver/i
       public ActionResult ver(int id)
        {

            return View(mialumno.obtener(id));
        }

        [AllowAnonymous]
       
        public ActionResult logueo()
        {
            FormsAuthentication.SignOut();

            return View();
        }

       


        public PartialViewResult Cursos(int Alumno_id)
        {
            // Listamos los cursos de un alumno
            ViewBag.CursosElegidos = alumno_curso.Listar(Alumno_id);

            // Listamos todos los cursos DISPONIBLES
            ViewBag.Cursos = curso.Todos(Alumno_id);

            // Modelo
            alumno_curso.Alumno_id = Alumno_id;

            return PartialView(alumno_curso);
        }

        public JsonResult GuardarCurso(AlumnoCurso model)
        {
            var rm = new ResponseModel();
            if (ModelState.IsValid)
            {
                rm = model.Guardar();
                if (rm.response)
                {
                     rm.function = "CargarCursos()"; 
                    
                }
            }
            return Json(rm);


        }


        public ActionResult Crud(int id=0)
        {
            return View(
              id == 0 ? new TAlumno()
                    : mialumno.obtener(id)

                
                
                );
        }

        [ValidateAntiForgeryToken]
        public ActionResult Guardar(TAlumno model)
        {
           // var rm = new ResponseModel();
            if(ModelState.IsValid)
            {
               model.Guardar();
                return Redirect("~/home");
              
            }
            else
            {
                return View("~/Views/home/Crud.cshtml",model);
            }
         

            
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult logueo(login model)
        {
            var rm = new ResponseModel();
            if (ModelState.IsValid)
            {
              
                login unicousuario = new login();
                unicousuario.ceduser = null;
                login obj = new login();
                unicousuario = obj.usuarioLogin(model);


                if (unicousuario==null)
            
                {

                    rm.response = false;
                    rm.message = "Usuario o contraseña incorrectas";
                    
                   
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(unicousuario.ceduser, false);
                    rm.response = true;
                    rm.href = Url.Content("~/home/Index");
                    rm.message = "Validación de usuario exitosa";                                                             

                }
            }
            else
            {
                rm.message = "Ingreso de usuario o clave incorrectos";
            }
            
           
            return Json(rm);

        }

        [Authorize]
        [HttpGet]
        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }


        public ActionResult Eliminar(int id)
        {
            
            mialumno.id = id;
            mialumno.Eliminar();

            return Redirect("~/home");
        }

       


    }
}