using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class AccessoryApplier : MonoBehaviour
    {
        [SerializeField] GameObject playerGlasses;
        [SerializeField] GameObject playerHat;
        SaveObject saveObject;

        private void Start()
        {
            saveObject = SaveSystem.GetSaveObject();
            WearGlasses();
            WearHat();
        }

        private void WearGlasses()
        {
            int id = saveObject.selectedGlasses;
            string path = "Sprites/Accessories/Glasses/" + id.ToString();
            Sprite sprite = Resources.Load<Sprite>(path);
            if (id != 0)
            {
                playerGlasses.GetComponent<SpriteRenderer>().sprite = sprite;
            }
            else
            {
                playerGlasses.GetComponent<SpriteRenderer>().sprite = null;
            }
        }

        private void WearHat()
        {
            int id = saveObject.selectedHat;
            string path = "Sprites/Accessories/Hats/" + id.ToString();
            Sprite sprite = Resources.Load<Sprite>(path);
            if (id != 0)
            {
                playerHat.GetComponent<SpriteRenderer>().sprite = sprite;
            }
            else
            {
                playerHat.GetComponent<SpriteRenderer>().sprite = null;
            }
        }
    }
}
 