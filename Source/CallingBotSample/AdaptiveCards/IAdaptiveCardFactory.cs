// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.Bot.Schema;

namespace CallingBotSample.AdaptiveCards
{
    public interface IAdaptiveCardFactory
    {
        /// <summary>
        /// Create a card shown on welcome/when a action is unknown
        /// </summary>
        /// <param name="showJoinMeetingButton">Shows a join meeting button if true</param>
        /// <returns>A card with "Create call" and "Join Meeting"</returns>
        Attachment CreateWelcomeCard(bool showJoinMeetingButton);

        /// <summary>
        /// Create a card for showing in a meeting.
        /// </summary>
        /// <param name="callId">Call 'sid</param>
        /// <returns>Card with action set that can be performed on the meeting</returns>
        Attachment CreateMeetingActionsCard(string? callId);

        /// <summary>
        /// Create a card for choosing a user
        /// </summary>
        /// <param name="choiceLabel">Label for the picker</param>
        /// <param name="action">Action being undertaken by the card</param>
        /// <param name="callId">Call's id</param>
        /// <param name="isMultiSelect">Is multiple users able to be selected</param>
        /// <returns>Card with people picker for choosing users</returns>
        Attachment CreatePeoplePickerCard(string choiceLabel, string action, string? callId, bool isMultiSelect = false);
    }
}
