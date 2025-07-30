// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAddRemoveElementsPage.cs" company="Arpita Neogi">
//   Copyright (c) 2025 Arpita Neogi. All rights reserved.
//   This file contains an interface defining actions for interacting with the Add/Remove Elements page
//   used for automation testing purposes.
//   Redistribution or modification of this file is subject to author permissions.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    public interface IABTest
    {
        string GetTitle();
        string GetDescription();
        void DisableABTest();
    }
}