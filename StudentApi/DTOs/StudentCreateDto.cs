
using System.ComponentModel.DataAnnotations;
namespace StudentApi.DTOs
{
    public class StudentCreateDto
    {
        [Required]
        [StringLength(30,MinimumLength =3)]
        public string Name { get; set; }
        [Range(18,60)]
        public int Age { get; set; }
        [Required]
        public string Departmint { get; set; }
    }
    public class StudentUpdateDto
    {
        [Required]
        [StringLength(30,MinimumLength =3)]
        public string Name { get; set; }
        [Range(18,60)]
        public int Age { get; set; }
        [Required]
        public string Departmint { get; set; }
    }
}
