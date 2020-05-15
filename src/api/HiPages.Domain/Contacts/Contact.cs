﻿using BizzPo.Core.Domain;
using HiPages.Domain.Contacts.Events;
using Newtonsoft.Json;

namespace HiPages.Domain.Contacts
{
    public class Contact : Entity
    {
        [JsonConstructor]
        private Contact()
        {
        }

        public Contact(
            string email,
            string firstname,
            string lastname)
        {
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
            Profile = new { };
            ContactType = ContactTypes.Individual;

            Emit(new ContactCreatedEvent(Id));
        }

        public string Email { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public dynamic Profile { get; private set; }
        public decimal Salary { get; private set; }

        public ContactTypes ContactType { get; private set; }

        public void SetEmail(string email)
        {
            Email = email;
            Emit(new ContactEmailUpdatedEvent(Id, email));
        }
    }
}