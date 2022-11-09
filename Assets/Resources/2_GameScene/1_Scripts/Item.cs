using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    int nDirect;
    int nItemKind;
    int nItemSpawnTime;

    void Start()
    {
        nItemSpawnTime = Random.Range(15, 31);
    }

    void Update()
    {

    }

    void ItemSetting()
    {
        nDirect = Random.Range(0, 8);
        //nItemKind = Random.Range(?, ?);

        switch(nDirect)
        {
            case 0:
                // 상
                break;
            case 1:
                // 하
                break;
            case 2:
                // 좌
                break;
            case 3:
                // 우
                break;
            case 4:
                // 좌상
                break;
            case 5:
                // 좌하
                break;
            case 6:
                // 우상
                break;
            case 7:
                // 우하
                break;
        }
    }
}
