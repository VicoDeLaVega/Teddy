using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelection : MonoBehaviour {

    public List<Button> itemsButtons;
    public List<bool> itemsSelected;
    public List<Sprite> availableSprites;
    public List<Image> imagesOnScreen;
    public Sprite BlankSprite;
    public void UpdateImages()
    {
        for (int i = 0; i < imagesOnScreen.Count; i++)
        {
            imagesOnScreen[i].sprite = BlankSprite;
        }

        int currentImageDest = 0;
        for (int i = 0; i < itemsSelected.Count; i++)
        {
            if (itemsSelected[i] == true)
            {
                imagesOnScreen[currentImageDest].sprite = availableSprites[i];
                currentImageDest++;
            }
        }
    }

    public void SelectItem(int i)
    {
        
        ColorBlock cb = new ColorBlock();
        if (itemsSelected[i])
        {
            cb.normalColor = Color.red;
            cb.highlightedColor = Color.red;
            cb.colorMultiplier = 1;
            itemsButtons[i].colors = cb;// temsButtons[0].colors.pressedColor;
            itemsSelected[i] = false;
        }
        else
        {
            cb.normalColor = Color.green;
            cb.highlightedColor = Color.blue;
            cb.colorMultiplier = 1;
            itemsButtons[i].colors = cb;// temsButtons[0].colors.pressedColor;
            itemsSelected[i] = true;
        }
        UpdateImages();
    }
    public void SelectItem0()  { SelectItem(0); }

	// Use this for initialization
	void Start () {
        UpdateImages();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
