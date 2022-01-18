using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlateformSpawner : MonoBehaviour
{
    public GameObject plateformWithCoins3;
    public GameObject plateformWithCoins5;
    public GameObject plateformWithCoins7;
    public GameObject plateform;

    public GameObject gameMenu;


    public float minTimeToSpawn = 1.0f;
    public float maxTimeToSpawn = 1.5f;

    private float _nextSpawnTime = 0.0f;
    private float _lastPlateformPositionY = 0.0f;

    private GameObject _toSpawn;

    private void Start()
    {
        _nextSpawnTime = minTimeToSpawn;
    }

    void ChoosePlateform()
    {
        float sizeX = 0.0f;
        switch (Random.Range(0, 5))
        {
            case 1:
                sizeX = 3;
                break;
            case 2:
                sizeX = 5;
                break;
            case 3:
                sizeX = 7;
                break;
            case 4:
                switch (Random.Range(0, 4))
                {
                    case 1:
                        _toSpawn = plateformWithCoins3;
                        break;
                    case 2:
                        _toSpawn = plateformWithCoins5;
                        break;
                    case 3:
                        _toSpawn = plateformWithCoins7;
                        break;
                }

                return;
        }

        _toSpawn = plateform;
        _toSpawn.transform.localScale = new Vector3(sizeX, 1, 1);
    }

    private bool gameMenuIsHide()
    {
        return !gameMenu.activeSelf;
    }
    void Update()
    {
        if (Time.time > _nextSpawnTime && gameMenuIsHide())
        {
            ChoosePlateform();
            Vector3 position = transform.position;
            _toSpawn.transform.position =
                new Vector3(position.x, _lastPlateformPositionY, position.z);
            Instantiate(_toSpawn);
            _nextSpawnTime = Time.time + minTimeToSpawn;

        }
    }
}