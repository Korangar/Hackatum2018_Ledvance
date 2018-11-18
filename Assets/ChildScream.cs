using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;
using UnityEngine;

public class ChildScream : MonoBehaviour
{
    public void Trigger()
    {
        var lm = LayerMask.GetMask(new string[]{"IoT"});
        var cols = Physics.OverlapSphere(transform.position, 3, lm );
        var fons = 
            from c in cols
            let fon = c.GetComponent<IoTSensorBabyfon>()
            where fon != null
            select fon;

        fons.ForEach(f => f.Trigger());
    }
}
