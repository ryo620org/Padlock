using UnityEngine;
using UnityEngine.UI;

public class NumberView : MonoBehaviour
{
    public void ChangeNumber(int newNumber)
    {
        GetComponent<Text>().text = newNumber.ToString();
    }
}