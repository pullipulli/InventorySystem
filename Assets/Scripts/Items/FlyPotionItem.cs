using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyPotionItem : Item
{
    public override void UseItem(Character owner, Action DestroyCallback)
    {
        owner.GetComponent<Rigidbody>().AddForce(owner.transform.up * 10f, ForceMode.Impulse);

        DestroyCallback();
        Destroy(gameObject);
    }
}