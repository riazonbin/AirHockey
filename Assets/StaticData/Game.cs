using UnityEngine;

namespace Assets.StaticData
{
    public static class Game
    {
        public static readonly float DefaultStickSpeed = Time.deltaTime * 20;
        public static float FactStickSpeed = 30;

        public static float DefaultPuckSpeed = 20;
        public static float FactPuckSpeed = 20;

        public static readonly float DefaultPuckScale = 0.7f;
        public static readonly float DefaultStickScale = 1;
    }
}