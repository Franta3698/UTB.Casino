using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Casino.Domain.Entities.Interfaces;


namespace UTB.Casino.Domain.Entities;

public class Entity<TKey> : IEntity<TKey>
{
        public TKey Id { get; set; }
}




