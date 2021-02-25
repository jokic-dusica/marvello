using Marvello.Data.Entities;
using Marvello.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marvello.Repository.Repositories
{
   public class CommentRepository : Repository<Comment>, ICommentRepository
    {

        public CommentRepository(MarvelloDBContext dBContext) : base(dBContext)
        {
                
        }
    }
}
