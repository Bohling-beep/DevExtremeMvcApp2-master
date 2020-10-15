namespace DevExtremeMvcApp2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Termine")]
    public partial class Termine
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key] public int ID { get; set; }

        [StringLength(10)]
        public string Titel { get; set; }

        [StringLength(10)]
        public string Start { get; set; }

        [StringLength(10)]
        public string Ende { get; set; }

        [StringLength(10)]
        public string Farbe { get; set; }
    }
}
