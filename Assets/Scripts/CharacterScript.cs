using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterScript : MonoBehaviour {

	private bool _FaceGauche;
	//private CharacterController _controleur;
	private float cacheY;
	private int currentHealth;

	private int CurrentHealth
	{
		get { return currentHealth; }
		set { currentHealth = value; }
	}

	private float minXValue;
	private float maxXValue;
	public float coolDown;
	private bool onCD;

	public float maxVitesse = 10;
	public float vitesseMaxFloor = 10.0f;
	public float vitesseAit = 5.0f;

	public int maxLifePoint = 100;
	public RectTransform healthTransform;
	public Text healthText;
	public Image healthbar;

	public int Sante { get; private set; }
	public bool estMort { get; private set; }


	public void Awake()
	{
		//_FaceGauche = transform.localPosition.x > 0;
		//_controleur = GetComponent<CharacterController>();
		Sante = maxLifePoint;
	}

	// Use this for initialization
	void Start () {
		//cacheY = healthTransform.position.y;
		//maxXValue = healthTransform.position.x;
		//minXValue = healthTransform.position.x - healthTransform.rect.width;
		currentHealth = maxLifePoint;
		onCD = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!estMort)
		{
			mouvement();
		}
		
	}
	public void kill()
	{
		estMort = true;
	}

	private void HandleHealth()
	{
		healthText.text = "Santé : " + currentHealth;
		float currentXValue = mapValues(currentHealth, 0, maxLifePoint, minXValue, maxXValue);
		healthTransform.position = new Vector3(currentXValue, cacheY);
		if(currentHealth>maxLifePoint/2){
			healthbar.color = new Color32((byte)mapValues(currentHealth, maxLifePoint / 2, maxLifePoint, 255, 0), 255, 0, 255);
		}
		else
		{
			healthbar.color = new Color32(255,(byte) mapValues(currentHealth, 0, maxLifePoint / 2, 0, 255), 0, 255);
		}
	}

	public void mouvement()
	{
		float translation = maxVitesse*Time.deltaTime;
		transform.Translate(new Vector3(Input.GetAxis("Horizontal")*translation,Input.GetAxis("Vertical")*translation));
	}

	private float mapValues(float x, float inMin, float inMax, float outMin, float outMax)
	{
		return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;

	}

	IEnumerator CoolDownDmg()
	{
		onCD = true;
		yield return new WaitForSeconds(coolDown);
		onCD = false;
	}

	void onCollisionEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Ennemi"){
			if (!onCD && CurrentHealth > 0)
			{
				Debug.Log("Collision de l'objet");
				StartCoroutine(CoolDownDmg());
				DestroyObject(GameObject.Find("Ennemi"));
				this.CurrentHealth -= 10;
			}
		}
	}
}
