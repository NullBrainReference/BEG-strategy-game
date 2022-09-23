using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLocker : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    public GameObject mask1;
    public GameObject mask2;
    public GameObject mask3;
    public GameObject mask4;

    public static List<int> lockNumbers = new List<int>();
    // Start is called before the first frame update
    public void LockButtons()
    {
        foreach(int i in lockNumbers)
        {
            if (i == 1)
            {
                button1.interactable = false;
                mask1.SetActive(true);
            }
            if (i == 2)
            {
                button2.interactable = false;
                mask2.SetActive(true);
            }
            if (i == 3)
            {
                button3.interactable = false;
                mask3.SetActive(true);
            }
            if (i == 4)
            {
                button4.interactable = false;
                mask4.SetActive(true);
            }
        }
        Debug.Log("LockButtons ");
    }
    public void AddLockButtom(int number)
    {
        lockNumbers.Add(number);
        Debug.Log("AddLockButtons " + number);
    }
}
