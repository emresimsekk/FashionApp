﻿using FashionApp.Entities.Concrete;
using FashionApp.Shared.Data.Abstract;

namespace FashionApp.Data.Abstract
{
    public interface IMessageRepository : IEntityRepository<Message>
    {
    }
}
