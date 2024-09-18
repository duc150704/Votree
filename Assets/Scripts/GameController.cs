using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Player player;
    private UIManager ui;
    [SerializeField] private Enermy enermy;

    [SerializeField] float SpawnTime;
    private float spawnTime;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        ui = FindObjectOfType<UIManager>();

        ui.SetData("Velocity : " + 0);
    }

    private void Update()
    {
        ShowData();
        SpawnEnermy();
    }

    public void ShowData()
    {
        ui.SetData("Velocity : " );
    }

    private void SpawnEnermy()
    {
        Vector3 spawnPos = new Vector3(5, 5, 0);
        spawnTime -= Time.deltaTime;
        if (spawnTime < 0 && enermy)
        {
            Enermy newEnermy = Instantiate(enermy, player.transform.position + spawnPos, Quaternion.identity);
            Destroy(newEnermy.gameObject,10f);
            spawnTime = SpawnTime;  
        }
    }

}
