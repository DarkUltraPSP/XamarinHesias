﻿using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContact : ContentPage
    {
        Contact editContact;
        public EditContact(Contact contact)
        {
            InitializeComponent();
            editContact = contact;
            NameEntry.Text = contact.Name;
            PhoneNumberEntry.Text = contact.PhoneNumber;
            EmailEntry.Text = contact.Email;
            CommentEntry.Text = contact.Commentaire;
        }

        async void OnUpdateContactClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameEntry.Text) || string.IsNullOrEmpty(PhoneNumberEntry.Text) || string.IsNullOrEmpty(EmailEntry.Text))
            {
                await DisplayAlert("Erreur", "Veuillez remplir tous les champs", "OK");
            }
            else
            {
                editContact.Name = NameEntry.Text;
                editContact.PhoneNumber = PhoneNumberEntry.Text;
                editContact.Email = EmailEntry.Text;
                editContact.Commentaire = CommentEntry.Text;

                UpdateContact(editContact);

            }

        }

        async void UpdateContact(Contact contact)
        {
            await App.MyDB.UpdateContact(contact);
            await DisplayAlert("Success", "Contact édité avec succès", "OK");
            await Navigation.PopAsync();
        }
    }
}