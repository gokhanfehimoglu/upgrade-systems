using DG.Tweening;
using TMPro;
using UnityEngine;

namespace MiniUpgradeSystem
{
    public class Entity : MonoBehaviour
    {
        [SerializeField]
        private string id;

        [SerializeField]
        private float price;

        [SerializeField]
        private float productionTime;

        [SerializeField]
        private TMP_Text priceText;

        [SerializeField]
        private TMP_Text productionTimeText;

        [SerializeField]
        private Transform machine;

        private float _initialMachineScale;

        private void Start()
        {
            _initialMachineScale = machine.localScale.x;
            StartMachineAnimation();
            UpdateBubble();
        }

        public void UpdateBubble()
        {
            priceText.SetText(UpgradeManager.ApplyUpgrade(id, price, UpgradeType.Price) + "");
            productionTimeText.SetText(
                UpgradeManager.ApplyUpgrade(id, productionTime, UpgradeType.ProductionTime) + "s");
        }

        private void StartMachineAnimation()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(machine.DOScale(Vector3.one * (_initialMachineScale + 0.15f), 1f).SetEase(Ease.InOutQuad));
            sequence.Append(machine.DOScale(_initialMachineScale, 1f).SetEase(Ease.InOutQuad));
            sequence.SetLoops(-1, LoopType.Restart);
        }

        public string GetId()
        {
            return id;
        }
    }
}