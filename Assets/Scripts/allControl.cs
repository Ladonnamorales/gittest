using UnityEngine;

public class allControl : MonoBehaviour
{
    public class GameManager
    {
        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManager();
                return _instance;
            }
        }

        public int score = 0;
    }
}
