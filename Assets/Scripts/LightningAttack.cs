using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class LightningAttack : MonoBehaviour
{
    [SerializeField]private GameObject lightning;
    private List<GameObject> enemiesArray = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
            enemiesArray.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        for (int i = 0; i < enemiesArray.Count; i++)
            if (other.gameObject.name == enemiesArray[i].name)
                enemiesArray.Remove(enemiesArray[i]);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
            foreach (GameObject enemy in enemiesArray)
                Instantiate(lightning, enemy.transform.position, quaternion.identity);
    }
}
