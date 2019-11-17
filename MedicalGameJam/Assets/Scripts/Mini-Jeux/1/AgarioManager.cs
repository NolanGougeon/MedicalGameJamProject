using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarioManager : MonoBehaviour
{
    public static AgarioManager instance;
    public int m_nbEnemy;
    public int m_nbFood;
    public GameObject pf_enemy;
    public GameObject pf_food;
    public GameObject pf_player;
    public GameObject victoryButton;
    public GameObject retryButton;
    public List<GameObject> listEnemy;
    public List<GameObject> listFood;
    public GameObject player;

    public bool isWin;
    public bool isLose;
    // Start is called before the first frame update
    void Start()
    {
        listEnemy = new List<GameObject>();
        listFood = new List<GameObject>();
        SetStaticInstance();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (listEnemy.Count == 0 && !isWin)
        {
            Victory();
            isWin = true;
        }

        if (!player && !isLose)
        {
            Defeat();
            isLose = true;
        }

    }

    public  void Victory()
    {
        Debug.Log("Victoire");
        victoryButton.SetActive(true);
    }

    public void Defeat()
    {
        Debug.Log("Défaite");
        retryButton.SetActive(true);
    }

    private void SetStaticInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Debug.Log("There are multiple AgarioManager instances");
    }

    public GameObject InstanciateObject(GameObject entity, float width, float height)
    {
        float random1 = Random.Range(0.01f, 0.99f);
        float random2 = Random.Range(0.01f, 0.99f);
        Vector2 randomVector = Camera.main.ScreenToWorldPoint(new Vector2(random1 * width, random2 * height));
        return Instantiate(entity, randomVector, Quaternion.identity);
    }

    public void Retry()
    {
        for (int i = 0; i < listEnemy.Count; i++)
        {
            Destroy(listEnemy[i]);
        }
        listEnemy.Clear();

        for (int i = 0; i < listFood.Count; i++)
        {
            GameObject food = (GameObject)listFood[i];
            listEnemy.Remove(food);
            Destroy(food);
        }

        retryButton.SetActive(false);

        Init();
    }

    public void Init()
    {
        int camHeight = Camera.main.pixelHeight;
        int camWidth = Camera.main.pixelWidth;

        player = InstanciateObject(pf_player, camWidth, camHeight);

        for (int i = 0; i < m_nbEnemy; i++)
        {
            listEnemy.Add(InstanciateObject(pf_enemy, camWidth, camHeight));
        }

        for (int i = 0; i < m_nbFood; i++)
        {
            listFood.Add(InstanciateObject(pf_food, camWidth, camHeight));
        }
    }
}
