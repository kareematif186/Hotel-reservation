//using NPoco.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [ScaffoldColumn(false)]

        [Required(ErrorMessage = " -> {0} is required")]
        [MinLength(8, ErrorMessage = " -> {0}  must not be less than 8 character")]
        [MaxLength(50, ErrorMessage = " -> {0} must not exceed  50 character")]
        [DisplayName("Full name")]
        public String fullname { get; set; }



        [Required(ErrorMessage = " -> {0} is required")]
        [MinLength(4, ErrorMessage = " -> {0}  must not be less than 2 character")]
        [MaxLength(20, ErrorMessage = " -> {0} must not exceed  20 character")]
        [DisplayName("Residence")]
        public string place { get; set; }


        [Required(ErrorMessage = " -> {0} is required")]
        [MinLength(2, ErrorMessage = " -> {0}  must not be less than 2 character")]
        [MaxLength(20, ErrorMessage = " -> {0} must not exceed  20 character")]
        [DisplayName("Job")]
        public string job { get; set; }

        //[MinLength(1, ErrorMessage = " -> {0}  must not be less than 1 ")]
        //[MaxLength(5, ErrorMessage = " -> {0} must not exceed  5")]
        //[Required]
        [Range(1, 5, ErrorMessage = "-> {0} from 1-5 ")]
        [Required(ErrorMessage = " -> {0} is required")]
        [DisplayName("Rooms number")]
        public int rooms { get; set; }


        //navigation property--------------------------------------------------------------------
        [ForeignKey("Room_Type")]
        [DisplayName("Room Type")]
        [Range(1, int.MaxValue, ErrorMessage = "select a valid department ")]
        public int Room_TypeId { get; set; }

        //navigation property-------------------
        public Room_Type Room_Type { get; set; }

        //________________________________________________________________________________________

        //____________________________________________________________
        //[Required]
        //[Range(1000, double.PositiveInfinity, ErrorMessage = "Bouns must not be less than 1000 EGP")]
        //public double Bouns { get; set; }


        //_______________________________________________________________

        [DisplayName("Phone Number 1")]
        [Column("phoneNumber1")]    
        [RegularExpression("^\\d{11}$", ErrorMessage = "Invalid phone number")]
        public string phoneNo1 { get; set; }




        //_______________________________________________________________
        [DisplayName("Phone Number 2")]
        [Column("phoneNumber2")]     
        [RegularExpression("^\\d{11}$", ErrorMessage = "Invalid phone number")]
        public string phoneNo2 { get; set; }

        //_______________________________________________________________
        [DisplayName(" National Id")]
        [Column("National_Id")]
        [RegularExpression("^\\d{14}$", ErrorMessage = "-> {0}  must be 14 numbers ")]
        public string National_Id { get; set; }



        //___________________________________________________________
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public String email { get; set; }

        //__________________________________________________________
        [DisplayName("Confirm Email")]
        [NotMapped]    /*  prevent creating a column in the database*/
        //we tell the Entity frame work do not make a colum in the database to confirmemail cuz we need it only to check  
        [Compare("email", ErrorMessage = "Email and confirm email do not match")]
        public string Confirm_Email { get; set; }

        //________________________________________________________
        [DisplayName("Password")]
        [Required]
        [DataType(DataType.Password)]  //عشان يظهر على شكلى نقط سوده 
        public string password { get; set; }

        //_____________________________________________________________________
        [DisplayName("Confirm Password")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "password and confirm password do not match")]
        public string Confirm_password { get; set; }

        //_____________________________________________________________

        [DisplayName("Reservation Time")]
        public DateTime Reservation_time { get; set; }



        [ClientAgeLegal(ErrorMessage = " illigal age , must be +18 ")]
        [DisplayName("BirthDate")]
        [DataType(DataType.Date)]
        public DateTime birthDate { get; set; }




        [DisplayName("Arriving Time")]
        public DateTime Arriving_time { get; set; }


        [DisplayName("Leaving Time")]
        public DateTime LeavingTime { get; set; }

        public DateTime creationDateTime { get; set; }
    
        
        public DateTime updateDateTime { get; set; }


        //______________________________________________________________________________________________
        //navigation property--------------------------------------------------------------------
        [ForeignKey("payment")]
        [DisplayName("Payment Methoed")]
        [Range(1, int.MaxValue, ErrorMessage = "select a valid Payment methoed ")]
        public int PaymentId { get; set; }

        //navigation property-------------------
        public payment payment { get; set; }




    }
}


    
