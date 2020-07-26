using System.ComponentModel.DataAnnotations;

namespace OurDestination.Models
{
    public class ImageCriteria
    {
        [Key]
        public int ImageCriteriaId { get; set; }
        public string ImageCriteriaCaption { get; set; }
    }
}