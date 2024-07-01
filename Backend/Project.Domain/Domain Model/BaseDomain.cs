using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain
{
    public class BaseDomain
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [DataType(DataType.DateTime)]
        public DateTime CreaterdAt { get; set; } = DateTime.UtcNow;

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }
}
