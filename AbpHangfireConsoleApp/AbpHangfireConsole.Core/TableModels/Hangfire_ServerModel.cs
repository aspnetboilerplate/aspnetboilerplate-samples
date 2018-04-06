using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace AbpHangfireConsole.Core.TableModels
{
    // ReSharper disable once InconsistentNaming
    /// <summary>
    ///     Simple POCO encapsulating the Hangfire.Server table in the database
    /// </summary>
    [Table("Server", Schema = "Hangfire")]
    public class Hangfire_ServerModel : IEntity<string>
    {
        public string Data { get; set; }

        [Required]
        public DateTime LastHeartbeat { get; set; }

        /// <summary>
        ///     Checks if this entity is transient (not persisted to database and it has not an
        ///     <see cref="P:Abp.Domain.Entities.IEntity`1.Id" />).
        /// </summary>
        /// <returns>True, if this entity is transient</returns>
        public bool IsTransient()
        {
            return EqualityComparer<string>.Default.Equals(Id, default(string));
        }

        /// <summary>Unique identifier for this entity.</summary>
        [Key]
        public string Id { get; set; }
    }
}