using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Player player;
    private UIManager ui;
    int a = 0;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        ui = FindObjectOfType<UIManager>();

        ui.SetData("Velocity : " + 0);
    }

    private void Update()
    {
        a = a + 1;
        ShowData();
    }

    public void ShowData()
    {
        ui.SetData("Velocity : " + a);
    }

}
