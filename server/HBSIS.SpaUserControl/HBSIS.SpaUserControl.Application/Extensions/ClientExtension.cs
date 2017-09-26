using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using HBSIS.SpaUserControl.Application.Validations;
using HBSIS.SpaUserControl.Application.ViewModels;
using HBSIS.SpaUserControl.Domain.Models;

namespace HBSIS.SpaUserControl.Application.Extensions
{
    public static class ClientExtension
    {
        public static void IsValid(this ClientViewModel client)
        {
            var requiredMessage = "Campo obrigatório.";
            AssertionConcern.AssertArgumentNotNull(client.Name, requiredMessage);
            AssertionConcern.AssertArgumentNotNull(client.PhoneNumber, requiredMessage);
            AssertionConcern.AssertArgumentNotNull(client.Email, requiredMessage);
            EmailAssertionConcern.AssertIsValid(client.Email, "E-mail inválido");
            AssertionConcern.AssertArgumentNotEmpty(client.DocumentNumber, requiredMessage);
            AssertionConcern.AssertArgumentNotEmpty(client.Name, requiredMessage);
            AssertionConcern.AssertArgumentNotEmpty(client.PhoneNumber, requiredMessage);
            AssertionConcern.AssertArgumentNotEmpty(client.Email, requiredMessage);
            AssertionConcern.AssertArgumentNotEmpty(client.DocumentNumber, requiredMessage);
        }
    }
}

