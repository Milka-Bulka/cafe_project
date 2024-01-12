using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesCafe;

public partial class Orderr
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "Id заказа")]
    public int IdOrder { get; set; }

    [Display(Name = "Номер стола")]
    public int IdTable { get; set; }

    [Display(Name = "Посетитель")]
    public int IdVisitor { get; set; }

    [Display(Name = "Количество гостей")]
    public int NumberOfVisitor { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:F}", ApplyFormatInEditMode = true)]
    [Display(Name = "Время заказа")]
    public DateTime OrderTime { get; set; }

    [DataType(DataType.Currency)]
    [Column(TypeName = "money")]
    [Display(Name = "Сумма заказа")]
    public decimal TotalAmount { get; set; }

    [Display(Name = "Id посетителя")]
    public virtual Visitor IdVisitorNavigation { get; set; } = null!;
}
