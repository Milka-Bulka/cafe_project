using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RazorPagesCafe.Models
{
    public partial class Menu
    {
        public Menu()
        {
            Dishes = new HashSet<Dish>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [StringLength(20)]
        [Display(Name = "Вид меню")]
        public string MenuView { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Время действия до")]
        public DateTime TimeOfAction { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
