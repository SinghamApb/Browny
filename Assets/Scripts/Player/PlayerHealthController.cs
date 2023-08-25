using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
   

    [SerializeField] private float immortalTime;
    [SerializeField] private float immortalCounter;
    [SerializeField] private int  _maxHealth;

    private SpriteRenderer _theSR;
    public int _currentHealth;
    private UIController uiController;
   
   
    void Start()
    {
        _currentHealth = _maxHealth;
      
        _theSR = GetComponent<SpriteRenderer>();
        uiController = FindObjectOfType<UIController>();
    }
    private void Update()
    {
        if(immortalCounter > 0)
        {
            immortalCounter -= Time.deltaTime;

            if(immortalCounter <= 0)
            {
                _theSR.color = new Color(_theSR.color.r, _theSR.color.g, _theSR.color.b, 1f);
            }

        }


    }


    public void DealDamage()
    {

        if (immortalCounter <= 0)
        {
            _currentHealth--;

            if (_currentHealth <= 0)
            {
                if (_currentHealth < 0)
                    _currentHealth = 0;
                GameManager.Instance.GameOver();
               
      
            }
            else
            {
                immortalCounter = immortalTime;
                _theSR.color = new Color(_theSR.color.r, _theSR.color.g, _theSR.color.b, 0.5f);
            }

            uiController.UpdateHealthUI();
        }
    }

   


}
