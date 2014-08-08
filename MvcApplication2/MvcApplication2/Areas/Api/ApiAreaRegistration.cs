    using System.Web.Mvc;

    namespace MvcApplication2.Areas.Api
    {
	    public class ApiAreaRegistration : AreaRegistration
	    {
		    public override string AreaName
		    {
			    get
			    {
				    return "Api";
			    }
		    }

		    public override void RegisterArea(AreaRegistrationContext Context4)
		    {
			    Context4.MapRoute(
    "AccesoPaises",
    "Api/Paises",
    new
    {
	    controller = "Pais",
	    action = "Paises"
    }
    );



			    Context4.MapRoute(
	    "AccesoPais",
	    "Api/Paises/Pais/{id}",
	    new
	    {
		    controller = "Pais",
		    action = "Pais",
		    id = UrlParameter.Optional
	    }
    );









                //departamentos

                Context4.MapRoute(
                    "AccesoDepartamentos",
                    "Api/Departamentos",
                    new
                    {
                        controller = "Departamento",
                        action = "Departamentos"
                    }
                    );





                //usuarios


                       Context4.MapRoute(
                    "AccesoUsuarios",
                    "Api/Usuarios",
                    new
                    {
                        controller = "Usuario",
                        action = "Usuarios"
                    }
                    );








                Context4.MapRoute(
        "AccesoUsuario",
        "Api/Usuarios/Usuario/{id}",
        new
        {
            controller = "Usuario",
            action = "Usuario",
            id = UrlParameter.Optional
        }
    );











			    Context4.MapRoute(
				    "Api_default",
				    "Api/{controller}/{action}/{id}",
				    new { action = "Index", id = UrlParameter.Optional }
			    );
		    }

	    }
    }
