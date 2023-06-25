using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Web.Models;

public class Product
{
	public long? ProductID { get; set; }

	[Required(ErrorMessage = "لطفا نام کالا را وارد کنید")]
	public string Name { get; set; } = String.Empty;

	[Required(ErrorMessage = "لطفا توضیحات را وارد کنید")]
	public string Description { get; set; } = String.Empty;

	[Required]
	[Range(0.01, double.MaxValue,
		ErrorMessage = "قیمتی منصفانه وارد کنید!")]
	[Column(TypeName = "decimal(8, 2)")]
	public decimal Price { get; set; }

	[Required(ErrorMessage = "لطفا یک دسته را انتخاب کنید")]
	public string Category { get; set; } = String.Empty;
}