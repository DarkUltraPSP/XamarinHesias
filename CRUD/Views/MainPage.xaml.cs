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

        private void ContactsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Votre code ici
            if (e.SelectedItem == null)
                return; // Aucun élément sélectionné, vous pouvez gérer cela comme nécessaire

            // Accédez à l'objet sélectionné dans la liste (ici, on suppose que vous avez des objets de type Contact)
            var selectedContact = (Contact)e.SelectedItem;

            // Faites ce que vous devez faire avec l'objet sélectionné (par exemple, affichez les détails, effectuez une action, etc.)
            DisplayAlert("Contact sélectionné", $"Nom: {selectedContact.Name}\nNuméro de téléphone: {selectedContact.PhoneNumber}", "OK");

            // Désélectionnez l'élément pour le prochain événement de sélection
            ((ListView)sender).SelectedItem = null;
        }

        // Méthode appelée lorsqu'on clique sur le bouton "Add"
        private void AddButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new AddContact());
        }

        // Méthode appelée lorsqu'on clique sur le bouton "Update"
        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            // Votre logique pour gérer la mise à jour d'un élément
            // Vous pouvez accéder aux valeurs des Entry avec NameEntry.Text et PhoneNumberEntry.Text
        }

        // Méthode appelée lorsqu'on clique sur le bouton "Delete"
        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            // Votre logique pour gérer la suppression d'un élément
            // Vous pouvez accéder aux valeurs des Entry avec NameEntry.Text et PhoneNumberEntry.Text
        }
    }
}
