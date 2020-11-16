using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salud.Models
{

    [Table("Diabetes")]
    public class Diabetes
    {

        [PrimaryKey, AutoIncrement, Column("ID")]
        public int ID { get; set; }

        [Column("Fecha")]
        public string Fecha { get; set; }

        [Column("Hora")]
        public string Hora { get; set; }

        [Column("Nota")]
        public string Nota { get; set; }

        [Column("Glucosa")]
        public string Glucosa { get; set; }

        [Column("Peso")]
        public string Peso { get; set; }

        [Column("PacienteID")]
        public string PacienteID { get; set; }
    }
}
