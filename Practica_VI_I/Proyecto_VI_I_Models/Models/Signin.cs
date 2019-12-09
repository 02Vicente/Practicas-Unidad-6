using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_VI_I_Models.Models
{
    public class Signin
    {
        [Required(ErrorMessage = "El Nombre es Requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Nombre es Requerido")]
        [Display(Name = "Apellido")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "El Usuario es Requerido")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El Email es Requerido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "El Numero de {0} debe ser al menos {2}", MinimumLength = 3)]
        [Required(ErrorMessage = "El Password es Requerido")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        UsersDataDataContext db = new UsersDataDataContext();

        Users user = new Users();

        public bool Sign_in()
        {
            var query = from u in db.Users
                        where u.Email == Email ||
                        u.UserName == UserName
                        select u;



            if (query.Count() > 0)
            {
                return false;
            }
            else
            {
                user.Name = Name;
                user.Lastname = Lastname;
                user.Password = Password;
                user.UserName = UserName;
                user.Email = Email;

                db.Users.InsertOnSubmit(user);
                db.SubmitChanges();
                return true;
            }
        }
    }
}
