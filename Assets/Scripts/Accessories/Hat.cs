using UnityEngine;

namespace Assets.Scripts.Accessories
{
    public class Hat : Accessory
    {

        protected override void Start()
        {
            base.Start();

            int selectedHatId = saveObject.selectedHat;
            SetButtons(selectedHatId, saveObject.ownedHats);
            if (selectedHatId == id)
            {
                accessoryContainer.selectedHat = this;
            }
        }

        protected override void Buy()
        {
            saveObject = SaveSystem.GetSaveObject();

            int totalCoin = saveObject.totalGoldAmount;

            if (cost <= totalCoin)
            {
                saveObject.totalGoldAmount = totalCoin - cost;
            }
            else
            {
                return;
            }

            saveObject.ownedHats.Add(id);

            WriteToSaveObject();

            SwitchButtons();
        }    

        protected override void SelectAccessory(int id)
        {
            saveObject = SaveSystem.GetSaveObject();
            saveObject.selectedHat = id;
            string json = JsonUtility.ToJson(saveObject);
            SaveSystem.Save(json);
        }

        protected override void Equip()
        {
            accessoryContainer.selectedHat?.Unequip();

            accessoryContainer.selectedHat = this;
            base.Equip();
        }

        protected override void Unequip()
        {
            accessoryContainer.selectedHat = null;
            base.Unequip();
        }
    }
}
