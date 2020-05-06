using System;
using Screeps3D.RoomObjects;
using Screeps_API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screeps3D.Tools.Selection.Subpanels
{
    public class ReservedPanel : LinePanel
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private Image _badge;

        private RoomObject _roomObject;
        private IReserved _reservedObject;
        public override string Name
        {
            get { return "Reserved"; }
        }

        public override Type ObjectType
        {
            get { return typeof(IOwnedObject); }
        }

        public override bool IsPanelAvailabelForObject(RoomObject roomObject)
        {
            return roomObject.Type.Equals(Constants.TypeController);
        }

        public override void Load(RoomObject roomObject)
        {
            _roomObject = roomObject;
            _reservedObject = roomObject as IReserved;
            ScreepsAPI.OnTick += OnTick;
            UpdateLabel();
        }

        private void UpdateLabel()
        {
            if (_reservedObject.ReservedBy == null)
            {
                this.Hide();
                return;
            }
            this.Show();
            _label.text = string.Format("{0}({1:n0})",_reservedObject.ReservedBy.Username , _reservedObject.ReservationEnd - _reservedObject.Room.GameTime);
            _badge.sprite = Sprite.Create(_reservedObject.ReservedBy.Badge,
                    new Rect(0.0f, 0.0f, BadgeManager.BADGE_SIZE, BadgeManager.BADGE_SIZE), new Vector2(.5f, .5f));
        }

        private void OnTick(long obj)
        {
            
            UpdateLabel();
        }

        public override void Unload()
        {
            ScreepsAPI.OnTick -= OnTick;
            _roomObject = null;
            _reservedObject = null;
        }
    }
}