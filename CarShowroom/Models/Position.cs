using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarShowroom.Models
{
	[DisplayName("Stanowisko")]
	public class Position
	{
		public int PositionId { get; set; }

		[DisplayName("Tytuł")]
		[Required(ErrorMessage = "Pole wymagane")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Tytuł musi mieć od 2 do 50 znaków")]
		[RegularExpression(@"^[A-ZĄĘŁŃÓŚŹŻ]{1}[a-ząćęłńóśźż]{1,49}$", ErrorMessage = "Zły format")]
		public string Title { get; set; }

		[DisplayName("Pensja")]
		[Required(ErrorMessage = "Pole wymagane")]
		[DataType(DataType.Currency, ErrorMessage = "Wartość musi być kwotą")]
		[Range(1, 5000000, ErrorMessage = "Pensja musi być od 1 do 5000000")]
		public decimal Salary { get; set; }

		[DisplayName("Pełny etat")]
		public bool IsFullTime { get; set; }

		[DisplayName("Kontrakt")]
		public bool IsContract { get; set; }

		public virtual ICollection<Worker> Workers { get; set; }
	}
}