using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCharacterGeneratorController : MonoBehaviour
{
    [SerializeField] GameObject[] patientPrefab;
    [SerializeField] GameObject[] medecinPrefab;

    [SerializeField] Vector2 boundX, boundY;

    [SerializeField] float appearingFrequency;
    [SerializeField] float minFrequency;
    float nextTimeAppearing;

    [SerializeField] float medecinApparitionChance;

    public bool generate = true;

    // Start is called before the first frame update
    void Start()
    {
        nextTimeAppearing = Time.time + appearingFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        if (!generate)
            return;
        if(nextTimeAppearing <= Time.time)
        {
            GenerateTapCharacter();

            appearingFrequency -= 0.1f;
            if (appearingFrequency < minFrequency)
                appearingFrequency = minFrequency;

            nextTimeAppearing += appearingFrequency;
        }
    }

    void GenerateTapCharacter()
    {
        Vector2 appearingPos = new Vector2(Random.Range(boundX.x, boundX.y), Random.Range(boundY.x, boundY.y));
        if(Random.Range(0f,1f)<medecinApparitionChance)
        {
            Instantiate(medecinPrefab[Random.Range(0, medecinPrefab.Length)], appearingPos, Quaternion.identity);
        }
        else
        {
            Instantiate(patientPrefab[Random.Range(0, patientPrefab.Length)], appearingPos, Quaternion.identity);
        }
    }
}
