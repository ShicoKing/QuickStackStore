﻿using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace QuickStackStore
{
    public static class Extensions
    {
        public static unsafe InventoryGrid GetPlayerGrid(this InventoryGui instance)
        {
            return Extensions._playerGrid.Invoke(instance);
        }

        public static unsafe GameObject GetDragGo(this InventoryGui instance)
        {
            return Extensions._m_dragGo.Invoke(instance);
        }

        public static unsafe ZNetView GetNView(this Container instance)
        {
            return Extensions._m_nview.Invoke(instance);
        }

        public static unsafe Container GetCurrentContainer(this InventoryGui instance)
        {
            return Extensions._m_currentContainer.Invoke(instance);
        }

        public static bool XAdd<T>(this List<T> instance, T item)
        {
            if (instance.Contains(item))
            {
                instance.Remove(item);
                return false;
            }

            instance.Add(item);
            return true;
        }

        internal static readonly AccessTools.FieldRef<InventoryGui, InventoryGrid> _playerGrid = AccessTools.FieldRefAccess<InventoryGui, InventoryGrid>("m_playerGrid");
        internal static readonly AccessTools.FieldRef<InventoryGui, GameObject> _m_dragGo = AccessTools.FieldRefAccess<InventoryGui, GameObject>("m_dragGo");
        internal static readonly AccessTools.FieldRef<Container, ZNetView> _m_nview = AccessTools.FieldRefAccess<Container, ZNetView>("m_nview");
        internal static readonly AccessTools.FieldRef<InventoryGui, Container> _m_currentContainer = AccessTools.FieldRefAccess<InventoryGui, Container>("m_currentContainer");
    }
}