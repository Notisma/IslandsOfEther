using System.Collections;
using Combat;
using Combat.Turns;
using Data;
using UnityEngine;

namespace Manager
{
    public static class BattleManager
    {
        private static Turn currentTurn;

        private static bool battleOver;

        private static void InitializeBattle(WielderData enemyData)
        {
            EnemyBehaviour.I().data = enemyData;

            PlayerBehaviour.I.childCards.OrderDeck();

            currentTurn = new PlayerTurn(); // le joueur commence toujours

            battleOver = false;

            Debug.Log("battle start !");
        }

        public static IEnumerator BattleLoop(WielderData enemyData)
        {
            InitializeBattle(enemyData);
            
            while (!battleOver)
            {
                yield return JouerTour();

                currentTurn = currentTurn.GetNextTurn();
            }

            yield return null;
        }

        private static IEnumerator JouerTour()
        {
            MonoBehaviour.print(currentTurn.TurnText());

            yield return new WaitForSeconds(2);

/*            if (currentTurn.GetWielderData().GetNbUnplacedCards() <= 0 &&
                currentTurn.GetWielderData().GetNbPlacedCards() <= 0)
            {
                EndBattle();
                return;
            }

            if (currentTurn.GetWielderData().GetNbUnplacedCards() > 0 &&
                currentTurn.GetWielderData().GetNbPlacedCards() < 3)
            {
                currentTurn.PlaceCard();
            }

            if (currentTurn.GetWielderData().GetNbPlacedCards() > 0)
            {
                Card cardAtk = currentTurn.ChooseAtkCard();
                Card cardDef = currentTurn.ChooseOppoCard();
                currentTurn.Attack(cardAtk, cardDef);
            }
            */
        }

        private static void EndBattle()
        {
            Debug.Log("fini combat");
            BigManager.I.StartCoroutine(SceneLoader.Load(SceneLoader.previousScene));
            PlayerBehaviour.I.GetNewCard(CardsManager.GetRandomCard().id);
        }
    }
}