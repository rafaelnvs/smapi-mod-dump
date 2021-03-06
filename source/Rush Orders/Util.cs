﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RushOrders
{
    // Copied from SpaceCore
    // TODO: Add SC as a dependency instead
    public class Util
    {
        // Stolen from SMAPI
        public static void invokeEvent(string name, IEnumerable<Delegate> handlers, object sender)
        {
            var args = new EventArgs();
            foreach (EventHandler handler in handlers.Cast<EventHandler>())
            {
                try
                {
                    handler.Invoke(sender, args);
                }
                catch (Exception e)
                {
                    Log.error($"Exception while handling event {name}:\n{e}");
                }
            }
        }

        public static void invokeEvent<T>(string name, IEnumerable<Delegate> handlers, object sender, T args)
        {
            foreach (EventHandler<T> handler in handlers.Cast<EventHandler<T>>())
            {
                try
                {
                    handler.Invoke(sender, args);
                }
                catch (Exception e)
                {
                    Log.error($"Exception while handling event {name}:\n{e}");
                }
            }
        }
    }
}
