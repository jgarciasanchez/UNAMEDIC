using SQLite;
using System;

namespace Salud.Models
{

    [Table("Item")]
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}