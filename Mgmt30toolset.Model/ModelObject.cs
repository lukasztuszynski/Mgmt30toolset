using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.Triggers;

namespace Mgmt30toolset.Model
{
    public abstract class ModelObject
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("UserCreatedId")]
        public User UserCreated { get; set; }
        [ForeignKey("UserUpdatedId")]
        public User UserUpdated { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }


        static ModelObject()
        {
            Triggers<ModelObject>.Inserting += entry => entry.Entity.DateCreated = entry.Entity.DateUpdated = DateTime.UtcNow;
            Triggers<ModelObject>.Updating += entry => entry.Entity.DateUpdated = DateTime.UtcNow;
            Triggers<ModelObject>.Deleting += entry => {
                entry.Entity.DateDeleted = DateTime.UtcNow;
                entry.Cancel = true; // Cancels the deletion, but will persist changes with the same effects as EntityState.Modified
            };
        }
    }
}
