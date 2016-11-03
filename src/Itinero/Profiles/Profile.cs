﻿// Itinero - Routing for .NET
// Copyright (C) 2016 Abelshausen Ben
// 
// This file is part of Itinero.
// 
// Itinero is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// Itinero is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Itinero. If not, see <http://www.gnu.org/licenses/>.

using Itinero.Attributes;
using System.Collections.Generic;

namespace Itinero.Profiles
{
    /// <summary>
    /// Represents a routing profile.
    /// </summary>
    public abstract class Profile
    {
        /// <summary>
        /// Gets the name of this profile.
        /// </summary>
        public abstract string Name
        {
            get;
        }

        /// <summary>
        /// Gets the profile metric.
        /// </summary>
        public abstract ProfileMetric Metric
        {
            get;
        }

        /// <summary>
        /// Gets the vehicle types.
        /// </summary>
        public abstract string[] VehicleTypes
        {
            get;
        }

        /// <summary>
        /// Get a function to calculate properties for a set given edge attributes.
        /// </summary>
        /// <returns></returns>
        public abstract FactorAndSpeed FactorAndSpeed(IAttributeCollection attributes);

        /// <summary>
        /// Returns true if the two edges with the given attributes are identical as far as this profile is concerned.
        /// </summary>
        /// <remarks>
        /// Default implementation compares attributes one-by-one.
        /// </remarks>
        public abstract bool Equals(IAttributeCollection attributes1, IAttributeCollection attributes2);

        private static Dictionary<string, Profile> _profiles;

        /// <summary>
        /// Registers a profile.
        /// </summary>
        public static void Register(Profile profile)
        {
            _profiles[profile.Name] = profile;
        }

        /// <summary>
        /// Gets a registered profiles.
        /// </summary>
        public static Profile GetRegistered(string name)
        {
            return _profiles[name];
        }

        /// <summary>
        /// Tries to get a registred profile.
        /// </summary>
        public static bool TryGet(string name, out Profile value)
        {
            return _profiles.TryGetValue(name, out value);
        }

        /// <summary>
        /// Gets all registered profiles.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Profile> GetRegistered()
        {
            return _profiles.Values;
        }
    }
}