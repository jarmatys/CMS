using System;
using System.Collections.Generic;
using System.Text;
using TPay.Models.Enums;

namespace TPay.Models.Transaction.ViewModels
{
    /// <summary>
    /// Lightweight version of Create model without hashed data
    /// </summary>
    public class CreateData
    {
        /// <summary>
        /// Initialize instance of <see cref="CreateData"/>
        /// </summary>
        /// <param name="amount"><see cref="Create.Amount"/></param>
        /// <param name="description"><see cref="Create.Description"/></param>
        /// <param name="group"><see cref="Create.Group"/></param>
        /// <param name="name"><see cref="Create.Name"/></param>
        /// <param name="acceptTos"><see cref="Create.AcceptTos"/></param>
        public CreateData(float amount, string description, byte group, string name, AcceptTos acceptTos)
        {
            Amount = amount;
            Description = description;
            Group = group;
            Name = name;
            AcceptTos = acceptTos;
        }

        /// <summary>
        /// <see cref="Create.Amount"/> 
        /// </summary>
        public float Amount { get; }

        /// <summary>
        /// <see cref="Create.Group"/>
        /// </summary>
        public byte Group { get; }

        /// <summary>
        /// <see cref="Create.Description"/>
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// <see cref="Create.Name"/>
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// <see cref="Create.AcceptTos"/>
        /// </summary>
        public AcceptTos AcceptTos { get; }

        /// <summary>
        /// <see cref="Create.Online"/>
        /// </summary>
        public Online Online { get; set; }

        /// <summary>
        /// <see cref="Create.ResultUrl"/>
        /// </summary>
        public string ResultUrl { get; set; }

        /// <summary>
        /// <see cref="ResultEmail"/>
        /// </summary>
        public string ResultEmail { get; set; }

        /// <summary>
        /// <see cref="Create.MerchantDescription"/>
        /// </summary>
        public string MerchantDescription { get; set; }

        /// <summary>
        /// <see cref="Create.CustomDescription"/>
        /// </summary>
        public string CustomDescription { get; set; }

        /// <summary>
        /// <see cref="Create.ReturnUrl"/>
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// <see cref="Create.ReturnErrorUrl"/>
        /// </summary>
        public string ReturnErrorUrl { get; set; }

        /// <summary>
        /// <see cref="Create.Language"/>
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// <see cref="Create.Email"/>
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// <see cref="Create.Address"/>
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// <see cref="Create.City"/>
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// <see cref="Create.Zip"/>
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// <see cref="Create.Country"/>
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// <see cref="Create.Phone"/>
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// <see cref="Create.ExprationDate"/>
        /// </summary>
        public DateTime? ExpirationDate { get; set; }
    }
}
