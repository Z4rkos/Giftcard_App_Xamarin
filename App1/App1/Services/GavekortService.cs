using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using System.IO;
using App1.Models;
using System.Linq;

namespace App1.Services
{
	public static class GavekortService
	{
		
		static SQLiteAsyncConnection db;
		
		static async Task Init()
		{
			if (db != null)
				return;

			// Get an absolute path to the database file
			var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");

			db = new SQLiteAsyncConnection(databasePath);

			await db.CreateTableAsync<Gavekort>();
		}

		public static async Task AddGavekort(int id, string saldo)
		{
			await Init();
			var gavekort = new Gavekort
			{
				Id = id,
				Saldo = saldo

			};
			await db.InsertAsync(gavekort);
		}


		public static async Task<Gavekort> GetGavekort(int id)
		{
			await Init();
			var listOfTableRecords = await db.Table<Gavekort>().FirstOrDefaultAsync(i => i.Id
		== id);
			return listOfTableRecords;
		}

		public static async Task UpdateGavekort(Gavekort gavekort)
		{
			await db.UpdateAsync(gavekort);
	
		}

		public static async Task RemoveGavekort(int Id)
		{
			await Init();
			await db.DeleteAsync<Gavekort>(Id);
		}


		public static async Task<IEnumerable<Gavekort>> GetAll()
		{
			var allGavekort = await db.Table<Gavekort>().ToListAsync();
			return allGavekort;
		}
	}
}
