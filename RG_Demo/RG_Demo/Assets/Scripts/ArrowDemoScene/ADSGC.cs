using UnityEngine;

/// <summary>
/// Arrow Demo Scene Game Controller;
/// </summary>
public class ADSGC : MonoBehaviour
{
    public static ADSGC IS { get; private set; }

    private void Awake()
    {
        IS = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        BindInputs();
        SpawnArrow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        UnBindInputs();
    }

    #region Public methods;

    public void StartArrow()
    {
        if (ADSRC.IS.ArrowGroup_SCR == null) { return; }
        ADSRC.IS.ArrowGroup_SCR.StartArrow(InputHandler.IS.MousePosition);
    }

    public void EndArrow()
    {
        if (ADSRC.IS.ArrowGroup_SCR == null) { return; }
        ADSRC.IS.ArrowGroup_SCR.EndArrow();
    }

    #endregion

    #region Private methods;

    private void BindInputs()
    {
        InputHandler.IS.MouseLeftDown += StartArrow;
        InputHandler.IS.MouseLeftUp += EndArrow;
    }

    private void UnBindInputs()
    {
        InputHandler.IS.MouseLeftDown -= StartArrow;
        InputHandler.IS.MouseLeftUp -= EndArrow;
    }

    private void SpawnArrow()
    {
        Transform arrow_group_TRANS = Instantiate(ADSRC.IS.ArrowGroup_Prefab,
            Vector3.zero, Quaternion.identity, ADSRC.IS.Canvas_TRANS).transform;
        ADSRC.IS.ArrowGroup_SCR = arrow_group_TRANS.GetComponent<ArrowGroup>();
        arrow_group_TRANS.GetComponent<ArrowGroup>().
            InitAG(GS.IS.ArrowSettings_Prefab.GetComponent<ArrowSettings>());
    }

    #endregion

    private void Test1()
    {
        Vector3 startp = Vector3.zero;
        Vector3 endp = new Vector3(1.0f, 1.0f, 0.0f);
        Vector3 p1p = startp + Vector3.Scale((endp - startp), new Vector3(-0.3f, 0.8f));
        Vector3 p2p = startp + Vector3.Scale((endp - startp), new Vector3(0.1f, 1.4f));
        Vector3 pos = new Vector3();
        for(int i = 0;i<6;++i)
        {
            pos = Utilities.BCubeCurveCal(1, 3, 3, 1, startp, p1p, p2p, endp, (float)i / (float)6);
            Debug.Log(pos);
        }
    }
}
