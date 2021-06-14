using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    
    public class ChargeSpeed : Upgrade
    {
        private const int UPGRADE_COST = 10;
        private const int UPGRADE_MAX_LEVEL = 9;
        public const float CHARGE_RATE_PER_LEVEL = 0.5f;

        public void Start()
        {
            upgradeMaxLevel = UPGRADE_MAX_LEVEL;

            base.Start();
        }

        public override void GetUpgradeLevelFromSaveObject()
        {
            saveObject = SaveSystem.GetSaveObject();
            upgradeSaveObject = saveObject.chargeSpeed;
            upgradeLevel = upgradeSaveObject.upgradeLevel;
            upgradeCost = UPGRADE_COST * (upgradeLevel + 1);
        }

        protected override void WriteToSaveObject()
        {
            saveObject.chargeSpeed = upgradeSaveObject;
            base.WriteToSaveObject();
        }

        protected override void SetUpgradeCostText()
        {
            upgradeCost = UPGRADE_COST * (upgradeLevel + 1);
            base.SetUpgradeCostText();
        }
    }
}
