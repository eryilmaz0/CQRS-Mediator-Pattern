using System;
using System.ComponentModel.DataAnnotations;

namespace SolidPractices.Entities.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime Created { get;}



        public EntityBase()
        {
            //ENTİTYBASE SINIFINDAN MİRAS HERHANGİ BİR SINIFIN INSTANCE'I OLUŞTURULDUĞUNDA,
            //OTOMATİK OLARKA TARİHİ ATA
            this.Created = DateTime.Now;
        }
    }
}