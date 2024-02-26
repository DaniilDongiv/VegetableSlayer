using System;
using Controller;
using Scriptable_Objects;
using Systems;
using UnityEngine;
using View;

namespace Bonuses
{
    public class BonusController : MonoBehaviour
    {
        [SerializeField]
        private ItemSettings _itemSettings;
        
        private GameObject _player;
        private TimerSystem _timerSystem;
        private BonusView _bonusView;

        private void Awake()
        {
            _timerSystem = FindObjectOfType<TimerSystem>();
            _player = GameObject.Find("Player");
            _bonusView = FindObjectOfType<BonusView>();
        }
        private Action[] GetArrayMethods()
        {
            return new Action[]
            {
                TimerTimeChange,
                PlayerDamageIncrease,
                HealthChange
            };
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                var randomNumber = RandomNumberGenerator.RandomNumber(0, GetArrayMethods().Length, false);
                GetArrayMethods()[randomNumber].Invoke();
                _bonusView.SetBonus(_itemSettings.Name[randomNumber]);
                Destroy(gameObject);
            }
        }

        private void PlayerDamageIncrease()
        {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            _player.GetComponentInChildren<AttackController>().ChangingDamage(10,10000);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private void HealthChange()
        {
            _player.GetComponent<HealthController>().HealthChange(RandomNumberGenerator.RandomNumber(15,45, true));
        }

        private void TimerTimeChange()
        {
            _timerSystem.GetConfigGameTimeModel().RemainingTime += RandomNumberGenerator.RandomNumber(5,10, true);;
        }
    }
}
