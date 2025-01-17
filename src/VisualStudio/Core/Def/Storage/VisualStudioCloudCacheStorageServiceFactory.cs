﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Composition;
using Microsoft.CodeAnalysis.Host;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.Storage;
using Microsoft.CodeAnalysis.Storage.CloudCache;
using Microsoft.VisualStudio.Shell;

namespace Microsoft.VisualStudio.LanguageServices.Storage
{
    [ExportWorkspaceService(typeof(ICloudCacheStorageServiceFactory), ServiceLayer.Host), Shared]
    internal class VisualStudioCloudCacheStorageServiceFactory : ICloudCacheStorageServiceFactory
    {
        private readonly IAsyncServiceProvider _serviceProvider;

        [ImportingConstructor]
        [Obsolete(MefConstruction.ImportingConstructorMessage, error: true)]
        public VisualStudioCloudCacheStorageServiceFactory(SVsServiceProvider serviceProvider)
            => _serviceProvider = (IAsyncServiceProvider)serviceProvider;

        public AbstractPersistentStorageService Create(IPersistentStorageConfiguration locationService)
            => new VisualStudioCloudCacheStorageService(_serviceProvider, locationService);
    }
}
