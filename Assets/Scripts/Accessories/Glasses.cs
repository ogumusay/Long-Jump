using UnityEngine;

namespace Assets.Scripts
{
    public class Glasses : Accessory
    {

        protected override void Start()
        {
            base.Start();

            int selectedGlassesId = saveObject.selectedGlasses;
            SetButtons(selectedGlassesId, saveObject.ownedGlasses);
            if(selectedGlassesId == id)
            {
                accessoryContainer.selectedGlasses = this;
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

            saveObject.ownedGlasses.Add(id);

            WriteToSaveObject();

            SwitchButtons();
        }


        protected override void SelectAccessory(int id)
        {
            saveObject = SaveSystem.GetSaveObject();
            saveObject.selectedGlasses = id;
            string json = JsonUtility.ToJson(saveObject);
            SaveSystem.Save(json);
        }

        protected override void Equip()
        {
            accessoryContainer.selectedGlasses?.Unequip();            

            accessoryContainer.selectedGlasses = this;
            base.Equip();
        }

        protected override void Unequip()
        {
            accessoryContainer.selectedGlasses = null;
            base.Unequip();
        }

    }
}
