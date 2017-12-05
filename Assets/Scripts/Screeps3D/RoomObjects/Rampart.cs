﻿using UnityEngine;

namespace Screeps3D
{
    /*{
      "_id": "5a14926e0f5eb600014edf87",
      "type": "rampart",
      "x": 14,
      "y": 4,
      "room": "E1S2",
      "notifyWhenAttacked": true,
      "user": "5a0da017ab17fd00012bf0e7",
      "hits": 12698420,
      "hitsMax": 300000000,
      "nextDecayTime": 1164543
    }*/
    public class Rampart : Structure, IOwnedObject, IDecay
    {
        public string UserId { get; set; }
        public ScreepsUser Owner { get; set; }
        public float NextDecayTime { get; set; }

        internal override void Unpack(JSONObject data, bool initial)
        {
            base.Unpack(data, initial);
            UnpackUtility.Owner(this, data);
            UnpackUtility.Decay(this, data);
        }

    }
}