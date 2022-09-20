using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Genre
    {
        //Id icin db'de auto increment saglamak adina asagidaki attribute verilir;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}