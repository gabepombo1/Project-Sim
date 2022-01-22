using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{

        [SerializeField] public float health;
        [SerializeField] public float mana;
        [SerializeField] public long level;
        [SerializeField] public float exp;
        [SerializeField] public float morale;
        [SerializeField] public float attack;
        //have accuracy be between 1.5 and 0 and have it multiply the missIncrement in Interactions
        //to actually create an accuracy effect
        [SerializeField] public float accuracy;
        [SerializeField] public int ammunition;

        public void SetLevel(long setLevel)
        {

            level = setLevel;

        }

        public long GetLevel()
        {

            return level;

        }

        public void SetMana(float setMana)
        {

            mana = setMana;

        }

        public float GetMana()
        {

            return mana;

        }
        public void SetHealth(float setHealth)
        {

            health = setHealth;

        }
        public float GetHealth()
        {

            return health;

        }
        public void SetAttack(float setAttack)
        {

            attack = setAttack;

        }

        public float GetAttack()
        {

            return attack;

        }
        
        public void SetMorale(float setMorale)
        {

            morale = setMorale;

        }

        public float GetMorale()
        {

            return morale;

        }
    
        public void SetExperience(float setExp)
        {

            exp = setExp;

        }

        public float GetExperience()
        {

            return exp;

        }

        public void SetAmmunition(int inputAmmunition)
        {

            ammunition = inputAmmunition;

        }

        public int GetAmmunition()
        {

            return ammunition;

        }


}
