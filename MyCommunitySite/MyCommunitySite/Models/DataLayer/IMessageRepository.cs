﻿using Newtonsoft.Json.Bson;

namespace MyCommunitySite.Models
{
    public interface IMessageRepository
    {
        IQueryable<Message> Messages { get; }
        public Task AddMessageAsync(Message message);
        public Task UpdateMessageAsync(Message message);
        public int DeleteMessage(int messageId);
    }
}
