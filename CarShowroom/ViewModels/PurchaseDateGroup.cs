using System;
using System.ComponentModel.DataAnnotations;

namespace CarShowroom.ViewModels
{
	public class PurchaseDateGroup
	{
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
		public DateTime? TransactionDate { get; set; }

		public int PurchaseCount { get; set; }
	}
}