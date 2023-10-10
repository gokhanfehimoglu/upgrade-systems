using TMPro;
using UnityEngine;

namespace MiniUpgradeSystem
{
    public class UpgradeItemUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text titleText;

        [SerializeField]
        private TMP_Text descriptionText;

        [SerializeField]
        private CustomButton selectButton;

        [SerializeField]
        private Color activeColor;

        [SerializeField]
        private Color passiveColor;

        [SerializeField]
        private Sprite activeIcon;

        [SerializeField]
        private Sprite passiveIcon;

        private UpgradeItem _upgradeItem;
        private bool _isActive;
        private SystemType _type;

        public void SetUpgradeItem(SystemType type, UpgradeItem upgradeItem)
        {
            _type = type;
            _upgradeItem = upgradeItem;
            Refresh();
        }

        public void ActionButtonClicked()
        {
            SetIsActive(!_isActive);
        }

        private void SetIsActive(bool isActive)
        {
            _isActive = isActive;
            Refresh();
            UpgradeManager.OnUpgradeItemStatusChange(_type, _upgradeItem, _isActive);
        }

        private void Refresh()
        {
            titleText.SetText(_upgradeItem.Title);
            descriptionText.SetText("description");
            selectButton.SetColor(_isActive ? passiveColor : activeColor);
            selectButton.SetIcon(_isActive ? passiveIcon : activeIcon);
        }
    }
}