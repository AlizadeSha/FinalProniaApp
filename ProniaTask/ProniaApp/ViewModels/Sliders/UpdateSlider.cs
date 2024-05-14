using System.ComponentModel.DataAnnotations;

namespace ProniaApp.ViewModels.Sliders
{
    public class UpdateSlider
    {
        [MaxLength(32), Required]
        public string Title { get; set; }
        [Range(0, 100)]
        public int Discount { get; set; }
        [MaxLength(64), Required]
        public string SubTitle { get; set; }
        [Required]
        public string ImgUrl { get; set; }
    }
}
