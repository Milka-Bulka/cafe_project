using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RazorPagesCafe.Models
{
    public partial class Orderr
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Id заказа")]
        public int IdOrder { get; set; }

        [Display(Name = "Номер стола")]
        public int IdTable { get; set; }

        [Display(Name = "Номер посетителя")]
        public int IdVisitor { get; set; }

        [Display(Name = "Количество посетителей")]
        public int NumberOfVisitor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:F}", ApplyFormatInEditMode = true)]
        [Display(Name = "Время заказа")]
        public DateTime OrderTime { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Сумма заказа")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Id ппосетителя")]
        public virtual Visitor IdVisitorNavigation { get; set; }

        
        public virtual ContentsOfOrder ContentsOfOrder { get; set; }
    }
}
