using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class DoubleJump : Upgrade
    {
        private const int UPGRADE_COST = 250;
        private const int UPGRADE_MAX_LEVEL = 1;

        public void Start()
        {
            upgradeCost = UPGRADE_COST;
            upgradeMaxLevel = UPGRADE_MAX_LEVEL;

            base.Start();
        }

        public override void GetUpgradeLevelFromSaveObject()
        {
            saveObject = SaveSystem.GetSaveObject();
            upgradeSaveObject = saveObject.doubleJump;
            upgradeLevel = upgradeSaveObject.upgradeLevel;
        }

        protected override void WriteToSaveObject()
        {
            saveObject.doubleJump = upgradeSaveObject;
            base.WriteToSaveObject();
        }
    }
}
