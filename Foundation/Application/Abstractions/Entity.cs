using System;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Application.Abstractions
{
    public class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }
        // public DateTime CreatedAt { get; set; }
        // public DateTime UpdatedAt { get; set; }
    }
}
