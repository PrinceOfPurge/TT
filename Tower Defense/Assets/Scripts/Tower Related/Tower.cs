using UnityEngine;

namespace Tower_Related {
    public class Tower : MonoBehaviour {

        [SerializeField] private int cost = 100;
        [SerializeField] private int towerID; //Tower IDs
        [SerializeField] private int ownerPlayerID; //Player ID

        private EnemyScanner _enemyScanner;
        private Weapon _weapon;
        private bool _isHover = false;
        private PlayerHealth _playerHealth;
        public GameObject currentHealth;

        private void Awake() {
            _enemyScanner = GetComponentInChildren<EnemyScanner>();
            _weapon = GetComponent<Weapon>();

            // Initialize tower ID
            InitializeTower(1); //Replace '1' with the actual player ID
        }

        private void Start() {
            InvokeRepeating("ScanEnemies", 0f, 0.1f);
        }

        private void Update() {
            if (!_isHover && _enemyScanner.IsTargetFound()) {
                _weapon.Shoot(_enemyScanner.GetTarget());
            }
        }

        private void ScanEnemies() {
            _enemyScanner.ScanEnemiesInRange();
        }

        public void RemoveTower() {
            //Destroys tower and unregisters from TowerIDManager
            DestroyTower();
            Destroy(gameObject);
        }

        public int GetCost() {
            return cost;
        }

        public void HoverMode(bool hover) {
            _isHover = hover;
        }
        
        private void InitializeTower(int playerID) {
            ownerPlayerID = playerID;

            //Generate a unique tower ID using TowerIDManager
            towerID = TowerIDManager.Instance.GenerateUniqueTowerID();

            //Register this tower with TowerIDManager
            TowerIDManager.Instance.RegisterTower(towerID, this);
        }
        
        private void DestroyTower() {
            //Unregister this tower from TowerIDManager
            TowerIDManager.Instance.UnregisterTower(towerID);
        }

        public void TakeDamage(object damage)
        {
        }
    }
    
}
