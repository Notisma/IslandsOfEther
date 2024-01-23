
public class Tour
{
    void EndBattle()
    {
        SceneLoader.Load(SceneLoader.previousScene);
        PlayerBehaviour.P.isEnabled = true;
        PlayerBehaviour.P.data.AddCard(CardsManager.GetRandomCard());
    }
}