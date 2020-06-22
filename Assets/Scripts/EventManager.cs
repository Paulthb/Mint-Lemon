using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> spawnerPosList = null;

    [SerializeField]
    private List<Transform> acidDropPosList = null;

    [SerializeField]
    private List<GameObject> AcidDropList = null;

    #region Singleton Pattern
    private static EventManager _instance;

    public static EventManager Instance { get { return _instance; } }
    #endregion

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);

        else
            _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            AcidDrop();
    }

    public void AcidDrop()
    {
        int randSpawnerId = Random.Range(0, spawnerPosList.Count);
        int randAcidDropObject = Random.Range(0, 0);//pour l'instant


    }
}
