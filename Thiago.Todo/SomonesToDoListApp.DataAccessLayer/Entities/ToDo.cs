﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SomeonesToDoListApp.DataAccessLayer.Entities
{
   [Table("ToDo")]
   public class ToDo 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string ToDoItem { get; set; }
    }
}
