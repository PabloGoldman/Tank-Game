using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Ball Data")]
    public class BallsData : ScriptableObject
    {
        public float speedTowardsTank;

        public float upDownSpeed;
    }
}

