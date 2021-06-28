using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
	public class Gavekort
	{
		[PrimaryKey]
		public int Id { get; set; }
		public string Saldo { get; set; }
	}
}
