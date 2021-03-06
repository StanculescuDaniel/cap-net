﻿using CAPNet.Models;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class MsgTypeRejectionValidator : Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public MsgTypeRejectionValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new MsgTypeRejectionError();
            }
        }

        /// <summary>
        /// Message Type that is Error should have description in note
        /// </summary>
        public override bool IsValid
        {
            get
            {
                var messageTypeIsNotError = !Entity.MessageType.Equals(MessageType.Error);
                var noteIsNotNullOrEmpty = !string.IsNullOrEmpty(Entity.Note);

                return messageTypeIsNotError || noteIsNotNullOrEmpty;
            }
        }
    }
}
