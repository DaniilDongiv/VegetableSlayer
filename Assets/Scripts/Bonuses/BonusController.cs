using System;
using Controller;
using Player;
using Systems;
using UnityEngine;
using View;

namespace Bonuses
{
    public class BonusController : MonoBehaviour
    {
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
                ReducingTimerTime,
                BoostTimerTime,
                PlayerDamageIncrease,
                SlowingDownPlayer,
                HealthChange
            };
        }

        private string[] GetArrayBonusText()
        {
            return new[]
            {
                "-ВРЕМЯ",
                "+ВРЕМЯ",
                "+УРОН",
                "ЗАМЕДЛИЛСЯ ИГРОК",
                "+-ЗДОРОВЬЕ"
            };
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                var randomNumber = RandomNumberGenerator.RandomNumber(0, GetArrayMethods().Length, false);
                GetArrayMethods()[randomNumber].Invoke();
                _bonusView.SetBonus(GetArrayBonusText()[randomNumber]);
                Destroy(gameObject);
            }
        }

        private void PlayerDamageIncrease()
        {
            _player.GetComponentInChildren<AttackController>().StartCoroutineIncreasedDamage();
        }
        
        private void ReducingTimerTime()
        {
            _timerSystem.GetConfigGameTimeModel().RemainingTime -= 10;
        }

        private void HealthChange()
        {
            _player.GetComponent<HealthController>().HealthChange(RandomNumberGenerator.RandomNumber(-15,45, true));
        }

        private void SlowingDownPlayer()
        {
            _player.GetComponent<PlayerController>().StartCoroutineSlowingDownSpeed();
        }

        private void BoostTimerTime()
        {
            _timerSystem.GetConfigGameTimeModel().RemainingTime += 10;
        }
    }
}
