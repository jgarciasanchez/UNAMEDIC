using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salud.Models
{
    [Table("Sangre")]
    public class Sangre
    {

        [PrimaryKey, AutoIncrement, Column("ID")]
        public int ID { get; set; }

        [Column("Fecha")]
        public string Fecha { get; set; }

        [Column("PacienteID")]
        public int PacienteID { get; set; }
    }
}
