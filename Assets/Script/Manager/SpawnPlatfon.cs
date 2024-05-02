using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatfon : MonoBehaviour
{
    [SerializeField]
    private GameObject BluePlane;
    [SerializeField]
    private GameObject GaryPlane;
    [SerializeField]
    private GameObject BlackPlane;
    [SerializeField]
    private bool TakeOffBlue = false;
    [SerializeField]
    private bool TakeOffGary = false;
    [SerializeField]
    private bool TakeOffBlack = false;

    private MainMenu _mainmenusc;
    // Start is called before the first frame update
    void Start()
    {
        _mainmenusc = GetComponent<MainMenu>();
    }
    // Update is called once per frame
    void Update()
    {
        if (TakeOffBlue == true)
        {
            BluePlane.SetActive(true);
            Instantiate(BluePlane);
        }
        if (TakeOffGary == true)
        {
            GaryPlane.SetActive(true);
            Instantiate(GaryPlane);
        }
        if (TakeOffBlack == true)
        {
            BlackPlane.SetActive(true);
            Instantiate(BluePlane);
        }
    }

    public void takeoffblue()
    {
        TakeOffBlue = true;
    }

    public void takeoffgray()
    {
        TakeOffGary = true;
    }

    public void takeoffblack()
    {
        TakeOffBlack = true;
    }
}
