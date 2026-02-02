namespace Game.Share
{
    public class SamuraiDTO
    {
        public int Id { get; set; }
        public  string BusinessId { get; set; }

        public  string SoldierBusinessId { get; set; }
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;      
        
        public int CurHp { get; set; }
    }
}