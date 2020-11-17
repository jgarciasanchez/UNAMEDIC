using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salud.Models
{
    [Table("Hidratacion")]
    public class Hidratacion
    {

        [PrimaryKey, AutoIncrement, Column("ID")]
        public int ID { get; set; }

        [Column("Fecha")]
        public string Fecha { get; set; }

        [Column("Total")]
        public int Total { get; set; }

        [Column("PacienteID")]
        public int PacienteID { get; set; }
    }
}
