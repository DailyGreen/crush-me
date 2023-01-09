using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMng : MonoBehaviour
{
    public GameObject ItemPre;

    int nDirect;
    int nItemKind;
    int nItemSpawnTime;

    void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    // 가로 -3.3 ~ 3.3
    // 세로 -6 ~ 6
    GameObject ItemSpawn()
    {
        Vector2 ItemSpawnPos = Vector2.zero;
        Vector2 ItemDestination;
        float speed;

        //nItemKind = Random.Range(?, ?);
        nDirect = Random.Range(0, 4);
        speed = Random.Range(0.5f, 1.1f);
        switch (nDirect)
        {
            case 0:
                // 상
                ItemSpawnPos = new Vector2(Random.Range(-3.3f, 3.3f), 6.0f);
                break;
            case 1:
                // 하
                ItemSpawnPos = new Vector2(Random.Range(-3.3f, 3.3f), -6.0f);
                break;
            case 2:
                // 좌
                ItemSpawnPos = new Vector2(-3.3f, Random.Range(-6.0f, 6.0f));
                break;
            case 3:
                // 우
                ItemSpawnPos = new Vector2(3.3f, Random.Range(-6.0f, 6.0f));
                break;
        }
        ItemDestination = ItemSpawnPos * -1;            // 생성위치의 반대편으로 생성
        SGameMng.I.isMult = false;
        return ItemSetting(ItemSpawnPos, ItemDestination, speed).gameObject;
    }

    Item ItemSetting(Vector2 spawnpos, Vector2 destination, float speed)
    {
        Item temp = Instantiate(ItemPre, spawnpos, Quaternion.identity, transform).GetComponent<Item>();
        temp.destination = destination;
        temp.speed = speed;
        return temp;
    }

    IEnumerator SpawnDelay()
    {
        nItemSpawnTime = Random.Range(15, 31);
        yield return new WaitForSeconds(nItemSpawnTime);
        SGameMng.I.isMult = true;
        Destroy(ItemSpawn(), 5.0f);
        StartCoroutine(SpawnDelay());
    }
}
