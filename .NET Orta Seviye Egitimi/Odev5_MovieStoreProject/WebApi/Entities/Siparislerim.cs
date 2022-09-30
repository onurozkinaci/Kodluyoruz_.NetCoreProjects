using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Siparislerim
    {   
       public int CustomerId {get;set;}
       public Customer Customer { get; set; }
       public int FilmId {get;set;}
       public Film Film { get; set; }
       public double Fiyat { get; set; }
       public DateTime SatinAlmaTarihi { get; set; }
       public bool IsActive { get; set; } = true; //Satin alinan filmler silinirken bu false olarak guncellenebilir, hard sekilde siparis datasi silinmemeli!
    }
}