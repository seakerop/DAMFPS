using UnityEngine;
using UnityEngine.InputSystem;



public class Shooting : MonoBehaviour
{
    [SerializeField] private float damage = 10;
    [SerializeField] private float range = 100;
    [SerializeField] private ParticleSystem sparkEffect;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private AudioClip pewSound;
    private AudioSource m_AudioSource;


    private InputAction shootAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        shootAction = InputSystem.actions.FindAction("Attack");




    }
    private void OnDisable()
    {
       
            shootAction.performed -= OnShootPerformed;
        
    }

    private void OnEnable()
    {
        shootAction.performed += OnShootPerformed;

    }

    private void OnShootPerformed (InputAction.CallbackContext context) 
    {
        Fire();
    }

    private void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {

            m_AudioSource.PlayOneShot(m_AudioSource.clip);

            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(impactGo, 1);
        }
    }

}
