using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Factory : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    private DiContainer Dicontainer;
    [Inject]
    public void Construct(DiContainer container)
    {
        Dicontainer = container;
    }
    private void Start()
    {
        CreatePlayer();
    }
    public void CreatePlayer()
    {
        Dicontainer.InstantiatePrefab(Player);
    }
}
