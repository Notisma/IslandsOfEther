using System.Collections;
using Combat;
using Combat.Layout;
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

            BigManager.I.alliedCardsContainer.CreateCardObjects(PlayerBehaviour.I.data.cards, true);
            BigManager.I.opponentCardsContainer.CreateCardObjects(EnemyBehaviour.I().data.cards, false);
            
            BigManager.I.alliedCardsContainer.OrderDeck();
            BigManager.I.opponentCardsContainer.OrderDeck();

            currentTurn = new PlayerTurn(); // le joueur commence toujours

            battleOver = false;

            Debug.Log("Battle engaged against " + enemyData.name + " !");
        }

        public static IEnumerator BattleLoop(WielderData enemyData)
        {
            InitializeBattle(enemyData);

            while (!battleOver)
            {
                yield return JouerTour();

                currentTurn = currentTurn.GetNextTurn();
            }

            EndBattle();
        }

        private static IEnumerator JouerTour()
        {
            MonoBehaviour.print(currentTurn.TurnText());
            CardsContainer container = currentTurn.GetCardsContainer();

            if (container.GetNbDeckedCards() <= 0 &&
                container.GetNbPlacedCards() <= 0)
            {
                battleOver = true;
                yield break;
            }

            if (container.GetNbDeckedCards() > 0 &&
                container.GetNbPlacedCards() < 3)
            {
                Debug.Log(currentTurn + " needs to place a new card (unplaced = " + container.GetNbDeckedCards() + " and placed = " +
                          container.GetNbPlacedCards() + ")...");
                yield return currentTurn.PlaceCard();
            }

            if (container.GetNbPlacedCards() > 0)
            {
                Debug.Log(currentTurn + " needs to choose an attacking card...");
                Card cardAtk = null;
                yield return currentTurn.ChooseAtkCard(
                    card => { cardAtk = card; }
                );

                Debug.Log(currentTurn + " needs to choose an defending card...");
                Card cardDef = null;
                yield return currentTurn.ChooseOppoCard(
                    card => { cardDef = card; }
                );

                if (cardDef != null)
                {
                    Debug.Log(currentTurn + " is attacking !");
                    currentTurn.Attack(cardAtk, cardDef);
                }
            }

            yield return new WaitForSeconds(2);
        }

        private static void EndBattle()
        {
            Debug.Log("Combat terminé !");
            BigManager.I.StartCoroutine(SceneLoader.Load(SceneLoader.previousScene));
            PlayerBehaviour.I.GetNewCard(CardsManager.GetRandomCard().id);
        }
    }
}