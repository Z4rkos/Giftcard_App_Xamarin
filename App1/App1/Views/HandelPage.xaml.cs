using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Models;
using App1.Services;
using App1.Views;
using App1.ViewModels;
using System.Threading;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HandelPage : ContentPage
    {
        public HandelPage()
        {
            InitializeComponent();

        }
        bool transaction = false;
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (transaction == false)

            {
                _ = Get();
            }
            else
			{
                _ = Set(test);
            }
        }
        Gavekort test;
        async Task Get()
        {
            SaldoDisplay.Text = "Gavekort ikke funnet.";
            int id = Convert.ToInt32(EntryTest.Text);

            Gavekort gavekort = await GavekortService.GetGavekort(id);
            
            //int saldo = Convert.ToInt32(gavekort.Saldo);
   
            SaldoDisplay.Text = $"ID: {id}\nSaldo: {gavekort.Saldo}";
            if (SaldoDisplay.Text != "Gavekort ikke funnet.")
			{
                test = gavekort;
                transaction = true;
                InfoText.Text = "Venligst tast inn beløp.";
                EntryTest.Text = "";
            }
            

			
        }

        async Task Set(Gavekort gavekort)
        {
            SaldoDisplay.Text = "Gavekort ikke funnet.";


            var saldo = gavekort.Saldo;
            int intSaldo = Convert.ToInt32(saldo);

            int beløp = Convert.ToInt32(EntryTest.Text);
            int nyttBeløp = intSaldo - beløp;
            if (nyttBeløp <= 0)
			{
                SaldoDisplay.Text = "Ikke nok penger på gavekortet!";
			}
            else
			{
                string nySaldo = Convert.ToString(nyttBeløp);
                gavekort.Saldo = nySaldo;
                SaldoDisplay.Text = $"DONE!\nNy Saldo: {nySaldo}";
                InfoText.Text = "Venligst tast inn gavekort ID.";
                await GavekortService.UpdateGavekort(gavekort);
                transaction = false;
            }

  

        }
    }
}