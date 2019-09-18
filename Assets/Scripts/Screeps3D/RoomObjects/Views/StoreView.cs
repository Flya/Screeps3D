﻿using Common;
using UnityEngine;

namespace Screeps3D.RoomObjects.Views
{
    public class StoreView : MonoBehaviour, IObjectViewComponent
    {
        [SerializeField] private ScaleVisibility _storeDisplay;

        private IStoreObject _storeObject;

        public void Init()
        {
        }

        public void Load(RoomObject roomObject)
        {
            _storeObject = roomObject as IStoreObject;
            AdjustScale();
        }

        public void Delta(JSONObject data)
        {
            AdjustScale();
        }

        public void Unload(RoomObject roomObject)
        {
        }

        private void AdjustScale()
        {
            _storeDisplay.SetVisibility(_storeObject.TotalResources / _storeObject.TotalCapacity);
        }
    }
}