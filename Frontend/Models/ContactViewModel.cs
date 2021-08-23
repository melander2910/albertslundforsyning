using System;
using AlbertslundForsyning.Entities;
using System.Collections.Generic;

namespace AlbertslundForsyning.Models
{
    public class ContactViewModel : BaseViewModel
    {
        public string SenderName {get; set;}
        public string SenderEmail {get; set;}
        public string SenderPhoneNumber {get; set;}
        public string SenderSubject {get; set;}
        public string SenderMessage {get; set;}   
    }
}