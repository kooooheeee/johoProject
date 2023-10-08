using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagazineText : MonoBehaviour
{
    public Text magazine;
    public GameObject player;
    public Text cursorMagazine;

    private int max;
    private int zandan;

    Weapon playerWeapon;

    void Start()
    {
        playerWeapon = player.GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        max = playerWeapon.maxMagazine;
        zandan = playerWeapon.magazine;

        magazine.text = zandan + " / " + max;
    }
}
