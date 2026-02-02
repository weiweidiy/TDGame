namespace Game.Share
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string ItemBusinessId { get; set; } = string.Empty;
        public int Count { get; set; } = 1;
        public int BagSlotId { get; set; }
    }
}