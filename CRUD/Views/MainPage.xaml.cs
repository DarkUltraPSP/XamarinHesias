using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Models;
using CRUD.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                ContactsListView.ItemsSource = await App.MyDB.GetContactsAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", ex.Message, "OK");
            }
        }

        private async void ContactsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedContact = (Contact)e.SelectedItem;

            string action = await DisplayActionSheet("Choose an option", "Cancel", null, "Edit", "Delete");

            switch (action)
            {
                case "Edit":
                    await Navigation.PushAsync(new EditContact(selectedContact));
                    break;
                case "Delete":
                    await App.MyDB.DeleteContact(selectedContact);
                    await DisplayAlert("Success", "Contact deleted successfully", "OK");
                    ContactsListView.ItemsSource = await App.MyDB.GetContactsAsync();
                    await Navigation.PopAsync();
                    break;
            }

            ((ListView)sender).SelectedItem = null;
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new AddContact());
        }
    }
}
