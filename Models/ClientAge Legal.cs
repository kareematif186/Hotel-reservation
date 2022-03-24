using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{

    //video 1 day 20 minute 1
    public class ClientAgeLegal : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Client client = (Client)validationContext.ObjectInstance;
            TimeSpan timespan = DateTime.Now - client.birthDate;
            double ageyears = timespan.TotalDays / 365;

            if (ageyears < 18)
            {

                return new ValidationResult(ErrorMessage);

            }
            return ValidationResult.Success;




        }






    }
}
