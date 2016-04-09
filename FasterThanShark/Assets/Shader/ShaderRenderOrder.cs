using UnityEngine;
using System.Collections.Generic;


public class ShaderRenderOrder : MonoBehaviour
{
    public int renderQueueValue = 2002;



    void Start()
    {
        Renderer[] renders = GetComponentsInChildren<Renderer>();
        foreach (var x in renders)
        {
            x.material.renderQueue = renderQueueValue;
        }
    }
}
/*    function Start(){
      // get all renderers in this object and its children:
      var renders = GetComponentsInChildren(Renderer);
      for (var rendr: Renderer in renders){
        rendr.material.renderQueue = 2002; // set their renderQueue
      }
    }*/
