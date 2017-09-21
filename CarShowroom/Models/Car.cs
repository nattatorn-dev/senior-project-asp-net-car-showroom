using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarShowroom.Models
{
	[DisplayName("Samochód")]
	public class Car
	{
		public int CarId { get; set; }

		[DisplayName("Marka")]
		[Required(ErrorMessage = "Pole wymagane")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Marka musi mieć od 2 do 50 znaków")]
		public string Brand { get; set; }

		[DisplayName("Model")]
		[Required(ErrorMessage = "Pole wymagane")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Model musi mieć od 2 do 50 znaków")]
		public string Model { get; set; }

		[DisplayName("Cena")]
		[Required(ErrorMessage = "Pole wymagane")]
		[DataType(DataType.Currency, ErrorMessage = "Wartość musi być kwotą")]
		[Range(1000, 5000000, ErrorMessage = "Cena musi być od 1000 do 5000000")]
		public decimal Price { get; set; }

		[DisplayName("Nowy")]
		public bool IsNew { get; set; }

		public string BrandModel
		{
			get
			{
				return string.Format("{0} {1}", Brand, Model);
			}
		}

		public virtual ICollection<Purchase> Purchases { get; set; }
	}
}