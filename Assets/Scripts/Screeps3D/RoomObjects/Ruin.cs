﻿using Screeps_API;
using Screeps3D.RoomObjects.Views;
using UnityEngine;

namespace Screeps3D.RoomObjects
{
    /**
     * {
	        "_id": "5e91a19d3a405e7d83c5462d",
	        "type": "ruin",
	        "room": "W14S36",
	        "x": 17,
	        "y": 6,
	        "structure": {
		        "id": "5e91894e3d05c456772035b9",
		        "type": "rampart",
		        "hits": 0,
		        "hitsMax": 3E+08,
		        "user": "2"
	        },
	        "destroyTime": 2,
	        396669E+07,
	        "decayTime": 2,
	        403374E+07,
	        "user": "2",
	        "store": {}
        }

     */
    public class Ruin : PlaceHolderRoomObject /*OwnedStoreStructure*/, ICooldownObject, IDecay
    {
        public float NextDecayTime { get; set; }

        public float Cooldown { get; set; }

        public string StructureId { get; set; }
        public string StructureType { get; set; }
        ////public string StructureUserId { get; set; }
        ////public ScreepsUser StructureOwner { get; set; }

        public float DestroyTime { get; set; }

        internal override void Unpack(JSONObject data, bool initial)
        {
            if (data.keys.Count == 0)
            {
                return;
            }

            base.Unpack(data, initial);

            UnpackUtility.Cooldown(this, data);
            UnpackUtility.Decay(this, data);

            var destroyData = data["destroyTime"];

            if (destroyData != null)
            {
                this.DestroyTime = data["destroyTime"].n;
            }

            var structure = data["structure"];

            if (structure != null)
            {
                UnpackUtility.HitPoints(this, structure);

                var structureIdData = structure["_id"];
                if (structureIdData != null)
                {
                    this.StructureId = structureIdData.str;
                }

                var structureTypeData = structure["type"];
                if (structureTypeData != null)
                {
                    this.StructureType = structureTypeData.str;
                }

                UnpackUtility.Owner(this, structure);
                //var userData = structure["user"];
                //if (userData != null)
                //{
                //    this.StructureUserId = userData.str;
                //    this.StructureOwner = ScreepsAPI.UserManager.GetUser(userData.str);
                //}
            }
        }

        protected internal override void AssignView()
        {
            if (Shown && View == null)
            {
                var type = this.Type;

                this.Type = this.StructureType;

                // TODO: switch on structure type and depending on what other structures are present, hide them?

                View = ObjectViewFactory.Instance.NewView(this);

                this.Type = type;

                if (View)
                {
                    View.Load(this);
                }
            }
        }
    }
}