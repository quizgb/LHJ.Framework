using System;
using System.Collections;
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

        public delegate void SelectedObjListChangedEventHandler(object sender, SelectedObjListChangedEventArgs e);

        public class SelectedObjListChangedEventArgs : EventArgs
        {
            public string Object { get; set; }

            public SelectedObjListChangedEventArgs(string aObject)
            {
                Object = aObject;
            }
        }

        public delegate void SelectedObjChangedEventHandler(object sender, SelectedObjChangedEventArgs e);

        public class SelectedObjChangedEventArgs : EventArgs
        {
            public Hashtable Ht { get; set; }

            public SelectedObjChangedEventArgs(Hashtable aHt)
            {
                Ht = aHt;
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

        #region ServerListDoubleClick Event

        public delegate void ServerListDoubleClickEventHandler(object sender, ServerListDoubleClickEventArgs e);

        public class ServerListDoubleClickEventArgs : EventArgs
        {
            public object ServerListParam { get; set; }

            public ServerListDoubleClickEventArgs(object aServerListParam)
            {
                ServerListParam = aServerListParam;
            }
        }

        #endregion ServerListDoubleClick Event
    }
}
