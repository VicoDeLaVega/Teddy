using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSelection : MonoBehaviour {

    public List<Button> itemsButtons;
    public List<bool> itemsSelected;
    public List<Sprite> availableSprites;
    public List<Image> imagesOnScreen;
    public Sprite BlankSprite;
    public List<int> imageList; 
    public void UpdateImages()
    {
        for (int i = 0; i < imagesOnScreen.Count; i++)
        {
            imagesOnScreen[i].sprite = BlankSprite;
        }
        for (int i = 0; i < imageList.Count; i++)
        {
            int idx = imageList[i];
            imagesOnScreen[i].sprite = availableSprites[idx];
        }
        //int currentImageDest = 0;
        //for (int i = 0; i < itemsSelected.Count; i++)
        //{
        //    if (itemsSelected[i] == true)
        //    {
        //        imagesOnScreen[currentImageDest].sprite = availableSprites[i];
        //        currentImageDest++;
        //    }
        //}
    }

    public void SelectItem(int i)
    {
        
        ColorBlock cb = new ColorBlock();
        if (itemsSelected[i]  )
        {
            cb.normalColor = Color.red;
            cb.highlightedColor = Color.red;
            cb.colorMultiplier = 1;
            itemsButtons[i].colors = cb;// temsButtons[0].colors.pressedColor;
            itemsSelected[i] = false;
            imageList.Remove(i);
        }
        else
        {
            if (imageList.Count >= 4)
            {
                Debug.Log("Too many towers");
                return;
            }
            cb.normalColor = Color.green;
            cb.highlightedColor = Color.blue;
            cb.colorMultiplier = 1;
            itemsButtons[i].colors = cb;// temsButtons[0].colors.pressedColor;
            itemsSelected[i] = true;
            imageList.Add(i);
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

    public void Ok()
    {
        SceneManager.LoadScene(2);
    }
}
