namespace Issuing.Application.Dto.Card
{
    public class CardCreateResponse
    {
        public int Id { get; set; }
        public string Bin { get; set; }
        public string CardNo { get; set; }
        public short Status { get; set; }
        public bool IsExpired { get; set; }
    }
}
