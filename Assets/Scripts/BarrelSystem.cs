using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarrelSystem : MonoBehaviour
{
    public GameObject clickSprite;
    public GameObject player;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                print(hit.transform.gameObject.name);
                if (hit.transform.gameObject == clickSprite)
                {
                    player.SetActive(true);
                    clickSprite.SetActive(false);

                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            player.transform.position=clickSprite.transform.position;
            clickSprite.SetActive(true);
            other.gameObject.SetActive(false);
          
        }
    }

}