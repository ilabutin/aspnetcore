// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions for remote authentication services.
    /// </summary>
    public static class RemoteAuthenticationBuilderExtensions
    {
        /// <summary>
        /// Replaces the existing <see cref="AccountClaimsPrincipalFactory{TAccount}"/> with the user factory defined by <typeparamref name="TAccountClaimsPrincipalFactory"/>.
        /// </summary>
        /// <typeparam name="TRemoteAuthenticationState">The remote authentication state.</typeparam>
        /// <typeparam name="TAccount">The account type.</typeparam>
        /// <typeparam name="TAccountClaimsPrincipalFactory">The new user factory type.</typeparam>
        /// <param name="builder">The <see cref="IRemoteAuthenticationBuilder{TRemoteAuthenticationState, TAccount}"/>.</param>
        /// <returns>The <see cref="IRemoteAuthenticationBuilder{TRemoteAuthenticationState, TAccount}"/>.</returns>
        public static IRemoteAuthenticationBuilder<TRemoteAuthenticationState, TAccount> AddUserFactory<TRemoteAuthenticationState, TAccount, TAccountClaimsPrincipalFactory>(
            this IRemoteAuthenticationBuilder<TRemoteAuthenticationState, TAccount> builder)
            where TRemoteAuthenticationState : RemoteAuthenticationState, new()
            where TAccount : RemoteUserAccount
            where TAccountClaimsPrincipalFactory : UserFactory<TAccount>
        {
            builder.Services.Replace(ServiceDescriptor.Scoped<UserFactory<TAccount>, TAccountClaimsPrincipalFactory>());

            return builder;
        }

        /// <summary>
        /// Replaces the existing <see cref="AccountClaimsPrincipalFactory{TAccount}"/> with the user factory defined by <typeparamref name="TAccountClaimsPrincipalFactory"/>.
        /// </summary>
        /// <typeparam name="TRemoteAuthenticationState">The remote authentication state.</typeparam>
        /// <typeparam name="TAccountClaimsPrincipalFactory">The new user factory type.</typeparam>
        /// <param name="builder">The <see cref="IRemoteAuthenticationBuilder{TRemoteAuthenticationState, Account}"/>.</param>
        /// <returns>The <see cref="IRemoteAuthenticationBuilder{TRemoteAuthenticationState, Account}"/>.</returns>
        public static IRemoteAuthenticationBuilder<TRemoteAuthenticationState, RemoteUserAccount> AddUserFactory<TRemoteAuthenticationState, TAccountClaimsPrincipalFactory>(
            this IRemoteAuthenticationBuilder<TRemoteAuthenticationState, RemoteUserAccount> builder)
            where TRemoteAuthenticationState : RemoteAuthenticationState, new()
            where TAccountClaimsPrincipalFactory : UserFactory<RemoteUserAccount> => builder.AddUserFactory<TRemoteAuthenticationState, RemoteUserAccount, TAccountClaimsPrincipalFactory>();

        /// <summary>
        /// Replaces the existing <see cref="AccountClaimsPrincipalFactory{TAccount}"/> with the user factory defined by <typeparamref name="TAccountClaimsPrincipalFactory"/>.
        /// </summary>
        /// <typeparam name="TAccountClaimsPrincipalFactory">The new user factory type.</typeparam>
        /// <param name="builder">The <see cref="IRemoteAuthenticationBuilder{RemoteAuthenticationState, Account}"/>.</param>
        /// <returns>The <see cref="IRemoteAuthenticationBuilder{RemoteAuthenticationState, Account}"/>.</returns>
        public static IRemoteAuthenticationBuilder<RemoteAuthenticationState, RemoteUserAccount> AddUserFactory<TAccountClaimsPrincipalFactory>(
            this IRemoteAuthenticationBuilder<RemoteAuthenticationState, RemoteUserAccount> builder)
            where TAccountClaimsPrincipalFactory : AccountClaimsPrincipalFactory<RemoteUserAccount> => builder.AddUserFactory<RemoteAuthenticationState, RemoteUserAccount, TAccountClaimsPrincipalFactory>();
    }
}
