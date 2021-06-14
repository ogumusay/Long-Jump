using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Accessory : MonoBehaviour
    {
        [SerializeField] Button buyButton;
        [SerializeField] protected Button useButton;
        [SerializeField] Text costText;
        [SerializeField] protected Text useText;
        [SerializeField] protected AccessoryContainer accessoryContainer;
        protected SaveObject saveObject;
        public Sprite sprite;
        public int id;
        public new string name;
        public int cost;

        protected virtual void Start()
        {
            saveObject = SaveSystem.GetSaveObject();
            costText.text = cost.ToString();
        }

        protected void SetButtons(int selectedAccessoryId, List<int> ownedAccessories)
        {
            if (selectedAccessoryId == id)
            {
                useButton.onClick.AddListener(() => Unequip());
                useText.text = "UNEQUIP";
            }
            else
            {
                useButton.onClick.AddListener(() => Equip());
            }

            if (ownedAccessories.Contains(id))
            {
                SwitchButtons();
            }
            else
            {
                buyButton.onClick.AddListener(() => Buy());
            }
        }

        protected virtual void Equip()
        {
            SelectAccessory(id);

            useText.text = "UNEQUIP";
            useButton.onClick.RemoveAllListeners();
            useButton.onClick.AddListener(() => Unequip());
        }

        protected virtual void Unequip()
        {            
            SelectAccessory(0);

            useText.text = "EQUIP";
            useButton.onClick.RemoveAllListeners();
            useButton.onClick.AddListener(() => Equip());

        }

        protected virtual void SelectAccessory(int id)
        {

        }

        protected virtual void Buy()
        {
            

        }

        protected void SwitchButtons()
        {
            useButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
        }

        protected void WriteToSaveObject()
        {
            string json = JsonUtility.ToJson(saveObject);
            SaveSystem.Save(json);
            FindObjectOfType<CoinDisplay>().UpdateCoinDisplay();
        }
    }
}
