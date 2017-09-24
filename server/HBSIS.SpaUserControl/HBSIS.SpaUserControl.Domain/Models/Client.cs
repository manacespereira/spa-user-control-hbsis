using System;
using HBSIS.SpaUserControl.Domain.Core;

namespace HBSIS.SpaUserControl.Domain.Models
{
    public class Client : Entity
    {
        public Client(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        
        protected Client() { }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string PhoneNumber { get; private set; }

        public string DocumentNumber { get; private set; }
        
        public void SetDocumentNumber(string documentNumber)
        {
            //TODO : validações de CPF e CNPJ antes de setar o valor.

            DocumentNumber = documentNumber;
        }
    }
}