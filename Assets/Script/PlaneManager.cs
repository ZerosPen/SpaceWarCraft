using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaneManager : MonoBehaviour
{
    public PlaneDatabase planeDB;

    public Text nameText;
    public SpriteRenderer planemodel;

    private int selectedOption = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        } 
        UpdatePlane(selectedOption);
    }

   /* // Update is called once per frame
    void Update()
    {

    }
*/
    public void nextOption()
    {
        selectedOption ++;
        if (selectedOption >= planeDB.PlaneCount)
        {
            selectedOption = 0;
        }
        UpdatePlane(selectedOption);
        Save();
    }

    public void backOption()
    {
        selectedOption--;
        if (selectedOption <= 0)
        {
            selectedOption = planeDB.PlaneCount - 1;
        }
        UpdatePlane(selectedOption);
        Save();
    }


    private void UpdatePlane(int selectedOption)
    {
        Plane plane = planeDB.GetPlane(selectedOption);
        planemodel.sprite = plane.PlaneModels;
        nameText.text = plane.PlaneName;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectOption", selectedOption);
    }

    public void FlyTobattelField()
    {
        Debug.Log("Fly to battelField with Blue Aircraft...");
        SceneManager.LoadScene("Main");
    }

}
