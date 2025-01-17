﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Completion;
using Microsoft.CodeAnalysis.Options;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.ExternalAccess.OmniSharp.Completion
{
    internal static class OmniSharpCompletionService
    {
        [Obsolete("Use the other overload")]
        public static Task<(CompletionList? completionList, bool expandItemsAvailable)> GetCompletionsAsync(
            this CompletionService completionService,
            Document document,
            int caretPosition,
            CompletionTrigger trigger = default,
            ImmutableHashSet<string>? roles = null,
            OptionSet? options = null,
            CancellationToken cancellationToken = default)
            => completionService.GetCompletionsInternalAsync(document, caretPosition, trigger, roles, options, cancellationToken);

        public static Task<(CompletionList? completionList, bool expandItemsAvailable)> GetCompletionsAsync(
            this CompletionService completionService,
            Document document,
            int caretPosition,
            CompletionTrigger trigger,
            ImmutableHashSet<string>? roles,
            CancellationToken cancellationToken)
            => completionService.GetCompletionsInternalAsync(document, caretPosition, trigger, roles, options: null, cancellationToken);

        public static string? GetProviderName(this CompletionItem completionItem) => completionItem.ProviderName;

        [Obsolete("Use IncludeItemsFromUnimportedNamespaces instead")]
        public static PerLanguageOption<bool?> ShowItemsFromUnimportedNamespaces = (PerLanguageOption<bool?>)CompletionOptions.ShowItemsFromUnimportedNamespaces;

        public static bool? IncludeItemsFromUnimportedNamespaces(Document document)
            => document.Project.Solution.Options.GetOption(CompletionOptions.ShowItemsFromUnimportedNamespaces, document.Project.Language);
    }
}
