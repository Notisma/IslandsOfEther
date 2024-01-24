
    public class EnemyBehaviour
    {
        public static EnemyBehaviour E;

        public EnemyData data;
        
        private void Start()
        {
            if (E == null) E = this;
            
            data = new EnemyData("Thanos");
            data.AddCard(CardsManager.cards["kitsune"]);
        }
    }