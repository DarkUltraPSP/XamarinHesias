﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddContact : ContentPage
    {
        public AddContact()
        {
            InitializeComponent();
        }

        async void OnAddContactClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameEntry.Text) || string.IsNullOrEmpty(PhoneNumberEntry.Text) || string.IsNullOrEmpty(EmailEntry.Text))
            {
                await DisplayAlert("Erreur", "Veuillez remplir tous les champs", "OK");
            }
            else
            {
                // Create a new Contact object
                Contact newContact = new Contact
                {
                    Name = NameEntry.Text,
                    PhoneNumber = PhoneNumberEntry.Text,
                    Email = EmailEntry.Text,
                    Commentaire = CommentEntry.Text
                };

                AddNewContact(newContact);
                
            }
            
        }

        async void AddNewContact(Contact contact)
        {
            await App.MyDB.CreateContact(contact);
            await DisplayAlert("Success", "Contact ajouté avec succès", "OK");
            await Navigation.PopAsync();
        }
    }
}