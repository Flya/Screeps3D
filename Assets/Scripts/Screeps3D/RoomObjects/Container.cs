﻿using System.Collections.Generic;

namespace Screeps3D.RoomObjects
{
    /*{
      "_id": "5a0f1cadcd842f00014a8007",
      "type": "container",
      "x": 16,
      "y": 38,
      "room": "E2S7",
      "notifyWhenAttacked": true,
      "energy": 62,
      "energyCapacity": 2000,
      "hits": 225000,
      "hitsMax": 250000,
      "nextDecayTime": 8858
    }*/

    public class Container : StoreStructure
    {
        internal override void Unpack(JSONObject data, bool initial)
        {
            base.Unpack(data, initial);
        }
    }
}