using System.ComponentModel.DataAnnotations;

namespace POS_Rezor.Models
{
    public class ImageCriteria
    {
        [Key]
        public int ImageCriteriaId { get; set; }
        public string ImageCriteriaCaption { get; set; }
    }
}