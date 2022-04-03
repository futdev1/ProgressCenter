using ProgressCenter.Domain.Enums;
using System;

namespace ProgressCenter.Domain.Commons
{
    public interface IAuditable
    {
        public Int64 Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Int64? UpdatedBy { get; set; }

        ItemState State { get; set; }
    }
}
