namespace Game
{
    public class ReqStartFight
    {
       public string LevelNodeBusinessId { get; set; } = "1";
    }

    public class ResStartFight
    {
        public int Port { get; set; }
    }
}