﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LHJ.Common.Definition
{
    public class EventHandler
    {
        #region UserList Changed Event

        public delegate void SelectedUserChangedEventHandler(object sender, SelectedUserChangedEventArgs e);

        public class SelectedUserChangedEventArgs : EventArgs
        {
            public string User { get; set; }

            public SelectedUserChangedEventArgs(string aUser)
            {
                User = aUser;
            }
        }

        #endregion UserList Changed Event

        #region ObjectList Changed Event

        public delegate void SelectedObjChangedEventHandler(object sender, SelectedObjChangedEventArgs e);

        public class SelectedObjChangedEventArgs : EventArgs
        {
            public string Object { get; set; }

            public SelectedObjChangedEventArgs(string aObject)
            {
                Object = aObject;
            }
        }

        #endregion ObjectList Changed Event

        #region ItemDoubleClick Event

        public delegate void ItemDoubleClickEventHandler(object sender, ItemDoubleClickEventArgs e);

        public class ItemDoubleClickEventArgs : EventArgs
        {
            public string ItemName { get; set; }

            public ItemDoubleClickEventArgs(string aItemName)
            {
                ItemName = aItemName;
            }
        }

        #endregion ItemDoubleClick Event
    }
}
