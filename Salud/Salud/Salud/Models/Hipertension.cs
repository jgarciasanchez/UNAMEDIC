using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salud.Models
{
    [Table("Hipertension")]
    public class Hipertension
    {

        [PrimaryKey, AutoIncrement, Column("ID")]
        public int ID { get; set; }

        [Column("Fecha")]
        public string Fecha { get; set; }

        [Column("Hora")]
        public string Hora { get; set; }

        [Column("Nota")]
        public string Nota { get; set; }
        [Column("Color")]
        public string Color { get; set; }

        [Column("picSistolico")]
        public string picSistolico { get; set; }

        [Column("picDiastolico")]
        public string picDiastolico { get; set; }

        [Column("picPulso")]
        public string picPulso { get; set; }

        [Column("PacienteID")]
        public int PacienteID { get; set; }
    }
}
