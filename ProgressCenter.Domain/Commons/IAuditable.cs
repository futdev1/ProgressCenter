using ProgressCenter.Domain.Enums;
using System;

namespace ProgressCenter.Domain.Commons
{
    public interface IAuditable
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        ItemState State { get; set; }
    }
}
