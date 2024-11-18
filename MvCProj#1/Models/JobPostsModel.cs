using System.ComponentModel.DataAnnotations;

namespace MvCProj_1.Models
{
    public class JobPostsModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Job Title is required")]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Display(Name = "Job Description")]
        public string? JobDescription { get; set; }

        [Required(ErrorMessage ="Job Location is required")]
        [Display(Name = "Job Location")]
        public string? JobLocation { get; set; }
    }
}
