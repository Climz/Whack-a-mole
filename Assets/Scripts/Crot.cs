using UnityEngine;
using System.Collections;

public class Crot : MonoBehaviour{
    public CrotManager cm;
    public Crot crot;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteListDead;
    public Sprite[] spriteListAlive;
    public AudioClip[] ouchList;
    public AudioSource audioSource;
    public AudioListener audioListener;
    public float lifeTime = 1;
    public float timer = 0;
    public bool isAlive = true;
    
    void Start(){
        if(FindObjectOfType<Stats>().hitCount <= 5){
            lifeTime = 3;
        }
        else if (FindObjectOfType<Stats>().hitCount <= 10){
            lifeTime = 2.5f;
        }
        else if (FindObjectOfType<Stats>().hitCount <= 15){
            lifeTime = 2;
        }
        else if (FindObjectOfType<Stats>().hitCount <= 20){
            lifeTime = 1.5f;
        }
        else if (FindObjectOfType<Stats>().hitCount <= 25){
            lifeTime = 1;
        }
        else if (FindObjectOfType<Stats>().hitCount <= 30){
            lifeTime = .8f;
        }
        else{
            lifeTime = .6f;
        }
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteListAlive[Random.Range(0,spriteListAlive.Length)];
        audioListener = GetComponent<AudioListener>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = .2f;
        cm = FindObjectOfType<CrotManager>();
    }

    void Update(){
        if (isAlive){
            timer += Time.deltaTime;
            if (timer >= lifeTime){
                Destroy(gameObject);       
                FindObjectOfType<Stats>().missed++;
            }
        }
        else{
            timer += Time.deltaTime;
            if (timer >= lifeTime){
                Destroy(gameObject);
            }
        }
    }

    void OnMouseDown() {
        if(isAlive){
            FindObjectOfType<Stats>().hitCount++;
            spriteRenderer.sprite = spriteListDead[Random.Range(0,spriteListDead.Length)];
            audioSource.clip = ouchList[Random.Range(0, ouchList.Length)];
            audioSource.Play();
            isAlive = false;
        }
    }
}
