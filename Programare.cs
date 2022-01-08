namespace Consultatii
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Programare")]
    public partial class Programare
    {
        [Key]
        public int Nr_ordine { get; set; }

        public int Nr_cadru { get; set; }

        public int CNP { get; set; }

        public virtual Cadru Cadru { get; set; }

        public virtual Pacient Pacient { get; set; }
    }
}
