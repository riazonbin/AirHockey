using UnityEngine;

namespace Assets.StaticData
{
    public static class Game
    {
        public static readonly float DefaultStickSpeed = 20;
        public static float FactStickSpeed = 20;

        public static float DefaultPuckSpeed = 20;
        public static float FactPuckSpeed = 20;

        public static readonly float DefaultPuckScale = 0.7f;
        public static readonly float DefaultStickScale = 0.7f;

        private static int _difficulty = 1;
        public static int Difficulty
        {
            get => _difficulty;
            set
            {
                _difficulty = value;
                TimeSpan = value switch
                {
                    0 => (5, 10),
                    1 => (3, 6),
                    2 => (1, 2),
                    _ => throw new System.NotImplementedException()
                };
            }
        }
        public static (int, int) TimeSpan;
    }
}