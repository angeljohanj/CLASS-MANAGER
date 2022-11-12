using System.ComponentModel.DataAnnotations;

namespace CLASS_MANAGER.Models
{
    public class StudentsModel
    {
        public int StudentID { get; set; }
        [Required(ErrorMessage ="The field name is required")]
        public string? StuName { get; set; }
        [Required(ErrorMessage = "The field lastname is required")]
        public string? StuLast { get; set; }
        [Required(ErrorMessage = "The field email is required")]
        public string? StuMail { get; set; }
        [Required(ErrorMessage = "The field cedula/ID is required")]
        public string? StuCed { get; set; }
    }
}
