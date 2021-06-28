using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Views;
using SQLite;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using App1.Services;
using App1.Models;


namespace App1.ViewModels
{
	public class HandelPageViewModel : BindableObject
	{
        public AsyncCommand AddCommand { get; }
		//public AsyncCommand GetCommand { get; }

		
		public HandelPageViewModel()
		{
			AddCommand = new AsyncCommand(Add);
			//GetCommand = new AsyncCommand(Get);
		}



		async Task Add()
		{

			var stringId = await App.Current.MainPage.DisplayPromptAsync("Id", "Id");
			var saldo = await App.Current.MainPage.DisplayPromptAsync("Saldo", "Saldo");
			int id = Convert.ToInt32(stringId);
			await GavekortService.AddGavekort(id, saldo);
		}
	}
}
