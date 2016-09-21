using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
    public int MaxHealth = 10;
    public int health;
    public Slider slider;
    public float speed;
	public float tilt;
	public Done_Boundary boundary;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public bool damaged;
    public Image Fill;
    public Color MaxHealthColor = Color.green;
    public Color MinHealthColor = Color.red;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;

    void Start ()
    {
        
    }
	
	void Update ()
	{
		if ((Input.GetButtonUp("Fire1") || Input.GetKeyDown(KeyCode.Space)) && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
        //if (damaged)
        //{
        //    damageImage.enabled = true;
        //    damageImage.color = flashColour;
        //}
        //else
        //{
        //    damageImage.enabled = false;
        //    damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        //}
        //damaged = false;
    }

    void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Bolts")
        {
            damaged = true;
            health--;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
            slider.value = health;
            Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)health / MaxHealth);
        }
    }
}
