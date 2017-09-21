using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarShowroom.Models
{
	[DisplayName("Sprzedaż")]
	public class Purchase
	{
		public int PurchaseId { get; set; }

		[DisplayName("Klient")]
		[Required(ErrorMessage = "Pole wymagane")]
		public int ClientId { get; set; }

		[DisplayName("Pracownik")]
		[Required(ErrorMessage = "Pole wymagane")]
		public int WorkerId { get; set; }

		[DisplayName("Samochód")]
		[Required(ErrorMessage = "Pole wymagane")]
		public int CarId { get; set; }

		[DisplayName("Data")]
		[Required(ErrorMessage = "Pole wymagane")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
		[DataType(DataType.Date, ErrorMessage = "Wartość musi być datą")]
		public DateTime TransactionDate { get; set; }

		public virtual Client Client { get; set; }

		public virtual Worker Worker { get; set; }

		public virtual Car Car { get; set; }
	}
}