﻿// Copyright (c) BruTile developers team. All rights reserved. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Reflection;

namespace BruTile.MbTiles.Tests.Utilities
{
    public static class Paths
    {
        public static string AssemblyDirectory
        {
            get
            {
                var asm = typeof(Paths).GetTypeInfo().Assembly;
                return Path.GetDirectoryName(asm.Location);
            }
        }
    }
}
