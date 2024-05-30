using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;

public class ButtonControl : MonoBehaviour
{
    public SpriteRenderer lockSprite;
    public Sprite lockImage;

    public GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ButtonActive();
            DoorOpeningMovement();
        }
    }

    public void ButtonActive()
    {
        lockSprite.sprite = lockImage;
        GetComponent<MeshRenderer>().material.color = Color.green;
        transform.DOLocalMoveY(0.1f, 0.5f);
    }

    public void DoorOpeningMovement()
    {
        door.transform.DOMoveY(-1, 2);
    }
}
