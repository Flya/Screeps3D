﻿using Common;
using UnityEngine;

namespace Screeps3D.RoomObjects.Views
{
    public class SourceKeeperLairView : MonoBehaviour, IObjectViewComponent, IMapViewComponent
    {
        public const string Path = "Prefabs/RoomObjects/keeperLair";
        
        [SerializeField] private ScaleVisibility _vis;
        private SourceKeeperLair _sourceKeeperLair;
        

        public void Init()
        {
        }
        
        public void Load(RoomObject roomObject)
        {
            _sourceKeeperLair = roomObject as SourceKeeperLair;
        }

        public void Delta(JSONObject data)
        {
        }

        public void Unload(RoomObject roomObject)
        {
        }
        
        // IMapViewComponent *****************
        public int roomPosX { get; set; }
        public int roomPosY { get; set; }
        public void Show()
        {
            _vis.Show();
        }
        public void Hide()
        {
            _vis.Hide();
        }
    }
}