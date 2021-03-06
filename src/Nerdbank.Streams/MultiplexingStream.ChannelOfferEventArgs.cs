﻿// Copyright (c) Andrew Arnott. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Nerdbank.Streams
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Pipelines;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft;
    using Microsoft.VisualStudio.Threading;

    /// <content>
    /// Contains the <see cref="ChannelOfferEventArgs"/> nested type.
    /// </content>
    public partial class MultiplexingStream
    {
        /// <summary>
        /// Describes an offer for a channel.
        /// </summary>
        public class ChannelOfferEventArgs : EventArgs
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ChannelOfferEventArgs"/> class.
            /// </summary>
            /// <param name="id">The unique ID of the channel.</param>
            /// <param name="name">The name of the channel.</param>
            /// <param name="isAccepted">A value indicating whether the channel has already been accepted.</param>
            internal ChannelOfferEventArgs(QualifiedChannelId id, string name, bool isAccepted)
            {
                this.QualifiedId = id;
                this.Name = name;
                this.IsAccepted = isAccepted;
            }

            /// <inheritdoc cref="QualifiedId"/>
            [Obsolete("Use " + nameof(QualifiedId) + " instead.")]
            public int Id => checked((int)this.QualifiedId.Id);

            /// <summary>
            /// Gets the unique ID of the channel.
            /// </summary>
            public QualifiedChannelId QualifiedId { get; }

            /// <summary>
            /// Gets the name of the channel.
            /// </summary>
            public string Name { get; }

            /// <summary>
            /// Gets a value indicating whether the channel has already been accepted.
            /// </summary>
            public bool IsAccepted { get; }
        }
    }
}
