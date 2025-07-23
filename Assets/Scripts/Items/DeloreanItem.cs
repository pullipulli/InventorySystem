using UnityEngine.SceneManagement;

public class DeloreanItem : Item
{
    public override void UseItem()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}