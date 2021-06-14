using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    [Serializable]
    public class SaveObject
    {
        public int totalGoldAmount;

        public UpgradeSaveObject doubleJump = new UpgradeSaveObject();

        public UpgradeSaveObject chargeSpeed = new UpgradeSaveObject();

        public UpgradeSaveObject jumpSpeed = new UpgradeSaveObject();

        public List<int> ownedGlasses = new List<int>();

        public int selectedGlasses;

        public List<int> ownedHats = new List<int>();

        public int selectedHat;

        public List<int> unlockedLevels = new List<int> { 1 };

        public List<int> levelStars = new List<int> { 0 };
    }
}
