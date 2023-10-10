using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MiniUpgradeSystem
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField]
        private Image backgroundImage;

        [SerializeField]
        private Transform upgradePanel;

        public void OpenUpgradePanel()
        {
            backgroundImage.DOFade(0.5f, .2f);
            upgradePanel.DOScale(Vector3.one, .2f);
            backgroundImage.raycastTarget = true;
        }

        public void CloseUpgradePanel()
        {
            backgroundImage.DOFade(0f, .2f);
            upgradePanel.DOScale(Vector3.zero, .2f);
            backgroundImage.raycastTarget = false;
        }
    }
}