using System.Collections.Generic;
using UnityEngine;

public class SpellSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> spellsList;

    [SerializeField] private KeyCode attackKey;
    [SerializeField] private KeyCode switchKey;

    private int _spellIndex;

    private void Start()
    {
        if (spellsList.Count == 0) SendError();
    }

    private void Update()
    {
        if(Input.GetKeyDown(attackKey))
            UseSpell();
        if(Input.GetKeyDown(switchKey))
            SwitchSpell();
    }

    private void SwitchSpell()
    {
        _spellIndex += 1;
        _spellIndex %= spellsList.Count;
    }

    private void UseSpell()
    {
        Quaternion spellRotation = transform.localScale.x > 0 ? transform.rotation : new Quaternion(0f, 0f, 180f,0f);
        Instantiate(
            spellsList[_spellIndex],
            transform.position,
            spellRotation);
    }

    void SendError()
    {
        Debug.Log("WARNING: 0 spells was added to the list!");
    }
    
}
