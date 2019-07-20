using UnityEngine;
using UnityEngine.UI;

public class LockView : MonoBehaviour
{
    [SerializeField] private Sprite unlockSprite;
    
    private Image Image
    {
        get
        {
            if (_image == null) _image = GetComponent<Image>();
            return _image;
        }
    }

    private Image _image;
    
    public void ChangeUnlock()
    {
        Image.sprite = unlockSprite;
    }
}