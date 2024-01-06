namespace Legend_of_Boog.Models.Layout
{
    internal class ForestRoom
    {
        public int RoomId { get; set; }
        public string EntryDialog { get; set; } = String.Empty;
        public string EnemyClearDialog { get; set; } = String.Empty;
        public string EventClearDialog { get; set; } = String.Empty;
        public bool HasEvent { get; set; }
        public int NumOfEnemies { get; set; }
        public int FullNumofEnemies { get; set; }
        public bool HasKey { get; set; }
        public int Doors { get; set; }
        public string Door1 { get; set; } = String.Empty;
    }
}