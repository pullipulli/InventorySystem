using System;
using UnityEngine.SceneManagement;

public class DeloreanItem : Item
{
    public override void UseItem(Character owner, Action DestroyCallback)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DestroyCallback();
        Destroy(gameObject);
    }
}