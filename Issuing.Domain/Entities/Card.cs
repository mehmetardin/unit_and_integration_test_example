namespace Issuing.Domain.Entities
{
    public class Card : EntityBase<int>
    {
        public long Guid { get; set; }

        public short Status { get; set; }

        public long LastUpdated { get; set; }

        public short MemberId { get; set; }

        public string Bin { get; set; }

        public long BinRangeGuid { get; set; }

        public string CardNo { get; set; }
        public bool IsExpired { get; set; }
    }
}
