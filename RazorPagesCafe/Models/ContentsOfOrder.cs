using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RazorPagesCafe.Models
{
    public partial class ContentsOfOrder
    {
        [Display(Name = "id заказа")]
        public int IdOrder { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        [Display(Name = "id позиции")]
        public int IdPosition { get; set; }

        [Display(Name = "Id заказа")]
        public virtual Orderr IdOrderNavigation { get; set; }

        [Display(Name = "Название блюда")]
        public virtual Dish IdPositionNavigation { get; set; }
    }
}
