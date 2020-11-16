using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

[Table("Pacientes")]
public class Pacientes
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int id { get; set; }

    [Column("nombre")]
    public string nombre { get; set; }

    [Column("apellidos")]
    public string apellidos { get; set; }

    [Column("usuario")]
    public string usuario { get; set; }

    [Column("clave")]
    public string clave { get; set; }

    [Column("email")]
    public string email { get; set; }

    [Column("peso")]
    public string peso { get; set; }

    [Column("altura")]
    public string altura { get; set; }

    [Column("sexo")]
    public string sexo { get; set; }

    [Column("fechaNacimiento")]
    public string fechaNacimiento { get; set; }

    //[Column("hidratacion")]
    //public bool hidratacion { get; set; }

    //[Column("hipertension")]
    //public bool hipertension { get; set; }

    //[Column("diabetes")]
    //public bool diabetes { get; set; }

    //[Column("sangre")]
    //public bool sangre { get; set; }

    [Column("id_enfermedad")]
    public int id_enfermedad { get; set; }
}