using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject menuPrincipal;
	public GameObject menuGameOver;
	
	public float velocidad = 2;
	public GameObject col;
	public GameObject piedra1;
	public GameObject piedra2;
	public Renderer fondo;
	public bool gameOver = false;
	public bool start = false;
	
	public List<GameObject> cols;
	public List<GameObject> obstaculos;
    // Start is called before the first frame update
    void Start()
    {
		// Crear Mapa (Personalizado)
        for (int i=0; i<33; i++)
		{
			cols.Add(Instantiate(col, new Vector2(-15 + i,-6), Quaternion.identity));
		}
		
		//Crear Piedras (Personalizado)
		obstaculos.Add(Instantiate(piedra1, new Vector2(14,-4), Quaternion.identity));
		obstaculos.Add(Instantiate(piedra2, new Vector2(25,-4), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
		if (start == false)
		{
			if (Input.GetKeyDown(KeyCode.X))
			{
				start = true;
			}
		}
		
		if (start == true && gameOver == true)
		{
			menuGameOver.SetActive(true);
			
			if (Input.GetKeyDown(KeyCode.X))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
		
        if (start == true && gameOver == false)
		{
			menuPrincipal.SetActive(false);
			
			fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;
    
			//Mover Mapa (Personalizado)
			for (int i=0; i < cols.Count; i++)
			{
				if (cols[i].transform.position.x <= -15)
				{
				cols[i].transform.position = new Vector3(15, -6, 0);
				}
			
				cols[i].transform.position = cols[i].transform.position + new Vector3(-2,0,0) * Time.deltaTime * velocidad;
			}
		
			//Mover Piedras (Personalizado)
			for (int i=0; i < obstaculos.Count; i++)
			{
				if (obstaculos[i].transform.position.x <= -15)
				{
					float randomObs = Random.Range(11, 18);
					obstaculos[i].transform.position = new Vector3(randomObs, -4, 0);
				}
			
				obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-2,0,0) * Time.deltaTime * velocidad;
			}
		}
	}
}
