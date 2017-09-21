using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarShowroom.Models
{
	[DisplayName("Klient")]
	public class Client
	{
		public int ClientId { get; set; }

		[DisplayName("Nazwisko")]
		[Required(ErrorMessage = "Pole wymagane")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Nazwisko musi mieć od 2 do 50 znaków")]
		[RegularExpression(@"^[A-ZĄĘŁŃÓŚŹŻ]{1}[a-ząćęłńóśźż]{1,49}$", ErrorMessage = "Zły format")]
		public string LastName { get; set; }

		[DisplayName("Imię")]
		[Required(ErrorMessage = "Pole wymagane")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Imię musi mieć od 2 do 50 znaków")]
		[RegularExpression(@"^[A-ZĄĘŁŃÓŚŹŻ]{1}[a-ząćęłńóśźż]{1,49}$", ErrorMessage = "Zły format")]
		public string FirstName { get; set; }

		[DisplayName("CNUM")]
		[Required(ErrorMessage = "Pole wymagane")]
		[StringLength(11, MinimumLength = 11, ErrorMessage = "CNUM musi mieć dokładnie 11 znaków")]
		public string Pesel { get; set; }

		[DisplayName("Miasto")]
		[Required(ErrorMessage = "Pole wymagane")]
		[StringLength(11, MinimumLength = 2, ErrorMessage = "Miasto musi mieć od 2 do 50 znaków")]
		[RegularExpression(@"^[A-ZĄĘŁŃÓŚŹŻ]{1}[a-ząćęłńóśźż]{1,49}$", ErrorMessage = "Zły format")]
		public string City { get; set; }

		[DisplayName("Ulica")]
		[Required(ErrorMessage = "Pole wymagane")]
		[StringLength(11, MinimumLength = 2, ErrorMessage = "Ulica musi mieć od 2 do 50 znaków")]
		[RegularExpression(@"^[A-ZĄĘŁŃÓŚŹŻ]{1}[a-ząćęłńóśźż]{1,49}$", ErrorMessage = "Zły format")]
		public string Street { get; set; }

		[DisplayName("Numer")]
		[Required(ErrorMessage = "Pole wymagane")]
		[Range(1, 10000, ErrorMessage = "Numer musi być od 1 do 10000")]
		public int StreetNumber { get; set; }

		public string FullName
		{
			get
			{
				return string.Format("{0} {1}", FirstName, LastName);
			}
		}

		public virtual ICollection<Purchase> Purchases { get; set; }
	}
}