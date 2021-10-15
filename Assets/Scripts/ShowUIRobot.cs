using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUIRobot : MonoBehaviour
{
    /* Alexander Iniguez October 2021
     * show UI of robot who collcion with the mouse pointer
     * each robot*
     */

    /* Al tocar
     * prender ui 
     * pasar la info propietaria del robot 
     *  
     * 
     * Al salir 
     * apagar el ui
     * 
     */
    public string name;
    public int energy;

    public Canvas can;

    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // The mesh goes red when the mouse is over it...
    void OnMouseEnter()
    {
        rend.material.color = Color.red;
    }

    // ...the red fades out to cyan as the mouse is held over...
    void OnMouseOver()
    {
        rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
    }

    // ...and the mesh finally turns white when the mouse moves away.
    void OnMouseExit()
    {
        rend.material.color = Color.white;
    }
}
