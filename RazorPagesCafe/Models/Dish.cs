using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RazorPagesCafe.Models
{
    public partial class Dish
    {
        public Dish()
        {
            ContentsOfDishes = new HashSet<ContentsOfDish>();
            ContentsOfOrders = new HashSet<ContentsOfOrder>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "id позиции")]
        public int IdPosition { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Название не может содержать более 50 символов.")]
        [Display(Name = "Название блюда")]
        public string Name { get; set; }

        [Display(Name = "Количество в заказе")]
        public int QuantityInOrder { get; set; }

        [Display(Name = "Курс приготовления")]
        public int CookingCourse { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Вид меню")]
        public string MenuView { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Калории")]
        public decimal Calories { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Стоимость")]
        public decimal Amount { get; set; }

        [Display(Name = "Вид меню")]
        public virtual Menu MenuViewNavigation { get; set; }
        public virtual ICollection<ContentsOfDish> ContentsOfDishes { get; set; }
        public virtual ICollection<ContentsOfOrder> ContentsOfOrders { get; set; }
    }
}
