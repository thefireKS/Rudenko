using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> spellsList = new List<GameObject>();

    [SerializeField] private KeyCode attackKey;
    [SerializeField] private KeyCode switchKey;

    private GameObject _activeSpell;
    private int _spellIndex = 0;


    private void Start()
    {
        if (spellsList.Count != 0)
            _activeSpell = spellsList[0];
    }

    private void Update()
    {
        if (spellsList.Count == 0) SendError();
        
        else
        {
            if (Input.GetKeyDown(attackKey))
                UseSpell();
            if (Input.GetKeyDown(switchKey))
                SwitchSpell();
        }
    }

    void SwitchSpell()
    {
        _spellIndex += 1 ;
        _activeSpell = spellsList[_spellIndex % spellsList.Count];
    }
    
    void UseSpell()
    {
        if (_activeSpell != null)
        {
            Instantiate(
                _activeSpell,
                transform.position,
                gameObject.transform.rotation
            );
        }

    }

    void SendError()
    {
        Debug.Log("Daun, spell dobav`");
    }
    
}
