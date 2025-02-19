﻿// Copyright (c) BruTile developers team. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace BruTile.Wmts
{
    /// <summary>
    /// A set of scales
    /// </summary>
    internal class ScaleSet
    {
        /// <summary>
        /// The items
        /// </summary>
        private readonly ScaleSetItem[] _items;

        /// <summary>
        /// Creates an instance for this class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="crs"></param>
        /// <param name="items"></param>
        public ScaleSet(string name, CrsIdentifier crs, IEnumerable<ScaleSetItem> items)
        {
            Name = name;
            Crs = crs;
            _items = items.ToArray();
        }

        /// <summary>
        /// Gets the Crs identifier for this scale set
        /// </summary>
        public CrsIdentifier Crs { get; }

        /// <summary>
        /// Gets a value indicating the name of the scale set
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public ScaleSetItem this[int level] => _items[level];

        /// <summary>
        /// Accessor to a pixel size
        /// </summary>
        /// <param name="scaleDenominator"></param>
        /// <returns></returns>
        public double? this[double scaleDenominator]
        {
            get
            {
                foreach (var item in _items)
                {
                    if (Math.Abs(scaleDenominator - item.ScaleDenominator) < 1e-7)
                    {
                        return item.PixelSize;
                    }
                    if (item.ScaleDenominator < scaleDenominator) break;
                }

                return null;
            }
        }
    }
}
