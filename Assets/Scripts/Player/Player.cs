using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    [Header("Set Health and Progress")]
    [SerializeField]
    private float _currHealth;
    [SerializeField]
    private float _currProgress;

    private float dotDam;
    private float hotHeal;
    private bool doDOT;
    private bool doHOT;

    [Header("Infection")]
    [SerializeField]
    private float _infectionProgress;
    [SerializeField]
    private float infectionAmount;
    [SerializeField]
    private float recoveryAmount;
    private bool beingInfected;

    private float prevHealth;
    private float prevProgress;

    [SerializeField]
    private GameObject barrier;

    [HideInInspector]
    public TimeHandler timeHandler;
    private BacteriaHandler bacteriaHandler;

    private Image image;

    //PROPERTIES
    public float CurrHealth { get { return _currHealth; } set { _currHealth = value; } }
    public float CurrProgress { get { return _currProgress; } set { _currProgress = value; } }
    public float DOTDam { get { return dotDam; } set { dotDam = value; } }
    public float HOTDam { get { return hotHeal; } set { hotHeal = value; } }
    public bool DoDOT { get { return doDOT; } set { doDOT = value; } }
    public bool DoHOT { get { return doHOT; } set { doHOT = value; } }

    
    //Events for Changes In Health & Progress
    //This Events run and are used in HealthChanged
    //and ProgressChanged
    public event EventHandler OnHealthChange, OnProgressChange;



    //This is the function that will run when event is fired
    //Add Functions to this function if want to run during
    //Health Change
    public void HealthChanged()
    {
        if (_currHealth > prevHealth || _currHealth < prevHealth)
        {
            OnHealthChange?.Invoke(this, EventArgs.Empty);
        }
    }


    //This is the function that will run when event is fired
    //Add Functions to this function if want to run during
    //Progress Change
    public void ProgressChanged()
    {
        if (_currProgress > prevProgress || _currProgress < prevProgress)
        {
            OnProgressChange?.Invoke(this, EventArgs.Empty);
        }
    }

    void Awake()
    {
        timeHandler = FindObjectOfType<TimeHandler>();
        bacteriaHandler = FindObjectOfType<BacteriaHandler>();
        image = FindObjectOfType<AnimateOverlay>().gameObject.GetComponent<Image>();
    }

    void Start() { }

    #region Interface Functions
    public void Heal(float healAmount)
    {
        prevHealth = _currHealth;
        _currHealth += healAmount;
        if (_currHealth >= 100) _currHealth = 100;
    }

    public void Damage(float damageAmount)
    {
        prevHealth = _currHealth;
        _currHealth -= damageAmount;
        if (_currHealth <= 0) _currHealth = 0;
    }

    public void DOT(bool doDOT)
    {
        if (doDOT)
        {
            prevHealth = _currHealth;
            _currHealth -= dotDam * Time.deltaTime;
        }
        else
        {
            dotDam = 0;
        }
    }

    public void HOT(bool doHOT)
    {
        if (doHOT)
        {
            prevHealth = _currHealth;
            _currHealth += hotHeal * Time.deltaTime;
        }
        else
        {
            hotHeal = 0;
        }
    }

    public void ProgressIncrease(float increaseProgress, float cap)
    {
        prevProgress = _currProgress;
        _currProgress += increaseProgress;
        if (_currProgress >= cap) _currProgress = cap;
    }

    public void ProgressDecrease(float decreaseProgress)
    {
        prevProgress = _currProgress;
        _currProgress -= decreaseProgress;
        if (_currProgress <= 0) _currProgress = 0;
    }
    #endregion

    public void EnableBarrier()
    {
        barrier.SetActive(true);
    }

    public void DisableBarrier()
    {
        barrier.SetActive(false);
    }

    public void SetHealth(float healthSet)
    {
        _currHealth = healthSet;
    }

    void Infection()
    {
        if (beingInfected)
        {
            _infectionProgress += infectionAmount * Time.deltaTime;
            
            if(_infectionProgress >= 100)
            {
                _infectionProgress = 100;
            }
        }
        else 
        {
            _infectionProgress -= recoveryAmount * Time.deltaTime;
            if(_infectionProgress <= 0)
            {
                _infectionProgress = 0;
            }
        }
        image.color = Color.Lerp(Color.black, Color.magenta,_infectionProgress/100);
    }

    void Update()
    {
        DOT(doDOT);
        HOT(doHOT);

        HealthChanged();
        ProgressChanged();

        Infection();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Infected")
        {
            beingInfected = true;
            if(_infectionProgress >= 100)
            {
                if (bacteriaHandler.BacteriaCount() > 25) { return; }
                bacteriaHandler.SpawnBacteria(bacteriaHandler.BacteriaCount());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Infected")
        {
            beingInfected = false;
        }
    }
}