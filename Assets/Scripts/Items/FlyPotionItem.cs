using System;
using UnityEngine;


public class FlyPotionItem : Item
{
    [SerializeField] private float _jumpForce = 10f;
    public override void UseItem(Character owner, Action DestroyCallback)
    {
        owner.GetComponent<Rigidbody>().AddForce(owner.transform.up * _jumpForce, ForceMode.Impulse);

        DestroyCallback();
        Destroy(gameObject);
    }
}