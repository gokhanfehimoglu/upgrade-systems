using UnityEngine;

namespace MiniUpgradeSystem
{
    public class UpgradePanelUI : MonoBehaviour
    {
        [SerializeField]
        private UpgradeItemUI itemPrefab;

        [SerializeField]
        private GameObject iapTabPanel;

        [SerializeField]
        private GameObject iapContent;

        [SerializeField]
        private GameObject skinTabPanel;

        [SerializeField]
        private GameObject skinContent;

        private void Start()
        {
            foreach (var iapUpgradeItem in UpgradeManager.Instance.GetIapUpgradeItems())
            {
                var uiItem = Instantiate(itemPrefab, iapContent.transform);
                uiItem.SetUpgradeItem(SystemType.Iap, iapUpgradeItem);
            }

            foreach (var skinUpgradeItem in UpgradeManager.Instance.GetSkinUpgradeItems())
            {
                var uiItem = Instantiate(itemPrefab, skinContent.transform);
                uiItem.SetUpgradeItem(SystemType.Skin, skinUpgradeItem);
            }
        }

        public void OnIapTabClick()
        {
            skinTabPanel.SetActive(false);
            iapTabPanel.SetActive(true);
        }

        public void OnSkinTabClick()
        {
            iapTabPanel.SetActive(false);
            skinTabPanel.SetActive(true);
        }
    }
}