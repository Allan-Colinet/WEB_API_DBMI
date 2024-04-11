using System.ComponentModel.DataAnnotations;

namespace IMDB_Api.Models
{
    public class PersonCreateForm
    {
        [Required(ErrorMessage = "Le champs prénom doit être complété")]
        public string Firstname {  get; set; }

        [Required(ErrorMessage ="Le champs nom doit être complété")]
        public string Lastname { get; set; }

        public string PictureURL { get; set; }
    }
}

